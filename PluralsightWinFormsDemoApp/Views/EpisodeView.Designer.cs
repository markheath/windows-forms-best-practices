namespace PluralsightWinFormsDemoApp.Views
{
    partial class EpisodeView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EpisodeView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.webBrowserDescription = new System.Windows.Forms.WebBrowser();
            this.numericUpDownRating = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNotes = new System.Windows.Forms.TextBox();
            this.textBoxTags = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelEpisodeTitle = new System.Windows.Forms.Label();
            this.labelPublicationDate = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.waveformViewer1 = new PluralsightWinFormsDemoApp.Views.WaveformViewer();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRating)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.webBrowserDescription);
            this.panel1.Controls.Add(this.waveformViewer1);
            this.panel1.Controls.Add(this.numericUpDownRating);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxNotes);
            this.panel1.Controls.Add(this.textBoxTags);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // webBrowserDescription
            // 
            resources.ApplyResources(this.webBrowserDescription, "webBrowserDescription");
            this.webBrowserDescription.Name = "webBrowserDescription";
            this.webBrowserDescription.ScriptErrorsSuppressed = true;
            // 
            // numericUpDownRating
            // 
            resources.ApplyResources(this.numericUpDownRating, "numericUpDownRating");
            this.numericUpDownRating.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownRating.Name = "numericUpDownRating";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // textBoxNotes
            // 
            resources.ApplyResources(this.textBoxNotes, "textBoxNotes");
            this.textBoxNotes.Name = "textBoxNotes";
            // 
            // textBoxTags
            // 
            resources.ApplyResources(this.textBoxTags, "textBoxTags");
            this.textBoxTags.Name = "textBoxTags";
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.labelEpisodeTitle);
            this.flowLayoutPanel1.Controls.Add(this.labelPublicationDate);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // labelEpisodeTitle
            // 
            resources.ApplyResources(this.labelEpisodeTitle, "labelEpisodeTitle");
            this.labelEpisodeTitle.ForeColor = System.Drawing.Color.DarkGray;
            this.labelEpisodeTitle.Name = "labelEpisodeTitle";
            // 
            // labelPublicationDate
            // 
            resources.ApplyResources(this.labelPublicationDate, "labelPublicationDate");
            this.labelPublicationDate.Name = "labelPublicationDate";
            // 
            // waveformViewer1
            // 
            resources.ApplyResources(this.waveformViewer1, "waveformViewer1");
            this.waveformViewer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.waveformViewer1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.waveformViewer1.Name = "waveformViewer1";
            this.waveformViewer1.PositionInSeconds = 0;
            // 
            // EpisodeView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "EpisodeView";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRating)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numericUpDownRating;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNotes;
        private System.Windows.Forms.TextBox textBoxTags;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labelEpisodeTitle;
        private System.Windows.Forms.Label labelPublicationDate;
        private System.Windows.Forms.ToolTip toolTip1;
        private Views.WaveformViewer waveformViewer1;
        private System.Windows.Forms.WebBrowser webBrowserDescription;

    }
}
