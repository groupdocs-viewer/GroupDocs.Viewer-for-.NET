using System;
using System.Windows.Forms;

namespace GroupsDocs.Viewer.Forms.UI
{
    /// <summary>
    /// Enter password form with text box.
    /// </summary>
    public partial class EnterPasswordBox : Form
    {
        public EnterPasswordBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form result value (entered password in text box).
        /// </summary>
        public string ResultValue { get; set; }

        /// <summary>
        /// Ok button click event.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event arguments.</param>
        private void OkBtn_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != null && string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                MessageBox.Show("Please enter password!");
            }
            else
            {
                DialogResult = DialogResult.OK;
                ResultValue = txtPassword.Text;
                this.Close();
            }
        }

        /// <summary>
        /// Cancel button click event.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event arguments.</param>
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Form shown event handler.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event arguments.</param>
        private void EnterPasswordBox_Shown(object sender, EventArgs e)
        {
            // We should reset the current value when the form is shown
            ResultValue = string.Empty;
        }
    }
}
