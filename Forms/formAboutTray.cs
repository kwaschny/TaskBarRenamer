using System.Windows.Forms;

namespace TaskBarRenamer
{
    public partial class formAboutTray : Form
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

        // Constructor
        public formAboutTray()
        {
            InitializeComponent();
        }

        #endregion
    }
}