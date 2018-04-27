using Microsoft.Win32;
using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TaskBarRenamer
{
    internal static class Program
    {
        #region Fields

        public static string Build
        {
            get
            {
                return "2012-11-12";
            }
        }

        public static string Website
        {
            get
            {
                return "https://kwaschny.net/";
            }
        }

        #endregion

        #region Methods

        // Constructor
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new formMain());
        }

        #region DLLImports

        [DllImport("user32")]
        public static extern IntPtr GetWindow(
            IntPtr hWnd,
            int wFlag
            );

        [DllImport("user32", EntryPoint = "GetClassLong", CharSet = CharSet.Auto)]
        public static extern int GetClassLongA(
            int hWnd,
            int nIndex
            );

        [DllImport("user32.dll")]
        public static extern bool IsWindow(
            int hWnd
            );

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(
            int hWnd,
            int Msg,
            IntPtr wParam,
            IntPtr lParam
            );

        [DllImport("User32.dll")]
        public static extern bool IsIconic(
            int hWnd
            );

        [DllImport("User32.dll")]
        public static extern Int32 SetForegroundWindow(
            int hWnd
            );

        [DllImport("user32.dll")]
        public static extern bool ShowWindowAsync(
            IntPtr hWnd,
            int cmdShow
            );

        #endregion

        // Misc
        private static int ContainsLike(StringCollection stringCollection, string value)
        {
            // durch Liste laufen und nach Vorkommen des Wertes suchen
            for (int i = 0; i < stringCollection.Count; i++)
            {
                if (stringCollection[i].Contains(value))
                    return i;
            }

            // falls kein Vorkommen
            return -1;
        }

        // Form
        public enum FormOperationResult
        {
            Successful,
            NoEntryFound,
            FormIsNull,
            FormNotVisible,
            FormMinimized,
            FormMaximized,
            CollectionIsNull,
            ValuesCorrupt,
        }
        public static FormOperationResult SaveForm(Form form, StringCollection formsCollection)
        {
            // Validierung
            if (form == null)
                return FormOperationResult.FormIsNull;

            if (formsCollection == null)
                formsCollection = new StringCollection();

            // Fenster nur speichern, wenn sichtbar und weder minimiert noch maximiert
            if (!form.Visible)
                return FormOperationResult.FormNotVisible;
            if (form.WindowState == FormWindowState.Minimized)
                return FormOperationResult.FormMinimized;
            if (form.WindowState == FormWindowState.Maximized)
                return FormOperationResult.FormMaximized;

            // falls Fenster in der Liste bereits vorhanden, dann entfernen,
            // um geändert neu hinzuzufügen
            int index = ContainsLike(formsCollection, form.Name);
            if (index >= 0)
                formsCollection.RemoveAt(index);

            // String der Liste hinzufügen als Name|Left|Top|Width|Height
            formsCollection.Add(string.Format("{0}|{1}|{2}|{3}|{4}", form.Name, form.Left, form.Top, form.Width, form.Height));

            return FormOperationResult.Successful;
        }
        public static FormOperationResult LoadForm(Form form, StringCollection formsCollection)
        {
            // Validierung
            if (form == null)
                return FormOperationResult.FormIsNull;

            if (formsCollection == null)
                return FormOperationResult.CollectionIsNull;

            // sichtbaren Bildschirmbereich ermitteln (erforderlich für Positionsprüfung und ggf. Ausrichtung)
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;

            // prüfen, ob Fenster in der Liste vorhanden ist
            int index = ContainsLike(formsCollection, form.Name);
            if (index >= 0)
            {
                // String aufsplitten in Name|Left|Top|Width|Height
                string[] values = formsCollection[index].Split('|');

                if (values.Length < 5)
                    return FormOperationResult.ValuesCorrupt;

                int tempValue;

                // Fensterposition zuweisem
                tempValue = -1;
                int.TryParse(values[1], out tempValue);
                form.Left = tempValue;

                tempValue = -1;
                int.TryParse(values[2], out tempValue);
                form.Top = tempValue;

                // Fenstergröße nur bei Fenstern mit erlaubter Größenänderung zuweisen
                switch (form.FormBorderStyle)
                {
                    case FormBorderStyle.Sizable:
                    case FormBorderStyle.SizableToolWindow:
                        tempValue = -1;
                        int.TryParse(values[3], out tempValue);
                        form.Width = tempValue;

                        tempValue = -1;
                        int.TryParse(values[4], out tempValue);
                        form.Height = tempValue;
                        break;
                }

                // prüfen, ob Fensterposition innerhalb des sichtbaren Bereiches liegt
                // korrigieren, falls Fensterposition außerhalb des sichtbaren Bereiches
                if (form.Left < 0)
                    form.Left = 0;
                if (form.Left + form.Width > screen.Width)
                    form.Left = screen.Width - form.Width;
                if (form.Top < 0)
                    form.Top = 0;
                if (form.Top + form.Height > screen.Height)
                    form.Top = screen.Height - form.Height;

                return FormOperationResult.Successful;
            }
            // falls Fenster nicht in der Liste vorhanden
            else
            {
                // falls übergeordnetes Fenster existiert, daran zentriert ausrichten
                if (form.Owner != null)
                {
                    form.Left = form.Owner.Left + ((form.Owner.Width / 2) - (form.Width / 2));
                    form.Top = form.Owner.Top + ((form.Owner.Height / 2) - (form.Height / 2));
                }
                // andernfalls am Bildschirmzentrum ausrichten
                else
                {
                    form.Left = (screen.Width / 2) - (form.Width / 2);
                    form.Top = (screen.Height / 2) - (form.Height / 2);
                }
            }

            // falls Fenster nicht in der Liste vorhanden ist
            return FormOperationResult.NoEntryFound;
        }

        // Web
        private static string GetDefaultBrowser()
        {
            const string fileExtension = ".exe";

            string browser = string.Empty;
            RegistryKey key = null;

            try
            {
                key = Registry.ClassesRoot.OpenSubKey(@"HTTP\shell\open\command", false);

                browser = key.GetValue(null).ToString().ToLower().Replace("\"", string.Empty);
                if (!browser.EndsWith(fileExtension))
                {
                    // get rid of everything after the file extension
                    browser = browser.Substring(0, browser.LastIndexOf(fileExtension) + fileExtension.Length);
                }
            }
            finally
            {
                if (key != null) 
                    key.Close();
            }

            return browser;
        }

        public static bool OpenWebsite(string websiteLink)
        {
            if (string.IsNullOrEmpty(websiteLink))
                return false;

            string defaultBrowser = GetDefaultBrowser();
            if (!File.Exists(defaultBrowser))
                return false;

            try
            {
                using (Process p = new Process())
                {
                    p.StartInfo.FileName = defaultBrowser;
                    p.StartInfo.Arguments = websiteLink;
                    p.Start();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}