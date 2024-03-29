using System.Windows.Forms;
using TaskBarRenamer.Languages;

namespace TaskBarRenamer
{
    #region Enums

    public enum SettingCategory
    {
        Refresh = 0,
        Update = 1,
    }

    #endregion

    public partial class FormSettings : Form
    {
        #region Methods

        public FormSettings(SettingCategory category)
        {
            InitializeComponent();

            if ((int)category < tabControlSettings.TabCount)
                tabControlSettings.SelectedIndex = (int)category;

            checkBoxAutoRefresh.Checked = Properties.Settings.Default.AutoRefresh;
            numericUpDownRefreshEvery.SetValue(Properties.Settings.Default.RefreshEvery);
            checkBoxForegroundOnly.Checked = Properties.Settings.Default.ForegroundOnly;
            numericUpDownForceNamesEvery.SetValue(Properties.Settings.Default.ForceNamesEvery);
        }

        #endregion

        #region Click/Key-Events

        private void OK_Click(object sender, System.EventArgs e)
        {
            Properties.Settings.Default.AutoRefresh = checkBoxAutoRefresh.Checked;
            Properties.Settings.Default.RefreshEvery = (int)numericUpDownRefreshEvery.Value;
            Properties.Settings.Default.ForegroundOnly = checkBoxForegroundOnly.Checked;
            Properties.Settings.Default.ForceNamesEvery = (int)numericUpDownForceNamesEvery.Value;
        }

        #endregion

        #region Events

        private void CheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            bool status = checkBoxAutoRefresh.Checked;
            numericUpDownRefreshEvery.Enabled = status;
            checkBoxForegroundOnly.Enabled = status;
        }
        private void ForegroundOnly_CheckedChanged(object sender, System.EventArgs e)
        {
            if (!checkBoxForegroundOnly.Checked)
                return;

            if (MessageBox.Show(Language.ForegroundOnly, string.Empty, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3) == DialogResult.Yes)
                checkBoxForegroundOnly.Checked = true;
            else
                checkBoxForegroundOnly.Checked = false;
        }

        #endregion
    }
}