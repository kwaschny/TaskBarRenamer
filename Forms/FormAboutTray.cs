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

        // Constructor
        public FormAboutTray()
        {
            InitializeComponent();
        }

        #endregion
    }
}