namespace TaskBarRenamer
{
    partial class formVersion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formVersion));
            this.buttonClose = new System.Windows.Forms.Button();
            this.pictureBoxK = new System.Windows.Forms.PictureBox();
            this.labelProduct = new System.Windows.Forms.Label();
            this.labelCompany = new System.Windows.Forms.Label();
            this.labelBuild = new System.Windows.Forms.Label();
            this.labelWebsite = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxK)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            resources.ApplyResources(this.buttonClose, "buttonClose");
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // pictureBoxK
            // 
            resources.ApplyResources(this.pictureBoxK, "pictureBoxK");
            this.pictureBoxK.Name = "pictureBoxK";
            this.pictureBoxK.TabStop = false;
            // 
            // labelProduct
            // 
            resources.ApplyResources(this.labelProduct, "labelProduct");
            this.labelProduct.Name = "labelProduct";
            // 
            // labelCompany
            // 
            resources.ApplyResources(this.labelCompany, "labelCompany");
            this.labelCompany.Name = "labelCompany";
            // 
            // labelBuild
            // 
            this.labelBuild.ForeColor = System.Drawing.SystemColors.GrayText;
            resources.ApplyResources(this.labelBuild, "labelBuild");
            this.labelBuild.Name = "labelBuild";
            // 
            // labelWebsite
            // 
            this.labelWebsite.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.labelWebsite, "labelWebsite");
            this.labelWebsite.ForeColor = System.Drawing.Color.Blue;
            this.labelWebsite.Name = "labelWebsite";
            this.labelWebsite.TabStop = true;
            this.labelWebsite.Click += new System.EventHandler(this.Website_Clicked);
            // 
            // formVersion
            // 
            this.AcceptButton = this.buttonClose;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.Controls.Add(this.labelWebsite);
            this.Controls.Add(this.labelBuild);
            this.Controls.Add(this.labelCompany);
            this.Controls.Add(this.labelProduct);
            this.Controls.Add(this.pictureBoxK);
            this.Controls.Add(this.buttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formVersion";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxK)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.PictureBox pictureBoxK;
        private System.Windows.Forms.Label labelProduct;
        private System.Windows.Forms.Label labelCompany;
        private System.Windows.Forms.Label labelBuild;
        private System.Windows.Forms.Label labelWebsite;
    }
}