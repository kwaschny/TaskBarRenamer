using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;
using TaskBarRenamer.Languages;

namespace TaskBarRenamer
{
    public partial class FormMain : Form
    {
        #region Fields

        // int => Handle
        private readonly Dictionary<int, TaskBarWindow> taskBarWindows = new Dictionary<int, TaskBarWindow>();

        // int => Handle
        private readonly Dictionary<int, TaskBarWindow> lastRenames = new Dictionary<int, TaskBarWindow>();

        // string => FromName
        private readonly Dictionary<string, AutomaticEntry> automaticEntries = new Dictionary<string, AutomaticEntry>();

        private ListView CurrentListView
        {
            get
            {
                switch (tabControlMain.SelectedIndex)
                {
                    case 0:
                        return listViewWindows;
                    case 1:
                        return listViewRenamed;
                    case 2:
                        return listViewAutomatic;
                    default:
                        return null;
                }
            }
        }
        private int NumberOfForcedNames
        {
            get
            {
                int counter = 0;

                foreach (TaskBarWindow window in taskBarWindows.Values)
                    if (window.ForceName)
                        counter += 1;

                return counter;
            }
        }

        #endregion

        #region Methods

        private IEnumerable<EnumWindowsItem> GetTaskBarWindows(bool includeAllWindows)
        {
            const int GW_OWNER = 4;

            List<EnumWindowsItem> collection = new List<EnumWindowsItem>();

            EnumWindows processWindows = new EnumWindows();
            processWindows.GetWindows();

            if (processWindows.Items.Count > 0)
            {
                foreach (EnumWindowsItem window in processWindows.Items)
                {
                    if ((!window.Visible) || (Program.GetWindow(window.Handle, GW_OWNER) != IntPtr.Zero))
                        continue;

                    if (includeAllWindows)
                        collection.Add(window);
                    else if ((window.ExtendedWindowStyle & ExtendedWindowStyleFlags.WS_EX_TOOLWINDOW) != ExtendedWindowStyleFlags.WS_EX_TOOLWINDOW)
                        collection.Add(window);
                }
            }

            return collection;
        }
        private Icon GetIconFromWindowHanlde(int hWnd)
        {
            const int WM_GETICON = 0x007f;
            const int GCL_HICON = -14;

            IntPtr hIcon;
            hIcon = (IntPtr)Program.SendMessage(hWnd, WM_GETICON, IntPtr.Zero, IntPtr.Zero);
            if (hIcon == IntPtr.Zero)
                hIcon = (IntPtr)Program.GetClassLongA(hWnd, GCL_HICON);

            if (hIcon != IntPtr.Zero)
                return Icon.FromHandle(hIcon);
            else
                return null;
        }
        private void Defrag()
        {
            List<int> handles = new List<int>();
            foreach (int handle in taskBarWindows.Keys)
            {
                if (!Program.IsWindow(handle))
                    handles.Add(handle);
            }
            foreach (int handle in handles)
                taskBarWindows.Remove(handle);
        }

        private void RenameWindow(int hWnd, string text, bool forceName)
        {
            const int WM_SETTEXT = 0x0C;

            IntPtr textPointer = IntPtr.Zero;
            try
            {
                textPointer = Marshal.StringToHGlobalUni(text);
                Program.SendMessage(hWnd, WM_SETTEXT, IntPtr.Zero, textPointer);
                if (taskBarWindows.ContainsKey(hWnd))
                {
                    taskBarWindows[hWnd].NewName = text;
                    taskBarWindows[hWnd].ForceName = forceName;
                }
            }
            finally
            {
                Marshal.FreeHGlobal(textPointer);
            }
        }
        private void RestoreWindowName(int hWnd)
        {
            if (!taskBarWindows.ContainsKey(hWnd))
                return;

            RenameWindow(hWnd, taskBarWindows[hWnd].OriginalName, false);
            taskBarWindows[hWnd].NewName = null;
        }
        private void ShowWindow(int hWnd)
        {
            if (Program.IsIconic(hWnd))
                Program.ShowWindowAsync(new IntPtr(hWnd), 9);
            else
                Program.SetForegroundWindow(hWnd);
        }
        private void CloseWindow(int hWnd)
        {
            const int WM_CLOSE = 0x10;

            try
            {
                Program.SendMessage(hWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            }
            catch
            {
                MessageBox.Show("The selected program(s) cannot be closed. Try to close them manually.", "Program(s) could not be closed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowTaskBarWindows(string searchText)
        {
            listViewWindows.Items.Clear();
            imageListSmallIcons.Images.Clear();

            listViewWindows.BeginUpdate();
            foreach (EnumWindowsItem window in GetTaskBarWindows(listAllWindowsToolStripMenuItem.Checked))
            {
                TaskBarWindow taskBarWindow = new TaskBarWindow(window);
                if (lastRenames.ContainsKey((int)window.Handle))
                    taskBarWindow.SetPredecessor(lastRenames[(int)window.Handle]);

                string container = string.Empty;
                if (automaticEntries.ContainsKey(window.Text))
                    container = window.Text;
                else if (automaticEntries.ContainsKey(window.ClassName))
                    container = window.ClassName;
                if (!string.IsNullOrEmpty(container))
                    RenameWindow((int)window.Handle, automaticEntries[container].ToName, automaticEntries[container].ForceName);

                if (!string.IsNullOrEmpty(searchText))
                {
                    string text = searchText.ToLower();
                    if (!(window.Text.ToLower().Contains(text) | window.ClassName.ToLower().Contains(text)))
                        continue;
                }

                ListViewItem item = new ListViewItem();

                if (string.IsNullOrEmpty(window.Text))
                {
                    item.Text = window.ClassName;
                    item.ForeColor = SystemColors.GrayText;
                }
                else
                    item.Text = window.Text;

                Icon icon = GetIconFromWindowHanlde((int)window.Handle);
                if (icon != null)
                {
                    imageListSmallIcons.Images.Add(window.Handle.ToString(), icon);
                    item.ImageIndex = imageListSmallIcons.Images.Count - 1;
                }

                item.Tag = window.Handle;
                listViewWindows.Items.Add(item);

                if (!taskBarWindows.ContainsKey((int)window.Handle))
                    taskBarWindows.Add((int)window.Handle, taskBarWindow);
            }
            listViewWindows.EndUpdate();
        }
        private void ShowTaskBarWindows()
        {
            ShowTaskBarWindows(string.Empty);
        }
        private void ShowRenamedWindows(string searchText)
        {
            if (listViewRenamed.Columns.Count < 2)
                return;

            Defrag();
            listViewRenamed.Items.Clear();

            listViewRenamed.BeginUpdate();
            foreach (TaskBarWindow window in taskBarWindows.Values)
            {
                if (!window.IsRenamed)
                    continue;

                if (!string.IsNullOrEmpty(searchText))
                {
                    string text = searchText.ToLower();
                    if (!(window.NewName.ToLower().Contains(text) | window.OriginalName.ToLower().Contains(text)))
                        continue;
                }

                ListViewItem item = new ListViewItem(new string[] { window.NewName, window.OriginalName });

                if (imageListSmallIcons.Images.ContainsKey(window.Handle.ToString()))
                    item.ImageKey = window.Handle.ToString();

                item.Tag = window.Handle;
                listViewRenamed.Items.Add(item);
            }
            listViewRenamed.EndUpdate();
        }
        private void ShowRenamedWindows()
        {
            ShowRenamedWindows(string.Empty);
        }

        private void AddAutomatic(string renameThis, string toThis, bool forceName)
        {
            if (automaticEntries.ContainsKey(renameThis))
                automaticEntries.Remove(renameThis);

            automaticEntries.Add(renameThis, new AutomaticEntry(renameThis, toThis, forceName));
        }
        private void RemoveAutomatic(string renameThis)
        {
            if (automaticEntries.ContainsKey(renameThis))
                automaticEntries.Remove(renameThis);
        }
        private void ShowAutomaticEntries(string searchText)
        {
            if (listViewAutomatic.Columns.Count < 2)
                return;

            listViewAutomatic.Items.Clear();

            listViewAutomatic.BeginUpdate();
            foreach (AutomaticEntry entry in automaticEntries.Values)
            {
                if (!string.IsNullOrEmpty(searchText))
                {
                    string text = searchText.ToLower();
                    if (!(entry.FromName.ToLower().Contains(text) | entry.ToName.ToLower().Contains(text)))
                        continue;
                }

                ListViewItem item = new ListViewItem(new string[] { entry.FromName, entry.ToName })
                {
                    Tag = entry
                };

                listViewAutomatic.Items.Add(item);
            }
            listViewAutomatic.EndUpdate();
        }
        private void ShowAutomaticEntries()
        {
            ShowAutomaticEntries(string.Empty);
        }

        private void ShowMain()
        {
            notifyIconMain.Visible = false;
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
        }
        private void RefreshList()
        {
            ListView currentListView = CurrentListView;
            List<long> handles = new List<long>();
            List<string> names = new List<string>();

            if ((currentListView == listViewWindows) || (currentListView == listViewRenamed))
                handles = SaveListViewSelectionByHandle(currentListView);
            else if (currentListView == listViewAutomatic)
                names = SaveListViewSelectionByName(currentListView);

            if (textBoxSearch.Text != Language.Search)
            {
                ShowTaskBarWindows(textBoxSearch.Text);
                ShowRenamedWindows(textBoxSearch.Text);
                ShowAutomaticEntries(textBoxSearch.Text);
            }
            else
            {
                ShowTaskBarWindows();
                ShowRenamedWindows();
                ShowAutomaticEntries();
            }

            if ((currentListView == listViewWindows) || (currentListView == listViewRenamed))
                RestoreListViewSelectionByHandle(currentListView, handles);
            else if (currentListView == listViewAutomatic)
                RestoreListViewSelectionByName(currentListView, names);

            bool selected = (listViewAutomatic.SelectedItems.Count > 0);
            buttonEdit.Enabled = selected;
            buttonRemove.Enabled = selected;
        }
        private void RefreshIntervals()
        {
            timerAutoRefresh.Interval = (int)Math.Round((decimal)(Properties.Settings.Default.RefreshEvery * 1000));
            timerForceNames.Interval = (int)Math.Round((decimal)(Properties.Settings.Default.ForceNamesEvery * 1000));
        }

        private List<long> SaveListViewSelectionByHandle(ListView listView)
        {
            List<long> handles = new List<long>();

            foreach (ListViewItem item in listView.SelectedItems)
            {
                if (item.Tag == null)
                    continue;

                if (long.TryParse(item.Tag.ToString(), out long handleKey))
                {
                    if (!handles.Contains(handleKey))
                        handles.Add(handleKey);
                }
            }

            return handles;
        }
        private List<string> SaveListViewSelectionByName(ListView listView)
        {
            List<string> names = new List<string>();

            foreach (ListViewItem item in listView.SelectedItems)
            {
                if (!names.Contains(item.Text))
                    names.Add(item.Text);
            }

            return names;
        }
        private void RestoreListViewSelectionByHandle(ListView listView, ICollection<long> handles)
        {
            listView.SelectedItems.Clear();
            listView.BeginUpdate();
            foreach (ListViewItem item in listView.Items)
            {
                if (item.Tag == null)
                    continue;

                if (long.TryParse(item.Tag.ToString(), out long currentHandle))
                {
                    if (handles.Contains(currentHandle))
                        item.Selected = true;
                }
            }
            listView.EndUpdate();
        }
        private void RestoreListViewSelectionByName(ListView listView, ICollection<string> names)
        {
            listView.SelectedItems.Clear();
            listView.BeginUpdate();
            foreach (ListViewItem item in listView.Items)
            {
                if (names.Contains(item.Text))
                    item.Selected = true;
            }
            listView.EndUpdate();
        }

        public FormMain()
        {
            InitializeComponent();

            string app = Application.ProductName + " " + Application.ProductVersion;
            this.Text = app;
            notifyIconMain.Text = app;
        }

        #endregion

        #region Click/Key-Events

        private void ShowMain_Click(object sender, EventArgs e)
        {
            ShowMain();
        }
        private void Tray_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                ShowMain();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void RefreshSettings_Click(object sender, EventArgs e)
        {
            FormSettings form = new FormSettings(SettingCategory.Refresh);
            if (form.ShowDialog(this) == DialogResult.OK)
                RefreshIntervals();
        }
        private void Website_Click(object sender, EventArgs e)
        {
            Program.OpenWebsite(Program.Website);
        }
        private void Version_Click(object sender, EventArgs e)
        {
            FormVersion form = new FormVersion(Program.Build, Program.Website);
            form.ShowDialog(this);
        }

        private void Rename_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in CurrentListView.SelectedItems)
            {
                if (item.Tag == null)
                    continue;

                if (int.TryParse(item.Tag.ToString(), out int handle))
                {
                    bool forceName = initialForceNamesToolStripMenuItem.Checked;
                    if (taskBarWindows.ContainsKey(handle))
                        if (taskBarWindows[handle].IsRenamed)
                            forceName = taskBarWindows[handle].ForceName;

                    FormTextInput form = new FormTextInput(Language.InputNewName, item.Text, forceName);
                    if (form.ShowDialog(this) == DialogResult.OK)
                        RenameWindow(handle, form.InputText, form.ForceName);
                }
            }

            RefreshList();
        }
        private void Restore_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in CurrentListView.SelectedItems)
            {
                if (item.Tag == null)
                    continue;

                if (int.TryParse(item.Tag.ToString(), out int handle))
                {
                    RestoreWindowName(handle);
                }
            }

            RefreshList();
        }
        private void ShowWindow_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in CurrentListView.SelectedItems)
            {
                if (item.Tag == null)
                    continue;

                if (int.TryParse(item.Tag.ToString(), out int handle))
                {
                    ShowWindow(handle);
                }
            }
        }
        private void Close_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in CurrentListView.SelectedItems)
            {
                if (item.Tag == null)
                    continue;

                if (int.TryParse(item.Tag.ToString(), out int handle))
                {
                    CloseWindow(handle);
                }
            }

            RefreshList();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            FormAutomatic form = new FormAutomatic(initialForceNamesToolStripMenuItem.Checked);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                AddAutomatic(form.RenameThis, form.ToThis, form.ForceName);

                RefreshList();
            }
        }
        private void Edit_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewAutomatic.SelectedItems)
            {
                if ((item.SubItems.Count < 2) || !(item.Tag is AutomaticEntry))
                    continue;

                AutomaticEntry entry = (AutomaticEntry)item.Tag;

                FormAutomatic form = new FormAutomatic(entry.FromName, entry.ToName, entry.ForceName);
                if (form.ShowDialog(this) == DialogResult.OK)
                    AddAutomatic(form.RenameThis, form.ToThis, form.ForceName);
            }

            RefreshList();
        }
        private void Remove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewAutomatic.SelectedItems)
            {
                RemoveAutomatic(item.Text);
            }

            RefreshList();
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                RefreshList();
        }

        #endregion

        #region Events

        private void Search_Enter(object sender, EventArgs e)
        {
            if (textBoxSearch.Text == Language.Search)
                textBoxSearch.Clear();

            textBoxSearch.ForeColor = SystemColors.HotTrack;
        }
        private void Search_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxSearch.Text))
            {
                textBoxSearch.Text = Language.Search;
                textBoxSearch.ForeColor = SystemColors.GrayText;
            }
        }

        private void Refresh_Changed(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void ContextMenuWindows_Opening(object sender, CancelEventArgs e)
        {
            if (CurrentListView.SelectedItems.Count <= 0)
            {
                e.Cancel = true;
                return;
            }

            bool showRestore = false;
            foreach (ListViewItem item in CurrentListView.SelectedItems)
            {
                if (item.Tag == null)
                    continue;

                if (int.TryParse(item.Tag.ToString(), out int handle))
                {
                    if (taskBarWindows[handle].IsRenamed)
                    {
                        showRestore = true;
                        break;
                    }
                }
            }

            restoreToolStripMenuItem.Visible = showRestore;
        }
        private void ContextMenuAutomatic_Opening(object sender, CancelEventArgs e)
        {
            bool visible = (CurrentListView.SelectedItems.Count > 0);
            editToolStripMenuItem.Visible = visible;
            removeToolStripMenuItem.Visible = visible;
        }

        private void Automatic_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool selected = (listViewAutomatic.SelectedItems.Count > 0);
            buttonEdit.Enabled = selected;
            buttonRemove.Enabled = selected;
        }

        private void AutoRefresh_Tick(object sender, EventArgs e)
        {
            if (!Properties.Settings.Default.AutoRefresh)
                return;
            if ((Properties.Settings.Default.ForegroundOnly) && (this.WindowState == FormWindowState.Minimized))
                return;

            RefreshList();
        }
        private void ForceNames_Tick(object sender, EventArgs e)
        {
            foreach (TaskBarWindow window in taskBarWindows.Values)
            {
                if (!window.ForceName)
                    continue;

                RenameWindow((int)window.Handle, window.NewName, window.ForceName);
            }
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
                return;

            this.ShowInTaskbar = false;
            notifyIconMain.Visible = true;

            if (Properties.Settings.Default.InformAboutTray)
            {
                FormAboutTray form = new FormAboutTray();
                if (form.ShowDialog(this) == DialogResult.OK)
                    Properties.Settings.Default.InformAboutTray = !form.DoNotShowAgain;
            }
        }
        private void Form_Shown(object sender, EventArgs e)
        {
            RefreshList();
        }
        private void Form_Load(object sender, EventArgs e)
        {
            foreach (string line in Properties.Settings.Default.LastRenames)
            {
                string[] values = line.Split(';');
                if (values.Length < 3)
                    continue;

                long.TryParse(values[0], out long handle);

                bool.TryParse(values[2], out bool force);

                if (!lastRenames.ContainsKey((int)handle))
                    lastRenames.Add((int)handle, new TaskBarWindow(handle, values[1], null, force));
            }

            foreach (string line in Properties.Settings.Default.Automatic)
            {
                string[] values = line.Split(';');
                if (values.Length < 3)
                    continue;

                bool.TryParse(values[2], out bool result);

                if (!automaticEntries.ContainsKey(values[0]))
                    automaticEntries.Add(values[0], new AutomaticEntry(values[0], values[1], result));
            }

            Program.LoadForm(this, Properties.Settings.Default.Forms);
            listAllWindowsToolStripMenuItem.Checked = Properties.Settings.Default.ListAllWindows;
            initialForceNamesToolStripMenuItem.Checked = Properties.Settings.Default.InitialForceNames;

            RefreshIntervals();
            timerAutoRefresh.Enabled = true;
            timerForceNames.Enabled = true;
        }
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (NumberOfForcedNames > 0)
                if (MessageBox.Show(Language.ClosingPrompt, string.Empty, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3) != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }

            Properties.Settings.Default.LastRenames.Clear();
            foreach (TaskBarWindow window in taskBarWindows.Values)
                if (window.IsRenamed)
                    Properties.Settings.Default.LastRenames.Add(string.Format("{0};{1};{2}", window.Handle, window.OriginalName.Replace(";", ","), window.ForceName));

            Properties.Settings.Default.Automatic.Clear();
            foreach (AutomaticEntry entry in automaticEntries.Values)
                Properties.Settings.Default.Automatic.Add(string.Format("{0};{1};{2}", entry.FromName, entry.ToName, entry.ForceName));

            Program.SaveForm(this, Properties.Settings.Default.Forms);
            Properties.Settings.Default.ListAllWindows = listAllWindowsToolStripMenuItem.Checked;
            Properties.Settings.Default.InitialForceNames = initialForceNamesToolStripMenuItem.Checked;

            if (timerAutoRefresh != null)
                Properties.Settings.Default.RefreshEvery = (int)Math.Round((decimal)(timerAutoRefresh.Interval / 1000));

            if (timerForceNames != null)
                Properties.Settings.Default.ForceNamesEvery = (int)Math.Round((decimal)(timerForceNames.Interval / 1000));

            Properties.Settings.Default.Save();
        }

        #endregion
    }
}