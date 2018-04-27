namespace TaskBarRenamer
{
    partial class formSettings
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formSettings));
            this.tabControlSettings = new System.Windows.Forms.TabControl();
            this.tabPageRefresh = new System.Windows.Forms.TabPage();
            this.labelSeconds2 = new System.Windows.Forms.Label();
            this.labelEvery2 = new System.Windows.Forms.Label();
            this.numericUpDownForceNamesEvery = new TaskBarRenamer.NumericUpDownFixed();
            this.labelForceNames = new System.Windows.Forms.Label();
            this.labelSeconds1 = new System.Windows.Forms.Label();
            this.labelEvery1 = new System.Windows.Forms.Label();
            this.numericUpDownRefreshEvery = new TaskBarRenamer.NumericUpDownFixed();
            this.checkBoxForegroundOnly = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoRefresh = new System.Windows.Forms.CheckBox();
            this.tabPageUpdate = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxUpdate = new System.Windows.Forms.CheckBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tabControlSettings.SuspendLayout();
            this.tabPageRefresh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownForceNamesEvery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRefreshEvery)).BeginInit();
            this.tabPageUpdate.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlSettings
            // 
            resources.ApplyResources(this.tabControlSettings, "tabControlSettings");
            this.tabControlSettings.Controls.Add(this.tabPageRefresh);
            this.tabControlSettings.Controls.Add(this.tabPageUpdate);
            this.tabControlSettings.Name = "tabControlSettings";
            this.tabControlSettings.SelectedIndex = 0;
            // 
            // tabPageRefresh
            // 
            resources.ApplyResources(this.tabPageRefresh, "tabPageRefresh");
            this.tabPageRefresh.Controls.Add(this.labelSeconds2);
            this.tabPageRefresh.Controls.Add(this.labelEvery2);
            this.tabPageRefresh.Controls.Add(this.numericUpDownForceNamesEvery);
            this.tabPageRefresh.Controls.Add(this.labelForceNames);
            this.tabPageRefresh.Controls.Add(this.labelSeconds1);
            this.tabPageRefresh.Controls.Add(this.labelEvery1);
            this.tabPageRefresh.Controls.Add(this.numericUpDownRefreshEvery);
            this.tabPageRefresh.Controls.Add(this.checkBoxForegroundOnly);
            this.tabPageRefresh.Controls.Add(this.checkBoxAutoRefresh);
            this.tabPageRefresh.Name = "tabPageRefresh";
            this.tabPageRefresh.UseVisualStyleBackColor = true;
            // 
            // labelSeconds2
            // 
            resources.ApplyResources(this.labelSeconds2, "labelSeconds2");
            this.labelSeconds2.Name = "labelSeconds2";
            // 
            // labelEvery2
            // 
            resources.ApplyResources(this.labelEvery2, "labelEvery2");
            this.labelEvery2.Name = "labelEvery2";
            // 
            // numericUpDownForceNamesEvery
            // 
            resources.ApplyResources(this.numericUpDownForceNamesEvery, "numericUpDownForceNamesEvery");
            this.numericUpDownForceNamesEvery.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::TaskBarRenamer.Properties.Settings.Default, "ForceNamesEvery", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDownForceNamesEvery.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.numericUpDownForceNamesEvery.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownForceNamesEvery.Name = "numericUpDownForceNamesEvery";
            this.numericUpDownForceNamesEvery.Value = global::TaskBarRenamer.Properties.Settings.Default.ForceNamesEvery;
            // 
            // labelForceNames
            // 
            resources.ApplyResources(this.labelForceNames, "labelForceNames");
            this.labelForceNames.Name = "labelForceNames";
            // 
            // labelSeconds1
            // 
            resources.ApplyResources(this.labelSeconds1, "labelSeconds1");
            this.labelSeconds1.Name = "labelSeconds1";
            // 
            // labelEvery1
            // 
            resources.ApplyResources(this.labelEvery1, "labelEvery1");
            this.labelEvery1.Name = "labelEvery1";
            // 
            // numericUpDownRefreshEvery
            // 
            resources.ApplyResources(this.numericUpDownRefreshEvery, "numericUpDownRefreshEvery");
            this.numericUpDownRefreshEvery.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::TaskBarRenamer.Properties.Settings.Default, "RefreshEvery", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDownRefreshEvery.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.numericUpDownRefreshEvery.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownRefreshEvery.Name = "numericUpDownRefreshEvery";
            this.numericUpDownRefreshEvery.Value = global::TaskBarRenamer.Properties.Settings.Default.RefreshEvery;
            // 
            // checkBoxForegroundOnly
            // 
            resources.ApplyResources(this.checkBoxForegroundOnly, "checkBoxForegroundOnly");
            this.checkBoxForegroundOnly.Checked = global::TaskBarRenamer.Properties.Settings.Default.ForegroundOnly;
            this.checkBoxForegroundOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxForegroundOnly.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TaskBarRenamer.Properties.Settings.Default, "ForegroundOnly", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxForegroundOnly.Name = "checkBoxForegroundOnly";
            this.checkBoxForegroundOnly.UseVisualStyleBackColor = true;
            this.checkBoxForegroundOnly.CheckedChanged += new System.EventHandler(this.ForegroundOnly_CheckedChanged);
            // 
            // checkBoxAutoRefresh
            // 
            resources.ApplyResources(this.checkBoxAutoRefresh, "checkBoxAutoRefresh");
            this.checkBoxAutoRefresh.Checked = global::TaskBarRenamer.Properties.Settings.Default.AutoRefresh;
            this.checkBoxAutoRefresh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoRefresh.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TaskBarRenamer.Properties.Settings.Default, "AutoRefresh", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxAutoRefresh.Name = "checkBoxAutoRefresh";
            this.checkBoxAutoRefresh.UseVisualStyleBackColor = true;
            this.checkBoxAutoRefresh.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // tabPageUpdate
            // 
            resources.ApplyResources(this.tabPageUpdate, "tabPageUpdate");
            this.tabPageUpdate.Controls.Add(this.label1);
            this.tabPageUpdate.Controls.Add(this.checkBoxUpdate);
            this.tabPageUpdate.Name = "tabPageUpdate";
            this.tabPageUpdate.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Name = "label1";
            // 
            // checkBoxUpdate
            // 
            resources.ApplyResources(this.checkBoxUpdate, "checkBoxUpdate");
            this.checkBoxUpdate.Checked = global::TaskBarRenamer.Properties.Settings.Default.CheckForUpdate;
            this.checkBoxUpdate.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TaskBarRenamer.Properties.Settings.Default, "CheckForUpdate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxUpdate.Name = "checkBoxUpdate";
            this.checkBoxUpdate.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.OK_Click);
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // formSettings
            // 
            this.AcceptButton = this.buttonOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.tabControlSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.tabControlSettings.ResumeLayout(false);
            this.tabPageRefresh.ResumeLayout(false);
            this.tabPageRefresh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownForceNamesEvery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRefreshEvery)).EndInit();
            this.tabPageUpdate.ResumeLayout(false);
            this.tabPageUpdate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlSettings;
        private System.Windows.Forms.TabPage tabPageRefresh;
        private System.Windows.Forms.Label labelSeconds2;
        private System.Windows.Forms.Label labelEvery2;
        private NumericUpDownFixed numericUpDownForceNamesEvery;
        private System.Windows.Forms.Label labelForceNames;
        private System.Windows.Forms.Label labelSeconds1;
        private System.Windows.Forms.Label labelEvery1;
        private NumericUpDownFixed numericUpDownRefreshEvery;
        private System.Windows.Forms.CheckBox checkBoxForegroundOnly;
        private System.Windows.Forms.CheckBox checkBoxAutoRefresh;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TabPage tabPageUpdate;
        private System.Windows.Forms.CheckBox checkBoxUpdate;
        private System.Windows.Forms.Label label1;

    }
}