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

        public FormAutomatic(AutomaticEntry entry)
        {
            ForceName = false;

            InitializeComponent();

            textBoxFrom.Text = entry.FromName;
            switch (entry.Type)
            {
                case RenameType.Exact:
                    radioButtonExact.Checked = true;
                    break;
                case RenameType.Wildcard:
                    radioButtonWildcard.Checked = true;
                    break;
                case RenameType.RegExp:
                    radioButtonRegExp.Checked = true;
                    break;
            }

            textBoxTo.Text = entry.ToName;
            checkBoxForceName.Checked = entry.ForceName;
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
            string from = textBoxFrom.Text;
            if (radioButtonWildcard.Checked)
            {
                from = ("wc$" + from);
            }
            else if (radioButtonRegExp.Checked)
            {
                from = ("re$" + from);
            }

            RenameThis = from;
            ToThis = textBoxTo.Text;
            ForceName = checkBoxForceName.Checked;
        }

        #endregion

        #region Events

        private void TextBox_TextChanged(object sender, System.EventArgs e)
        {
            bool hasError = false;

            if (textBoxFrom.Text.Contains(";"))
            {
                hasError = true;
                errorProvider.SetError(textBoxFrom, Language.NotContainSemicolon);
            }
            else
                errorProvider.SetError(textBoxFrom, string.Empty);

            if (textBoxTo.Text.Contains(";"))
            {
                hasError = true;
                errorProvider.SetError(textBoxTo, Language.NotContainSemicolon);
            }
            else
                errorProvider.SetError(textBoxTo, string.Empty);

            if (textBoxFrom.Text.Length == 0)
            {
                hasError = true;
            }

            if (!hasError)
            {
                if (radioButtonWildcard.Checked)
                {
                    var wc = AutomaticEntry.BuildRegex(textBoxFrom.Text, RenameType.Wildcard);
                    if (wc == null)
                    {
                        hasError = true;
                        errorProvider.SetError(textBoxFrom, Language.InvalidWildcard);
                    }
                    else
                    {
                        errorProvider.SetError(textBoxFrom, string.Empty);
                    }
                }
                else if (radioButtonRegExp.Checked)
                {
                    var re = AutomaticEntry.BuildRegex(textBoxFrom.Text, RenameType.RegExp);
                    if (re == null)
                    {
                        hasError = true;
                        errorProvider.SetError(textBoxFrom, Language.InvalidRegExp);
                    }
                    else
                    {
                        errorProvider.SetError(textBoxFrom, string.Empty);
                    }
                }
            }

            buttonOK.Enabled = !hasError;
        }

        private void radioButtonExact_CheckedChanged(object sender, System.EventArgs e)
        {
            labelMatch.Text = string.Empty;
        }

        private void radioButtonWildcard_CheckedChanged(object sender, System.EventArgs e)
        {
            labelMatch.Text = Language.WildcardHint;
        }

        private void radioButtonRegExp_CheckedChanged(object sender, System.EventArgs e)
        {
            labelMatch.Text = Language.RegExpHint;
        }

        #endregion

    }
}