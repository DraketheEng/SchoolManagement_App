namespace schoolManagement
{
    partial class FrmAnnouncement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnnouncement));
            this.dtGridAnnouncement = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridAnnouncement)).BeginInit();
            this.SuspendLayout();
            // 
            // dtGridAnnouncement
            // 
            this.dtGridAnnouncement.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGridAnnouncement.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtGridAnnouncement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridAnnouncement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGridAnnouncement.Location = new System.Drawing.Point(0, 0);
            this.dtGridAnnouncement.Name = "dtGridAnnouncement";
            this.dtGridAnnouncement.RowHeadersWidth = 51;
            this.dtGridAnnouncement.RowTemplate.Height = 24;
            this.dtGridAnnouncement.Size = new System.Drawing.Size(803, 418);
            this.dtGridAnnouncement.TabIndex = 0;
            // 
            // FrmAnnouncement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.PaleVioletRed;
            this.ClientSize = new System.Drawing.Size(803, 418);
            this.Controls.Add(this.dtGridAnnouncement);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmAnnouncement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Duyurular";
            this.Load += new System.EventHandler(this.FrmAnnouncement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridAnnouncement)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGridAnnouncement;
    }
}