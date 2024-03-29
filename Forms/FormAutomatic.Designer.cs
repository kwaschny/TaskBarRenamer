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
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.errorProvider.SetError(this.buttonCancel, resources.GetString("buttonCancel.Error"));
            this.errorProvider.SetIconAlignment(this.buttonCancel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("buttonCancel.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.buttonCancel, ((int)(resources.GetObject("buttonCancel.IconPadding"))));
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.errorProvider.SetError(this.buttonOK, resources.GetString("buttonOK.Error"));
            this.errorProvider.SetIconAlignment(this.buttonOK, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("buttonOK.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.buttonOK, ((int)(resources.GetObject("buttonOK.IconPadding"))));
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.OK_Click);
            // 
            // textBoxFrom
            // 
            resources.ApplyResources(this.textBoxFrom, "textBoxFrom");
            this.errorProvider.SetError(this.textBoxFrom, resources.GetString("textBoxFrom.Error"));
            this.errorProvider.SetIconAlignment(this.textBoxFrom, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("textBoxFrom.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.textBoxFrom, ((int)(resources.GetObject("textBoxFrom.IconPadding"))));
            this.textBoxFrom.Name = "textBoxFrom";
            this.textBoxFrom.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // labelFrom
            // 
            resources.ApplyResources(this.labelFrom, "labelFrom");
            this.errorProvider.SetError(this.labelFrom, resources.GetString("labelFrom.Error"));
            this.errorProvider.SetIconAlignment(this.labelFrom, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("labelFrom.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.labelFrom, ((int)(resources.GetObject("labelFrom.IconPadding"))));
            this.labelFrom.Name = "labelFrom";
            // 
            // labelTo
            // 
            resources.ApplyResources(this.labelTo, "labelTo");
            this.errorProvider.SetError(this.labelTo, resources.GetString("labelTo.Error"));
            this.errorProvider.SetIconAlignment(this.labelTo, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("labelTo.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.labelTo, ((int)(resources.GetObject("labelTo.IconPadding"))));
            this.labelTo.Name = "labelTo";
            // 
            // textBoxTo
            // 
            resources.ApplyResources(this.textBoxTo, "textBoxTo");
            this.errorProvider.SetError(this.textBoxTo, resources.GetString("textBoxTo.Error"));
            this.errorProvider.SetIconAlignment(this.textBoxTo, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("textBoxTo.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.textBoxTo, ((int)(resources.GetObject("textBoxTo.IconPadding"))));
            this.textBoxTo.Name = "textBoxTo";
            this.textBoxTo.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // checkBoxForceName
            // 
            resources.ApplyResources(this.checkBoxForceName, "checkBoxForceName");
            this.errorProvider.SetError(this.checkBoxForceName, resources.GetString("checkBoxForceName.Error"));
            this.errorProvider.SetIconAlignment(this.checkBoxForceName, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("checkBoxForceName.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.checkBoxForceName, ((int)(resources.GetObject("checkBoxForceName.IconPadding"))));
            this.checkBoxForceName.Name = "checkBoxForceName";
            this.checkBoxForceName.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            resources.ApplyResources(this.errorProvider, "errorProvider");
            // 
            // FormAutomatic
            // 
            this.AcceptButton = this.buttonOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
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
    }
}