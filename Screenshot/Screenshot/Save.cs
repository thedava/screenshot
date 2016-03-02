using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Screenshot
{
    public partial class Save : Form
    {
        const string Folder = "Screenshots";
        const string FileName = "Screenshot";
        const string DateFormat = "yyyyMMdd_HHmmss";
        const string Extension = ".png";

        private bool Done { get; set; }

        public Save()
        {
            InitializeComponent();
        }

        private void Save_Load(object sender, System.EventArgs e)
        {
            if (!Clipboard.ContainsImage())
            {
                this.lblSaving.Text = "Aborting...";
                MessageBox.Show("Clipboard doesn't contain an image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Done = true;
                return;
            }

            var folder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + Path.DirectorySeparatorChar + Folder;
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            var image = Clipboard.GetImage();
            try
            {
                image.Save(folder + Path.DirectorySeparatorChar + FileName + "_" + DateTime.Now.ToString(DateFormat) + Extension);
                Process.Start(folder);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Done = true;
            }
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.Done)
            {
                this.timer.Stop();
                this.Close();
            }
        }
    }
}
