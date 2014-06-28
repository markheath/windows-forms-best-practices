namespace PluralsightWinFormsDemoApp
{
    partial class PodcastView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelEpisodeCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.Gray;
            this.labelTitle.Location = new System.Drawing.Point(4, 4);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(165, 25);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "{{Podcast Title}}";
            // 
            // labelEpisodeCount
            // 
            this.labelEpisodeCount.AutoSize = true;
            this.labelEpisodeCount.Location = new System.Drawing.Point(9, 44);
            this.labelEpisodeCount.Name = "labelEpisodeCount";
            this.labelEpisodeCount.Size = new System.Drawing.Size(92, 13);
            this.labelEpisodeCount.TabIndex = 1;
            this.labelEpisodeCount.Text = "{{Episode Count}}";
            // 
            // PodcastView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelEpisodeCount);
            this.Controls.Add(this.labelTitle);
            this.Name = "PodcastView";
            this.Size = new System.Drawing.Size(203, 191);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelEpisodeCount;
    }
}
