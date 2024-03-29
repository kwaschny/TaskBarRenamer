using System.Windows.Forms;
using TaskBarRenamer.Languages;

namespace TaskBarRenamer
{
    public partial class FormAutomatic : Form
    {
        #region Fields

        public string RenameThis
        {
            get;
            private set;
        }
        public string ToThis
        {
            get;
            private set;
        }
        public bool ForceName
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        public FormAutomatic(string renameThis, string toThis, bool forceName)
        {
            ForceName = false;

            InitializeComponent();

            textBoxFrom.Text = renameThis;
            textBoxTo.Text = toThis;
            checkBoxForceName.Checked = forceName;
        }
        public FormAutomatic(bool forceName)
        {
            ForceName = false;

            InitializeComponent();

            checkBoxForceName.Checked = forceName;
        }

        #endregion

        #region Click/Key-Events

        private void OK_Click(object sender, System.EventArgs e)
        {
            RenameThis = textBoxFrom.Text;
            ToThis = textBoxTo.Text;
            ForceName = checkBoxForceName.Checked;
        }

        #endregion

        #region Events

        private void TextBox_TextChanged(object sender, System.EventArgs e)
        {
            int errors = 0;

            if (textBoxFrom.Text.Contains(";"))
            {
                errors += 1;
                errorProvider.SetError(textBoxFrom, Language.NotContainSemicolon);
            }
            else
                errorProvider.SetError(textBoxFrom, string.Empty);

            if (textBoxTo.Text.Contains(";"))
            {
                errors += 1;
                errorProvider.SetError(textBoxTo, Language.NotContainSemicolon);
            }
            else
                errorProvider.SetError(textBoxTo, string.Empty);

            if (textBoxFrom.Text.Length <= 0)
                errors += 1;

            buttonOK.Enabled = (errors == 0);
        }

        #endregion
    }
}