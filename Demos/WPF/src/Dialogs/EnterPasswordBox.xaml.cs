using System.Windows;
using System.Windows.Input;

namespace GroupDocs.Viewer.WPF.Dialogs
{
    /// <summary>
    /// Interaction logic for EnterPasswordBox.xaml
    /// </summary>
    public partial class EnterPasswordBox : Window
    {
        /// <summary>
        /// Form result value (entered password in text box).
        /// </summary>
        public string ResultValue { get; set; }

        public EnterPasswordBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// On key down handler for text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                OkBtn_Click(null, null);
            }
        }

        /// <summary>
        /// Click on OK button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Text != null && string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                MessageBox.Show("Please enter password!");
            }
            else
            {
                DialogResult = true;
                ResultValue = txtPassword.Text;
                this.Close();
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // We should reset the current value when the window is shown
            ResultValue = string.Empty;
        }
    }
}
