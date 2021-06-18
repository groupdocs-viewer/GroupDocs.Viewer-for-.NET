using GroupDocs.Viewer.Exceptions;
using GroupDocs.Viewer.Options;
using GroupsDocs.Viewer.Forms.UI;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace GroupDocs.Viewer.Forms.UI
{
    /// <summary>
    /// Main application form.
    /// </summary>
    public partial class MainForm : Form
    {
        private string CurrentFilePath { get; set; }
        private Results.ViewInfo ViewInfo { get; set; }

        private MemoryPageStreamFactory MemoryPageStreamFactory { get; set; }

        private GroupDocs.Viewer.Viewer Viewer { get; set; }

        private int CurrentPage { get; set; } = 1;

        const string GeneralTitle = "Viewer for .NET  Windows Forms";

        public MainForm()
        {
            InitializeComponent();
            SetLicense();
            UpdateControlsVisibility();

            // Set title.
            Text = GeneralTitle;
            MemoryPageStreamFactory = new MemoryPageStreamFactory();
        }

        /// <summary>
        /// Update controls visibility.
        /// </summary>
        private void UpdateControlsVisibility()
        {
            // If viewinfo != null (document loaded) - enable all page buttons.
            firstPageBtn.Enabled = lastPageBtn.Enabled = prevPageBtn.Enabled = nextPageBtn.Enabled = (ViewInfo != null);

            // If viewinfo != null (document loaded) and document with 1 or more pages - all buttons should be visible.
            firstPageBtn.Visible = lastPageBtn.Visible = prevPageBtn.Visible = nextPageBtn.Visible = (ViewInfo != null && ViewInfo.Pages.Count > 1);

            if (ViewInfo != null)
            {
                firstPageBtn.Enabled = lastPageBtn.Enabled = (ViewInfo.Pages.Count > 0);

                if (CurrentPage <= 1)
                {
                    firstPageBtn.Enabled = false;
                }

                if (CurrentPage > 1)
                {
                    firstPageBtn.Enabled = true;
                }

                lastPageBtn.Enabled = (ViewInfo.Pages.Count != CurrentPage) && (ViewInfo.Pages.Count > 0);

                prevPageBtn.Enabled = (CurrentPage != 1);
                nextPageBtn.Enabled = (CurrentPage != ViewInfo.Pages.Count);
            }
        }

        /// <summary>
        /// Set GroupDocs.Viewer license.
        /// </summary>
        private void SetLicense()
        {
            string fileName = "GroupDocs.Viewer.lic";

            if (File.Exists(fileName))
            {
                GroupDocs.Viewer.License license = new License();
                license.SetLicense(fileName);
                SetLabelText(licenseStatusLabel, "Licensed");
            }
        }

        /// <summary>
        /// Open file button click event.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event arguments.</param>
        private void openFileBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    CurrentFilePath = openFileDialog.FileName;
                    openFileBtn.Enabled = false;
                }
            }

            // If file set - process it.
            if (!string.IsNullOrEmpty(CurrentFilePath))
            {

                if (Viewer != null)
                {
                    Viewer.Dispose();
                    ViewInfo = null;
                    CurrentPage = 1;
                    DisplayViewInfo();
                }

                new Thread(() =>
                {
                    try
                    {
                        SetPagesInfoText($"Loading {Path.GetFileName(CurrentFilePath)}");

                        Viewer = new GroupDocs.Viewer.Viewer(CurrentFilePath);
                        GroupDocs.Viewer.Options.ViewInfoOptions viewInfo = GroupDocs.Viewer.Options.ViewInfoOptions.ForHtmlView();

                        try
                        {
                            ViewInfo = Viewer.GetViewInfo(viewInfo);
                        }
                        catch (PasswordRequiredException)
                        {
                            // Ask for password
                            EnterPasswordBox enterPasswordbox = new EnterPasswordBox();
                            DialogResult res = enterPasswordbox.ShowDialog();

                            if (res == DialogResult.OK)
                            {
                                Viewer.Dispose();
                                ViewInfo = null;

                                LoadOptions loadOptions = new LoadOptions();
                                loadOptions.Password = enterPasswordbox.ResultValue;

                                Viewer = new GroupDocs.Viewer.Viewer(CurrentFilePath, loadOptions);
                                ViewInfo = Viewer.GetViewInfo(viewInfo);
                            }
                            else
                            {
                                ViewInfo = null;
                                CurrentFilePath = null;
                                webBrowerMain.DocumentText = string.Empty;
                                DisplayViewInfo();

                                throw;
                            }
                        }

                        ViewFile(Viewer);
                        openFileBtn.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error occured! {ex.Message}");
                        ViewInfo = null;
                        DisplayViewInfo();
                        openFileBtn.Enabled = true;
                    }
                }).Start();
            }
        }

        /// <summary>
        /// View file.
        /// </summary>
        /// <param name="viewer">Viewer object.</param>
        /// <param name="page">Page number to view.</param>
        private void ViewFile(Viewer viewer, int page = 1)
        {
            if (ViewInfo != null)
            {
                HtmlViewOptions htmlViewOptions = HtmlViewOptions.ForEmbeddedResources(MemoryPageStreamFactory);
                viewer.View(htmlViewOptions, page);

                MemoryPageStreamFactory.Stream.Position = 0;
                webBrowerMain.DocumentStream = MemoryPageStreamFactory.Stream;
            }

            UpdateControlsVisibility();
            DisplayViewInfo();
        }

        /// <summary>
        /// Display current file view info (current page, total pages, file name).
        /// </summary>
        private void DisplayViewInfo()
        {
            if (ViewInfo != null)
            {
                SetPagesInfoText($"{CurrentPage}/{ViewInfo.Pages.Count}");
                SetFormTitle(Path.GetFileName(CurrentFilePath));
            }
            else
            {
                SetPagesInfoText(" ");
                SetFormTitle("No document loaded.");
            }
        }

        /// <summary>
        /// Set form title.
        /// </summary>
        /// <param name="text"></param>
        private void SetFormTitle(string text)
        {
            this.Text = GeneralTitle + " - " + text;
        }

        /// <summary>
        /// Set pages info text.
        /// </summary>
        /// <param name="text"></param>
        private void SetPagesInfoText(string text)
        {
            pagesStatusLabel.Text = text;
        }

        /// <summary>
        /// Set tool strip label text.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event arguments.</param>
        private void SetLabelText(ToolStripLabel control, string text)
        {
            control.Text = text;

        }

        /// <summary>
        /// First page button click event.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event arguments.</param>
        private void FirstPageBtn_Click(object sender, EventArgs e)
        {
            CurrentPage = 1;
            ViewFile(Viewer, CurrentPage);
        }

        /// <summary>
        /// Previous page button click event.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event arguments.</param>
        private void PrevPageBtn_Click(object sender, EventArgs e)
        {
            if (CurrentPage != 1)
            {
                CurrentPage = CurrentPage - 1;
                ViewFile(Viewer, CurrentPage);
            }
        }

        /// <summary>
        /// Next page button click event.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event arguments.</param>
        private void NextPageBtn_Click(object sender, EventArgs e)
        {
            if (CurrentPage != ViewInfo.Pages.Count)
            {
                CurrentPage = CurrentPage + 1;
                ViewFile(Viewer, CurrentPage);
            }
        }

        /// <summary>
        /// Last page button click event.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event arguments.</param>
        private void LastPageBtn_Click(object sender, EventArgs e)
        {
            CurrentPage = ViewInfo.Pages.Count;
            ViewFile(Viewer, CurrentPage);
        }

        /// <summary>
        /// Form closing event.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Form closing event arguments.</param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Dispose viewer object if not null
            if (Viewer != null)
            {
                Viewer.Dispose();
            }
        }
    }
}
