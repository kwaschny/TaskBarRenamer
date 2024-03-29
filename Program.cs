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

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
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

        private static int ContainsLike(StringCollection stringCollection, string value)
        {
            for (int i = 0; i < stringCollection.Count; i++)
            {
                if (stringCollection[i].Contains(value))
                    return i;
            }

            return -1;
        }

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
            if (form == null)
                return FormOperationResult.FormIsNull;

            if (formsCollection == null)
                formsCollection = new StringCollection();

            if (!form.Visible)
                return FormOperationResult.FormNotVisible;
            if (form.WindowState == FormWindowState.Minimized)
                return FormOperationResult.FormMinimized;
            if (form.WindowState == FormWindowState.Maximized)
                return FormOperationResult.FormMaximized;

            int index = ContainsLike(formsCollection, form.Name);
            if (index >= 0)
                formsCollection.RemoveAt(index);

            formsCollection.Add(string.Format("{0}|{1}|{2}|{3}|{4}", form.Name, form.Left, form.Top, form.Width, form.Height));

            return FormOperationResult.Successful;
        }
        public static FormOperationResult LoadForm(Form form, StringCollection formsCollection)
        {
            if (form == null)
                return FormOperationResult.FormIsNull;

            if (formsCollection == null)
                return FormOperationResult.CollectionIsNull;

            Rectangle screen = Screen.PrimaryScreen.WorkingArea;

            int index = ContainsLike(formsCollection, form.Name);
            if (index >= 0)
            {
                string[] values = formsCollection[index].Split('|');

                if (values.Length < 5)
                    return FormOperationResult.ValuesCorrupt;

                int.TryParse(values[1], out int tempValue);
                form.Left = tempValue;
                int.TryParse(values[2], out tempValue);
                form.Top = tempValue;

                switch (form.FormBorderStyle)
                {
                    case FormBorderStyle.Sizable:
                    case FormBorderStyle.SizableToolWindow:
                        int.TryParse(values[3], out tempValue);
                        form.Width = tempValue;
                        int.TryParse(values[4], out tempValue);
                        form.Height = tempValue;
                        break;
                }

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
            else
            {
                if (form.Owner != null)
                {
                    form.Left = form.Owner.Left + ((form.Owner.Width / 2) - (form.Width / 2));
                    form.Top = form.Owner.Top + ((form.Owner.Height / 2) - (form.Height / 2));
                }
                else
                {
                    form.Left = (screen.Width / 2) - (form.Width / 2);
                    form.Top = (screen.Height / 2) - (form.Height / 2);
                }
            }

            return FormOperationResult.NoEntryFound;
        }

        public static bool OpenWebsite(string websiteLink)
        {
            if (string.IsNullOrEmpty(websiteLink))
                return false;

            try
            {
                Process.Start(websiteLink);
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