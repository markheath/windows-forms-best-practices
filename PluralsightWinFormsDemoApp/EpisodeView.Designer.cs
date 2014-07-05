namespace PluralsightWinFormsDemoApp
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
            this.checkBoxIsFavourite = new System.Windows.Forms.CheckBox();
            this.numericUpDownRating = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNotes = new System.Windows.Forms.TextBox();
            this.textBoxTags = new System.Windows.Forms.TextBox();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelEpisodeTitle = new System.Windows.Forms.Label();
            this.labelPublicationDate = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRating)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.checkBoxIsFavourite);
            this.panel1.Controls.Add(this.numericUpDownRating);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxNotes);
            this.panel1.Controls.Add(this.textBoxTags);
            this.panel1.Controls.Add(this.buttonPlay);
            this.panel1.Name = "panel1";
            this.toolTip1.SetToolTip(this.panel1, resources.GetString("panel1.ToolTip"));
            // 
            // checkBoxIsFavourite
            // 
            resources.ApplyResources(this.checkBoxIsFavourite, "checkBoxIsFavourite");
            this.checkBoxIsFavourite.Name = "checkBoxIsFavourite";
            this.toolTip1.SetToolTip(this.checkBoxIsFavourite, resources.GetString("checkBoxIsFavourite.ToolTip"));
            this.checkBoxIsFavourite.UseVisualStyleBackColor = true;
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
            this.toolTip1.SetToolTip(this.numericUpDownRating, resources.GetString("numericUpDownRating.ToolTip"));
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.toolTip1.SetToolTip(this.label2, resources.GetString("label2.ToolTip"));
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            this.toolTip1.SetToolTip(this.label3, resources.GetString("label3.ToolTip"));
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.toolTip1.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            // 
            // textBoxNotes
            // 
            resources.ApplyResources(this.textBoxNotes, "textBoxNotes");
            this.textBoxNotes.Name = "textBoxNotes";
            this.toolTip1.SetToolTip(this.textBoxNotes, resources.GetString("textBoxNotes.ToolTip"));
            // 
            // textBoxTags
            // 
            resources.ApplyResources(this.textBoxTags, "textBoxTags");
            this.textBoxTags.Name = "textBoxTags";
            this.toolTip1.SetToolTip(this.textBoxTags, resources.GetString("textBoxTags.ToolTip"));
            // 
            // buttonPlay
            // 
            resources.ApplyResources(this.buttonPlay, "buttonPlay");
            this.buttonPlay.Name = "buttonPlay";
            this.toolTip1.SetToolTip(this.buttonPlay, resources.GetString("buttonPlay.ToolTip"));
            this.buttonPlay.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.labelEpisodeTitle);
            this.flowLayoutPanel1.Controls.Add(this.labelPublicationDate);
            this.flowLayoutPanel1.Controls.Add(this.labelDescription);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.toolTip1.SetToolTip(this.flowLayoutPanel1, resources.GetString("flowLayoutPanel1.ToolTip"));
            // 
            // labelEpisodeTitle
            // 
            resources.ApplyResources(this.labelEpisodeTitle, "labelEpisodeTitle");
            this.labelEpisodeTitle.ForeColor = System.Drawing.Color.DarkGray;
            this.labelEpisodeTitle.Name = "labelEpisodeTitle";
            this.toolTip1.SetToolTip(this.labelEpisodeTitle, resources.GetString("labelEpisodeTitle.ToolTip"));
            // 
            // labelPublicationDate
            // 
            resources.ApplyResources(this.labelPublicationDate, "labelPublicationDate");
            this.labelPublicationDate.Name = "labelPublicationDate";
            this.toolTip1.SetToolTip(this.labelPublicationDate, resources.GetString("labelPublicationDate.ToolTip"));
            // 
            // labelDescription
            // 
            resources.ApplyResources(this.labelDescription, "labelDescription");
            this.labelDescription.Name = "labelDescription";
            this.toolTip1.SetToolTip(this.labelDescription, resources.GetString("labelDescription.ToolTip"));
            // 
            // EpisodeView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "EpisodeView";
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
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
        public System.Windows.Forms.CheckBox checkBoxIsFavourite;
        public System.Windows.Forms.NumericUpDown numericUpDownRating;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBoxNotes;
        public System.Windows.Forms.TextBox textBoxTags;
        public System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public System.Windows.Forms.Label labelEpisodeTitle;
        public System.Windows.Forms.Label labelPublicationDate;
        public System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.ToolTip toolTip1;

    }
}
