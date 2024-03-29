namespace TaskBarRenamer
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listAllWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemView = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSettings = new System.Windows.Forms.ToolStripSeparator();
            this.initialForceNamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHelp = new System.Windows.Forms.ToolStripSeparator();
            this.websiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewWindows = new System.Windows.Forms.ListView();
            this.columnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripWindows = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemWindows = new System.Windows.Forms.ToolStripSeparator();
            this.showWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListSmallIcons = new System.Windows.Forms.ImageList(this.components);
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageWindows = new System.Windows.Forms.TabPage();
            this.tabPageRenamed = new System.Windows.Forms.TabPage();
            this.listViewRenamed = new System.Windows.Forms.ListView();
            this.columnHeaderNew = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderOriginal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageAutomatic = new System.Windows.Forms.TabPage();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.listViewAutomatic = new System.Windows.Forms.ListView();
            this.columnHeaderFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripAutomatic = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerForceNames = new System.Windows.Forms.Timer(this.components);
            this.timerAutoRefresh = new System.Windows.Forms.Timer(this.components);
            this.menuStripMain.SuspendLayout();
            this.contextMenuStripWindows.SuspendLayout();
            this.contextMenuStripTray.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageWindows.SuspendLayout();
            this.tabPageRenamed.SuspendLayout();
            this.tabPageAutomatic.SuspendLayout();
            this.contextMenuStripAutomatic.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            resources.ApplyResources(this.menuStripMain, "menuStripMain");
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStripMain.Name = "menuStripMain";
            // 
            // fileToolStripMenuItem
            // 
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            // 
            // exitToolStripMenuItem
            // 
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.Exit_Click);
            // 
            // viewToolStripMenuItem
            // 
            resources.ApplyResources(this.viewToolStripMenuItem, "viewToolStripMenuItem");
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listAllWindowsToolStripMenuItem,
            this.toolStripMenuItemView,
            this.refreshToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            // 
            // listAllWindowsToolStripMenuItem
            // 
            resources.ApplyResources(this.listAllWindowsToolStripMenuItem, "listAllWindowsToolStripMenuItem");
            this.listAllWindowsToolStripMenuItem.CheckOnClick = true;
            this.listAllWindowsToolStripMenuItem.Name = "listAllWindowsToolStripMenuItem";
            this.listAllWindowsToolStripMenuItem.Click += new System.EventHandler(this.Refresh_Changed);
            // 
            // toolStripMenuItemView
            // 
            resources.ApplyResources(this.toolStripMenuItemView, "toolStripMenuItemView");
            this.toolStripMenuItemView.Name = "toolStripMenuItemView";
            // 
            // refreshToolStripMenuItem
            // 
            resources.ApplyResources(this.refreshToolStripMenuItem, "refreshToolStripMenuItem");
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.Refresh_Changed);
            // 
            // settingsToolStripMenuItem
            // 
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshSettingsToolStripMenuItem,
            this.toolStripMenuItemSettings,
            this.initialForceNamesToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            // 
            // refreshSettingsToolStripMenuItem
            // 
            resources.ApplyResources(this.refreshSettingsToolStripMenuItem, "refreshSettingsToolStripMenuItem");
            this.refreshSettingsToolStripMenuItem.Name = "refreshSettingsToolStripMenuItem";
            this.refreshSettingsToolStripMenuItem.Click += new System.EventHandler(this.RefreshSettings_Click);
            // 
            // toolStripMenuItemSettings
            // 
            resources.ApplyResources(this.toolStripMenuItemSettings, "toolStripMenuItemSettings");
            this.toolStripMenuItemSettings.Name = "toolStripMenuItemSettings";
            // 
            // initialForceNamesToolStripMenuItem
            // 
            resources.ApplyResources(this.initialForceNamesToolStripMenuItem, "initialForceNamesToolStripMenuItem");
            this.initialForceNamesToolStripMenuItem.CheckOnClick = true;
            this.initialForceNamesToolStripMenuItem.Name = "initialForceNamesToolStripMenuItem";
            // 
            // helpToolStripMenuItem
            // 
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemHelp,
            this.websiteToolStripMenuItem,
            this.versionToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            // 
            // toolStripMenuItemHelp
            // 
            resources.ApplyResources(this.toolStripMenuItemHelp, "toolStripMenuItemHelp");
            this.toolStripMenuItemHelp.Name = "toolStripMenuItemHelp";
            // 
            // websiteToolStripMenuItem
            // 
            resources.ApplyResources(this.websiteToolStripMenuItem, "websiteToolStripMenuItem");
            this.websiteToolStripMenuItem.Name = "websiteToolStripMenuItem";
            this.websiteToolStripMenuItem.Click += new System.EventHandler(this.Website_Click);
            // 
            // versionToolStripMenuItem
            // 
            resources.ApplyResources(this.versionToolStripMenuItem, "versionToolStripMenuItem");
            this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            this.versionToolStripMenuItem.Click += new System.EventHandler(this.Version_Click);
            // 
            // listViewWindows
            // 
            resources.ApplyResources(this.listViewWindows, "listViewWindows");
            this.listViewWindows.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader});
            this.listViewWindows.ContextMenuStrip = this.contextMenuStripWindows;
            this.listViewWindows.FullRowSelect = true;
            this.listViewWindows.HideSelection = false;
            this.listViewWindows.Name = "listViewWindows";
            this.listViewWindows.SmallImageList = this.imageListSmallIcons;
            this.listViewWindows.UseCompatibleStateImageBehavior = false;
            this.listViewWindows.View = System.Windows.Forms.View.Details;
            this.listViewWindows.DoubleClick += new System.EventHandler(this.Rename_Click);
            // 
            // columnHeader
            // 
            resources.ApplyResources(this.columnHeader, "columnHeader");
            // 
            // contextMenuStripWindows
            // 
            resources.ApplyResources(this.contextMenuStripWindows, "contextMenuStripWindows");
            this.contextMenuStripWindows.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameToolStripMenuItem,
            this.restoreToolStripMenuItem,
            this.toolStripMenuItemWindows,
            this.showWindowToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.contextMenuStripWindows.Name = "contextMenuStripWindows";
            this.contextMenuStripWindows.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuWindows_Opening);
            // 
            // renameToolStripMenuItem
            // 
            resources.ApplyResources(this.renameToolStripMenuItem, "renameToolStripMenuItem");
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.Rename_Click);
            // 
            // restoreToolStripMenuItem
            // 
            resources.ApplyResources(this.restoreToolStripMenuItem, "restoreToolStripMenuItem");
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            this.restoreToolStripMenuItem.Click += new System.EventHandler(this.Restore_Click);
            // 
            // toolStripMenuItemWindows
            // 
            resources.ApplyResources(this.toolStripMenuItemWindows, "toolStripMenuItemWindows");
            this.toolStripMenuItemWindows.Name = "toolStripMenuItemWindows";
            // 
            // showWindowToolStripMenuItem
            // 
            resources.ApplyResources(this.showWindowToolStripMenuItem, "showWindowToolStripMenuItem");
            this.showWindowToolStripMenuItem.Name = "showWindowToolStripMenuItem";
            this.showWindowToolStripMenuItem.Click += new System.EventHandler(this.ShowWindow_Click);
            // 
            // closeToolStripMenuItem
            // 
            resources.ApplyResources(this.closeToolStripMenuItem, "closeToolStripMenuItem");
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.Close_Click);
            // 
            // imageListSmallIcons
            // 
            this.imageListSmallIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            resources.ApplyResources(this.imageListSmallIcons, "imageListSmallIcons");
            this.imageListSmallIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // textBoxSearch
            // 
            resources.ApplyResources(this.textBoxSearch, "textBoxSearch");
            this.textBoxSearch.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.TabStop = false;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.Refresh_Changed);
            this.textBoxSearch.Enter += new System.EventHandler(this.Search_Enter);
            this.textBoxSearch.Leave += new System.EventHandler(this.Search_Leave);
            // 
            // notifyIconMain
            // 
            resources.ApplyResources(this.notifyIconMain, "notifyIconMain");
            this.notifyIconMain.ContextMenuStrip = this.contextMenuStripTray;
            this.notifyIconMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Tray_MouseClick);
            // 
            // contextMenuStripTray
            // 
            resources.ApplyResources(this.contextMenuStripTray, "contextMenuStripTray");
            this.contextMenuStripTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem1});
            this.contextMenuStripTray.Name = "contextMenuStripTray";
            // 
            // showToolStripMenuItem
            // 
            resources.ApplyResources(this.showToolStripMenuItem, "showToolStripMenuItem");
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.ShowMain_Click);
            // 
            // toolStripMenuItem1
            // 
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            // 
            // exitToolStripMenuItem1
            // 
            resources.ApplyResources(this.exitToolStripMenuItem1, "exitToolStripMenuItem1");
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.Exit_Click);
            // 
            // tabControlMain
            // 
            resources.ApplyResources(this.tabControlMain, "tabControlMain");
            this.tabControlMain.Controls.Add(this.tabPageWindows);
            this.tabControlMain.Controls.Add(this.tabPageRenamed);
            this.tabControlMain.Controls.Add(this.tabPageAutomatic);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            // 
            // tabPageWindows
            // 
            resources.ApplyResources(this.tabPageWindows, "tabPageWindows");
            this.tabPageWindows.Controls.Add(this.listViewWindows);
            this.tabPageWindows.Name = "tabPageWindows";
            this.tabPageWindows.UseVisualStyleBackColor = true;
            // 
            // tabPageRenamed
            // 
            resources.ApplyResources(this.tabPageRenamed, "tabPageRenamed");
            this.tabPageRenamed.Controls.Add(this.listViewRenamed);
            this.tabPageRenamed.Name = "tabPageRenamed";
            this.tabPageRenamed.UseVisualStyleBackColor = true;
            // 
            // listViewRenamed
            // 
            resources.ApplyResources(this.listViewRenamed, "listViewRenamed");
            this.listViewRenamed.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderNew,
            this.columnHeaderOriginal});
            this.listViewRenamed.ContextMenuStrip = this.contextMenuStripWindows;
            this.listViewRenamed.FullRowSelect = true;
            this.listViewRenamed.HideSelection = false;
            this.listViewRenamed.Name = "listViewRenamed";
            this.listViewRenamed.SmallImageList = this.imageListSmallIcons;
            this.listViewRenamed.UseCompatibleStateImageBehavior = false;
            this.listViewRenamed.View = System.Windows.Forms.View.Details;
            this.listViewRenamed.DoubleClick += new System.EventHandler(this.Rename_Click);
            // 
            // columnHeaderNew
            // 
            resources.ApplyResources(this.columnHeaderNew, "columnHeaderNew");
            // 
            // columnHeaderOriginal
            // 
            resources.ApplyResources(this.columnHeaderOriginal, "columnHeaderOriginal");
            // 
            // tabPageAutomatic
            // 
            resources.ApplyResources(this.tabPageAutomatic, "tabPageAutomatic");
            this.tabPageAutomatic.Controls.Add(this.buttonEdit);
            this.tabPageAutomatic.Controls.Add(this.buttonRemove);
            this.tabPageAutomatic.Controls.Add(this.buttonAdd);
            this.tabPageAutomatic.Controls.Add(this.listViewAutomatic);
            this.tabPageAutomatic.Name = "tabPageAutomatic";
            this.tabPageAutomatic.UseVisualStyleBackColor = true;
            // 
            // buttonEdit
            // 
            resources.ApplyResources(this.buttonEdit, "buttonEdit");
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // buttonRemove
            // 
            resources.ApplyResources(this.buttonRemove, "buttonRemove");
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // buttonAdd
            // 
            resources.ApplyResources(this.buttonAdd, "buttonAdd");
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.Add_Click);
            // 
            // listViewAutomatic
            // 
            resources.ApplyResources(this.listViewAutomatic, "listViewAutomatic");
            this.listViewAutomatic.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderFrom,
            this.columnHeaderTo});
            this.listViewAutomatic.ContextMenuStrip = this.contextMenuStripAutomatic;
            this.listViewAutomatic.FullRowSelect = true;
            this.listViewAutomatic.HideSelection = false;
            this.listViewAutomatic.Name = "listViewAutomatic";
            this.listViewAutomatic.UseCompatibleStateImageBehavior = false;
            this.listViewAutomatic.View = System.Windows.Forms.View.Details;
            this.listViewAutomatic.SelectedIndexChanged += new System.EventHandler(this.Automatic_SelectedIndexChanged);
            this.listViewAutomatic.DoubleClick += new System.EventHandler(this.Edit_Click);
            // 
            // columnHeaderFrom
            // 
            resources.ApplyResources(this.columnHeaderFrom, "columnHeaderFrom");
            // 
            // columnHeaderTo
            // 
            resources.ApplyResources(this.columnHeaderTo, "columnHeaderTo");
            // 
            // contextMenuStripAutomatic
            // 
            resources.ApplyResources(this.contextMenuStripAutomatic, "contextMenuStripAutomatic");
            this.contextMenuStripAutomatic.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.contextMenuStripAutomatic.Name = "contextMenuStripAutomatic";
            this.contextMenuStripAutomatic.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuAutomatic_Opening);
            // 
            // addToolStripMenuItem
            // 
            resources.ApplyResources(this.addToolStripMenuItem, "addToolStripMenuItem");
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.Add_Click);
            // 
            // editToolStripMenuItem
            // 
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.Edit_Click);
            // 
            // removeToolStripMenuItem
            // 
            resources.ApplyResources(this.removeToolStripMenuItem, "removeToolStripMenuItem");
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.Remove_Click);
            // 
            // timerForceNames
            // 
            this.timerForceNames.Interval = 5000;
            this.timerForceNames.Tick += new System.EventHandler(this.ForceNames_Tick);
            // 
            // timerAutoRefresh
            // 
            this.timerAutoRefresh.Interval = 5000;
            this.timerAutoRefresh.Tick += new System.EventHandler(this.AutoRefresh_Tick);
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.menuStripMain);
            this.Controls.Add(this.tabControlMain);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "FormMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
            this.Load += new System.EventHandler(this.Form_Load);
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.Resize += new System.EventHandler(this.Form_Resize);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.contextMenuStripWindows.ResumeLayout(false);
            this.contextMenuStripTray.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageWindows.ResumeLayout(false);
            this.tabPageRenamed.ResumeLayout(false);
            this.tabPageAutomatic.ResumeLayout(false);
            this.contextMenuStripAutomatic.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem websiteToolStripMenuItem;
        private System.Windows.Forms.ListView listViewWindows;
        private System.Windows.Forms.ColumnHeader columnHeader;
        private System.Windows.Forms.ImageList imageListSmallIcons;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listAllWindowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItemHelp;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItemView;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripWindows;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItemWindows;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIconMain;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTray;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageWindows;
        private System.Windows.Forms.TabPage tabPageRenamed;
        private System.Windows.Forms.TabPage tabPageAutomatic;
        private System.Windows.Forms.ListView listViewRenamed;
        private System.Windows.Forms.ColumnHeader columnHeaderNew;
        private System.Windows.Forms.ColumnHeader columnHeaderOriginal;
        private System.Windows.Forms.ListView listViewAutomatic;
        private System.Windows.Forms.ColumnHeader columnHeaderFrom;
        private System.Windows.Forms.ColumnHeader columnHeaderTo;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItemSettings;
        private System.Windows.Forms.ToolStripMenuItem initialForceNamesToolStripMenuItem;
        private System.Windows.Forms.Timer timerForceNames;
        private System.Windows.Forms.Timer timerAutoRefresh;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripAutomatic;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showWindowToolStripMenuItem;
    }
}

