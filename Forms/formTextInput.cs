﻿using System.Windows.Forms;

namespace TaskBarRenamer
{
    public partial class formTextInput : Form
    {
        #region Fields

        public string InputText
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

        // Constructor
        public formTextInput(string description, string defaultText, bool forceName)
        {
            ForceName = false;

            InitializeComponent();

            labelDescription.Text = description;
            textBoxInput.Text = defaultText;
            checkBoxForceName.Checked = forceName;
        }

        #endregion

        #region Click/Key-Events

        private void OK_Click(object sender, System.EventArgs e)
        {
            InputText = textBoxInput.Text;
            ForceName = checkBoxForceName.Checked;
        }

        #endregion
    }
}