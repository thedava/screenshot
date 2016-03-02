namespace Screenshot
{
    partial class Save
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblSaving = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.cbxClose = new System.Windows.Forms.CheckBox();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // lblSaving
            // 
            this.lblSaving.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSaving.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaving.Location = new System.Drawing.Point(0, 0);
            this.lblSaving.Name = "lblSaving";
            this.lblSaving.Size = new System.Drawing.Size(284, 54);
            this.lblSaving.TabIndex = 0;
            this.lblSaving.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1100;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // cbxClose
            // 
            this.cbxClose.AutoSize = true;
            this.cbxClose.Checked = true;
            this.cbxClose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxClose.Location = new System.Drawing.Point(63, 57);
            this.cbxClose.Name = "cbxClose";
            this.cbxClose.Size = new System.Drawing.Size(141, 17);
            this.cbxClose.TabIndex = 1;
            this.cbxClose.Text = "Close after saving image";
            this.cbxClose.UseVisualStyleBackColor = true;
            // 
            // worker
            // 
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            // 
            // Save
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(284, 86);
            this.Controls.Add(this.cbxClose);
            this.Controls.Add(this.lblSaving);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Save";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Screenshot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Save_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSaving;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.CheckBox cbxClose;
        private System.ComponentModel.BackgroundWorker worker;
    }
}

