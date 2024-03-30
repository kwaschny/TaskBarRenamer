namespace TaskBarRenamer
{
    partial class FormAutomatic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAutomatic));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.textBoxFrom = new System.Windows.Forms.TextBox();
            this.labelFrom = new System.Windows.Forms.Label();
            this.labelTo = new System.Windows.Forms.Label();
            this.textBoxTo = new System.Windows.Forms.TextBox();
            this.checkBoxForceName = new System.Windows.Forms.CheckBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.radioButtonExact = new System.Windows.Forms.RadioButton();
            this.radioButtonWildcard = new System.Windows.Forms.RadioButton();
            this.radioButtonRegExp = new System.Windows.Forms.RadioButton();
            this.labelMatch = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.OK_Click);
            // 
            // textBoxFrom
            // 
            resources.ApplyResources(this.textBoxFrom, "textBoxFrom");
            this.textBoxFrom.Name = "textBoxFrom";
            this.textBoxFrom.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // labelFrom
            // 
            resources.ApplyResources(this.labelFrom, "labelFrom");
            this.labelFrom.Name = "labelFrom";
            // 
            // labelTo
            // 
            resources.ApplyResources(this.labelTo, "labelTo");
            this.labelTo.Name = "labelTo";
            // 
            // textBoxTo
            // 
            resources.ApplyResources(this.textBoxTo, "textBoxTo");
            this.textBoxTo.Name = "textBoxTo";
            this.textBoxTo.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // checkBoxForceName
            // 
            resources.ApplyResources(this.checkBoxForceName, "checkBoxForceName");
            this.checkBoxForceName.Name = "checkBoxForceName";
            this.checkBoxForceName.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // radioButtonExact
            // 
            resources.ApplyResources(this.radioButtonExact, "radioButtonExact");
            this.radioButtonExact.Checked = true;
            this.radioButtonExact.Name = "radioButtonExact";
            this.radioButtonExact.TabStop = true;
            this.radioButtonExact.UseVisualStyleBackColor = true;
            this.radioButtonExact.CheckedChanged += new System.EventHandler(this.radioButtonExact_CheckedChanged);
            // 
            // radioButtonWildcard
            // 
            resources.ApplyResources(this.radioButtonWildcard, "radioButtonWildcard");
            this.radioButtonWildcard.Name = "radioButtonWildcard";
            this.radioButtonWildcard.UseVisualStyleBackColor = true;
            this.radioButtonWildcard.CheckedChanged += new System.EventHandler(this.radioButtonWildcard_CheckedChanged);
            // 
            // radioButtonRegExp
            // 
            resources.ApplyResources(this.radioButtonRegExp, "radioButtonRegExp");
            this.radioButtonRegExp.Name = "radioButtonRegExp";
            this.radioButtonRegExp.UseVisualStyleBackColor = true;
            this.radioButtonRegExp.CheckedChanged += new System.EventHandler(this.radioButtonRegExp_CheckedChanged);
            // 
            // labelMatch
            // 
            resources.ApplyResources(this.labelMatch, "labelMatch");
            this.labelMatch.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelMatch.Name = "labelMatch";
            // 
            // FormAutomatic
            // 
            this.AcceptButton = this.buttonOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.labelMatch);
            this.Controls.Add(this.radioButtonRegExp);
            this.Controls.Add(this.radioButtonWildcard);
            this.Controls.Add(this.radioButtonExact);
            this.Controls.Add(this.checkBoxForceName);
            this.Controls.Add(this.labelTo);
            this.Controls.Add(this.textBoxTo);
            this.Controls.Add(this.labelFrom);
            this.Controls.Add(this.textBoxFrom);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAutomatic";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TextBox textBoxFrom;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.TextBox textBoxTo;
        private System.Windows.Forms.CheckBox checkBoxForceName;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.RadioButton radioButtonRegExp;
        private System.Windows.Forms.RadioButton radioButtonWildcard;
        private System.Windows.Forms.RadioButton radioButtonExact;
        private System.Windows.Forms.Label labelMatch;
    }
}