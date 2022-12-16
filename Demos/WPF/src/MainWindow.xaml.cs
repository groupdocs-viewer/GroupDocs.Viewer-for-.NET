using GroupDocs.Viewer;
using GroupDocs.Viewer.Exceptions;
using GroupDocs.Viewer.Options;
using Microsoft.Win32;
using GroupDocs.Viewer.WPF.Dialogs;
using GroupDocs.Viewer.WPF.Utils;
using System;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Media.Imaging;

namespace GroupDocs.Viewer.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetWindowTitle(string.Empty);
            SetLicense();
            UpdateControlsVisibility();
            WorkMemoryPageStreamFactory = new MemoryPageStreamFactory();
        }

        private string CurrentFilePath { get; set; }
        private GroupDocs.Viewer.Results.ViewInfo ViewInfo { get; set; }

        private MemoryPageStreamFactory WorkMemoryPageStreamFactory { get; set; }

        private GroupDocs.Viewer.Viewer Viewer { get; set; }

        private int CurrentPage { get; set; } = 1;

        const string GeneralTitle = "GroupDocs.Viewer for WPF";

        /// <summary>
        /// Update controls visibility.
        /// </summary>
        private void UpdateControlsVisibility()
        {
            Dispatcher.Invoke(() =>
            {
                // If viewinfo != null (document loaded) - enable all page buttons.
                firstPageBtn.IsEnabled = lastPageBtn.IsEnabled = prevPageBtn.IsEnabled = nextPageBtn.IsEnabled = (ViewInfo != null);

                // If viewinfo != null (document loaded) and document with 1 or more pages - all buttons should be visible.
                firstPageBtn.Visibility = lastPageBtn.Visibility = prevPageBtn.Visibility = nextPageBtn.Visibility = (ViewInfo != null && ViewInfo.Pages.Count > 1) ? Visibility.Visible : Visibility.Hidden;
            });

            if (ViewInfo != null)
            {
                Dispatcher.Invoke(() =>
                {
                    firstPageBtn.IsEnabled = lastPageBtn.IsEnabled = (ViewInfo.Pages.Count > 0);

                    if (CurrentPage <= 1)
                    {
                        firstPageBtn.IsEnabled = false;
                    }

                    if (CurrentPage > 1)
                    {
                        firstPageBtn.IsEnabled = true;
                    }

                    lastPageBtn.IsEnabled = (ViewInfo.Pages.Count != CurrentPage) && (ViewInfo.Pages.Count > 0);

                    prevPageBtn.IsEnabled = (CurrentPage != 1);
                    nextPageBtn.IsEnabled = (CurrentPage != ViewInfo.Pages.Count);
                });
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
                SetLabelText(lblStatus, "Licensed");
            }
        }

        /// <summary>
        /// Open file button click event.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event arguments.</param>
        private void openFileBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";

            if (openFileDialog.ShowDialog() == true)
            {
                //Get the path of specified file
                CurrentFilePath = openFileDialog.FileName;
                openFileBtn.IsEnabled = false;
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
                        ViewInfo = null;
                        SetPagesInfoText($"Loading {System.IO.Path.GetFileName(CurrentFilePath)}");
                        UpdateControlsVisibility();

                        Viewer = new GroupDocs.Viewer.Viewer(CurrentFilePath);
                        GroupDocs.Viewer.Options.ViewInfoOptions viewInfo = GroupDocs.Viewer.Options.ViewInfoOptions.ForHtmlView();

                        try
                        {
                            ViewInfo = Viewer.GetViewInfo(viewInfo);
                        }
                        catch (PasswordRequiredException)
                        {
                            bool? res = null;
                            string password = string.Empty;

                            Dispatcher.Invoke(() =>
                            {
                                // Ask for password
                                EnterPasswordBox enterPasswordbox = new EnterPasswordBox();
                                res = enterPasswordbox.ShowDialog();
                                password = enterPasswordbox.ResultValue;
                            });

                            if (res == true)
                            {
                                Viewer.Dispose();
                                ViewInfo = null;

                                LoadOptions loadOptions = new LoadOptions();
                                loadOptions.Password = password;

                                Viewer = new GroupDocs.Viewer.Viewer(CurrentFilePath, loadOptions);
                                ViewInfo = Viewer.GetViewInfo(viewInfo);
                            }
                            else
                            {
                                Dispatcher.Invoke(() =>
                                {
                                    ViewInfo = null;
                                    CurrentFilePath = null;
                                    imageMain.Source = null;
                                    DisplayViewInfo();
                                });

                                throw;
                            }
                        }

                        ViewFile(Viewer);
                        Dispatcher.Invoke(() =>
                        {
                            openFileBtn.IsEnabled = true;
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error occured! {ex.Message}");
                        ViewInfo = null;
                        DisplayViewInfo();
                        Dispatcher.Invoke(() =>
                        {
                            openFileBtn.IsEnabled = true;
                        });
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
                PngViewOptions htmlViewOptions = new PngViewOptions(WorkMemoryPageStreamFactory);
                viewer.View(htmlViewOptions, page);

                Dispatcher.Invoke(() =>
                {
                    WorkMemoryPageStreamFactory.Stream.Position = 0;
                    imageMain.Source = BitmapFrame.Create(WorkMemoryPageStreamFactory.Stream,
                        BitmapCreateOptions.None,
                        BitmapCacheOption.OnLoad);
                });
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
                SetWindowTitle(Path.GetFileName(CurrentFilePath));
            }
            else
            {
                SetPagesInfoText(" ");
                SetWindowTitle("No document loaded.");
            }
        }

        /// <summary>
        /// Set form title.
        /// </summary>
        /// <param name="text"></param>
        private void SetWindowTitle(string text)
        {
            Dispatcher.Invoke(() =>
            {
                Title = (GeneralTitle + " - " + (string.IsNullOrEmpty(text) ? "No document loaded" : text));
            });
        }

        /// <summary>
        /// Set pages info text.
        /// </summary>
        /// <param name="text"></param>
        private void SetPagesInfoText(string text)
        {
            Dispatcher.Invoke(() =>
            {
                lblPagesStatus.Content = text;
            });
        }

        /// <summary>
        /// Set tool strip label text.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event arguments.</param>
        private void SetLabelText(System.Windows.Controls.Label control, string text)
        {
            Dispatcher.Invoke(() =>
            {
                control.Content = text;
            });
        }

        /// <summary>
        /// First page button click event.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event arguments.</param>
        private void FirstPageBtn_Click(object sender, RoutedEventArgs e)
        {
            CurrentPage = 1;
            ViewFile(Viewer, CurrentPage);
        }

        /// <summary>
        /// Previous page button click event.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event arguments.</param>
        private void PrevPageBtn_Click(object sender, RoutedEventArgs e)
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
        private void NextPageBtn_Click(object sender, RoutedEventArgs e)
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
        private void LastPageBtn_Click(object sender, RoutedEventArgs e)
        {
            CurrentPage = ViewInfo.Pages.Count;
            ViewFile(Viewer, CurrentPage);
        }

        /// <summary>
        /// Window closing event.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Closing event arguments.</param>
        private void MainWindow_Closing(object sender, RoutedEventArgs e)
        {
            // Dispose viewer object if not null
            if (Viewer != null)
            {
                Viewer.Dispose();
            }
        }
    }
}
