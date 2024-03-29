using System;
using System.Windows.Forms;

namespace TaskBarRenamer
{
    public partial class FormVersion : Form
    {
        #region Fields

        private readonly string website;

        #endregion

        #region Methods

        // Constructor
        public FormVersion(string buildVersion, string website)
        {
            this.website = website;

            InitializeComponent();

            labelProduct.Text = Application.ProductName + " " + Application.ProductVersion;
            labelBuild.Text = buildVersion;

            labelCompany.Text = Application.CompanyName;
            labelWebsite.Text = website;
        }

        #endregion

        #region Click/Key-Events

        private void Website_Clicked(object sender, EventArgs e)
        {
            Program.OpenWebsite(website);
        }

        #endregion
    }
}