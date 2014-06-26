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
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelPublicationDate = new System.Windows.Forms.Label();
            this.labelEpisodeTitle = new System.Windows.Forms.Label();
            this.checkBoxIsFavourite = new System.Windows.Forms.CheckBox();
            this.numericUpDownRating = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNotes = new System.Windows.Forms.TextBox();
            this.textBoxTags = new System.Windows.Forms.TextBox();
            this.buttonPlay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRating)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDescription
            // 
            this.labelDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDescription.Location = new System.Drawing.Point(3, 57);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(408, 56);
            this.labelDescription.TabIndex = 23;
            this.labelDescription.Text = "{{IN CODE}}";
            // 
            // labelPublicationDate
            // 
            this.labelPublicationDate.AutoSize = true;
            this.labelPublicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPublicationDate.Location = new System.Drawing.Point(3, 40);
            this.labelPublicationDate.Name = "labelPublicationDate";
            this.labelPublicationDate.Size = new System.Drawing.Size(67, 13);
            this.labelPublicationDate.TabIndex = 22;
            this.labelPublicationDate.Text = "{{IN CODE}}";
            // 
            // labelEpisodeTitle
            // 
            this.labelEpisodeTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelEpisodeTitle.AutoEllipsis = true;
            this.labelEpisodeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEpisodeTitle.ForeColor = System.Drawing.Color.DarkGray;
            this.labelEpisodeTitle.Location = new System.Drawing.Point(3, 9);
            this.labelEpisodeTitle.Name = "labelEpisodeTitle";
            this.labelEpisodeTitle.Size = new System.Drawing.Size(408, 25);
            this.labelEpisodeTitle.TabIndex = 21;
            this.labelEpisodeTitle.Text = "{{IN CODE}}";
            // 
            // checkBoxIsFavourite
            // 
            this.checkBoxIsFavourite.AutoSize = true;
            this.checkBoxIsFavourite.Location = new System.Drawing.Point(110, 170);
            this.checkBoxIsFavourite.Name = "checkBoxIsFavourite";
            this.checkBoxIsFavourite.Size = new System.Drawing.Size(64, 17);
            this.checkBoxIsFavourite.TabIndex = 20;
            this.checkBoxIsFavourite.Text = "Favorite";
            this.checkBoxIsFavourite.UseVisualStyleBackColor = true;
            // 
            // numericUpDownRating
            // 
            this.numericUpDownRating.Location = new System.Drawing.Point(110, 143);
            this.numericUpDownRating.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownRating.Name = "numericUpDownRating";
            this.numericUpDownRating.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownRating.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "My Notes:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "My Rating:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "My Tags:";
            // 
            // textBoxNotes
            // 
            this.textBoxNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNotes.Location = new System.Drawing.Point(6, 205);
            this.textBoxNotes.Multiline = true;
            this.textBoxNotes.Name = "textBoxNotes";
            this.textBoxNotes.Size = new System.Drawing.Size(405, 93);
            this.textBoxNotes.TabIndex = 15;
            // 
            // textBoxTags
            // 
            this.textBoxTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTags.Location = new System.Drawing.Point(110, 116);
            this.textBoxTags.Name = "textBoxTags";
            this.textBoxTags.Size = new System.Drawing.Size(301, 20);
            this.textBoxTags.TabIndex = 14;
            // 
            // buttonPlay
            // 
            this.buttonPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPlay.Location = new System.Drawing.Point(6, 304);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(75, 23);
            this.buttonPlay.TabIndex = 13;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            // 
            // EpisodeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelPublicationDate);
            this.Controls.Add(this.labelEpisodeTitle);
            this.Controls.Add(this.checkBoxIsFavourite);
            this.Controls.Add(this.numericUpDownRating);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNotes);
            this.Controls.Add(this.textBoxTags);
            this.Controls.Add(this.buttonPlay);
            this.Name = "EpisodeView";
            this.Size = new System.Drawing.Size(421, 334);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRating)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label labelDescription;
        public System.Windows.Forms.Label labelPublicationDate;
        public System.Windows.Forms.Label labelEpisodeTitle;
        public System.Windows.Forms.CheckBox checkBoxIsFavourite;
        public System.Windows.Forms.NumericUpDown numericUpDownRating;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBoxNotes;
        public System.Windows.Forms.TextBox textBoxTags;
        public System.Windows.Forms.Button buttonPlay;
    }
}
