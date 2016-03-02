using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Screenshot
{
    public partial class Save : Form
    {
        private const string Folder = "Screenshots";
        private const string FileName = "Screenshot";
        private const string DateFormat = "yyyyMMdd_HHmmss";
        private const string Extension = ".png";

        private const string TextWaiting = "Waiting for images in the clipboard...";
        private const string TextSaving = "Saving Screenshot...";
        private const string TextAborting = "Aborting...";

        private bool Done { get; set; }
        private Image ClipboardImage { get; set; }
        private Image LastImage { get; set; }

        public Save()
        {
            InitializeComponent();

            this.lblSaving.Text = TextWaiting;

            var folder = GetFolderPath();
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }

        private static string GetFolderPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + Path.DirectorySeparatorChar + Folder;
        }

        private void Save_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process.Start(GetFolderPath());
        }

        private static string GetBase64(Image image)
        {
            var stream = new MemoryStream();
            image.Save(stream, ImageFormat.Png);
            return Convert.ToBase64String(stream.ToArray());
        }
        
        private bool CheckImageSame(Image image)
        {
            // Check if there is a last image
            if (image == null || LastImage == null)
                return false;

            // Compare sizes
            if (image.Width != LastImage.Width || image.Height != LastImage.Height)
                return false;

            // Compare base64
            if (GetBase64(image) != GetBase64(LastImage))
                return false;
            
            return true;
        }

        private void worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (CheckImageSame(ClipboardImage))
                return;

            this.Invoke((MethodInvoker) delegate
            {
                this.lblSaving.Text = TextSaving;

                var folder = GetFolderPath();
                LastImage = Clipboard.GetImage();

                try
                {
                    LastImage.Save(folder + Path.DirectorySeparatorChar + FileName + "_" + DateTime.Now.ToString(DateFormat) + Extension);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cbxClose.Checked)
                    {
                        this.Done = true;
                    }
                    else
                    {
                    }
                }
            });
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.Done)
            {
                this.lblSaving.Text = TextAborting;
                this.timer.Stop();
                this.Close();
                return;
            }
            this.lblSaving.Text = TextWaiting;

            if (!worker.IsBusy && Clipboard.ContainsImage() && Clipboard.GetImage() != null)
            {
                ClipboardImage = Clipboard.GetImage();
                worker.RunWorkerAsync();
            }
        }
    }
}
