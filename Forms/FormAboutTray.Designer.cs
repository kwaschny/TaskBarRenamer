namespace TaskBarRenamer
{
    partial class FormAboutTray
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAboutTray));
            this.pictureBoxTray = new System.Windows.Forms.PictureBox();
            this.labelInformAbout = new System.Windows.Forms.Label();
            this.checkBoxDoNotShowAgain = new System.Windows.Forms.CheckBox();
            this.buttonOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTray)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxTray
            // 
            resources.ApplyResources(this.pictureBoxTray, "pictureBoxTray");
            this.pictureBoxTray.Image = global::TaskBarRenamer.Properties.Resources.AboutTray;
            this.pictureBoxTray.Name = "pictureBoxTray";
            this.pictureBoxTray.TabStop = false;
            // 
            // labelInformAbout
            // 
            resources.ApplyResources(this.labelInformAbout, "labelInformAbout");
            this.labelInformAbout.Name = "labelInformAbout";
            // 
            // checkBoxDoNotShowAgain
            // 
            resources.ApplyResources(this.checkBoxDoNotShowAgain, "checkBoxDoNotShowAgain");
            this.checkBoxDoNotShowAgain.Name = "checkBoxDoNotShowAgain";
            this.checkBoxDoNotShowAgain.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // FormAboutTray
            // 
            this.AcceptButton = this.buttonOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.checkBoxDoNotShowAgain);
            this.Controls.Add(this.labelInformAbout);
            this.Controls.Add(this.pictureBoxTray);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAboutTray";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTray)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.PictureBox pictureBoxTray;
        private System.Windows.Forms.Label labelInformAbout;
        private System.Windows.Forms.CheckBox checkBoxDoNotShowAgain;
        private System.Windows.Forms.Button buttonOK;
    }
}