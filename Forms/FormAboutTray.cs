using System.Windows.Forms;

namespace TaskBarRenamer
{
    public partial class FormAboutTray : Form
    {
        #region Fields

        public bool DoNotShowAgain
        {
            get
            {
                return checkBoxDoNotShowAgain.Checked;
            }
        }

        #endregion

        #region Methods

        public FormAboutTray()
        {
            InitializeComponent();
        }

        #endregion
    }
}