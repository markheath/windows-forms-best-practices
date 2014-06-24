﻿namespace PluralsightWinFormsDemoApp
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBoxPodcasts = new System.Windows.Forms.ListBox();
            this.listBoxEpisodes = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBoxTags = new System.Windows.Forms.TextBox();
            this.textBoxNotes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownRating = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxIsFavourite = new System.Windows.Forms.CheckBox();
            this.labelEpisodeTitle = new System.Windows.Forms.Label();
            this.labelPublicationDate = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRating)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxPodcasts
            // 
            this.listBoxPodcasts.FormattingEnabled = true;
            this.listBoxPodcasts.Location = new System.Drawing.Point(13, 13);
            this.listBoxPodcasts.Name = "listBoxPodcasts";
            this.listBoxPodcasts.Size = new System.Drawing.Size(191, 316);
            this.listBoxPodcasts.TabIndex = 0;
            this.listBoxPodcasts.SelectedIndexChanged += new System.EventHandler(this.OnSelectedPodcastChanged);
            // 
            // listBoxEpisodes
            // 
            this.listBoxEpisodes.FormattingEnabled = true;
            this.listBoxEpisodes.Location = new System.Drawing.Point(211, 13);
            this.listBoxEpisodes.Name = "listBoxEpisodes";
            this.listBoxEpisodes.Size = new System.Drawing.Size(216, 316);
            this.listBoxEpisodes.TabIndex = 1;
            this.listBoxEpisodes.SelectedIndexChanged += new System.EventHandler(this.OnSelectedEpisodeChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 336);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnButtonAddSubscriptionClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(94, 335);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Remove";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OnButtonRemovePodcastClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(445, 310);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Play";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.OnButtonPlayClick);
            // 
            // textBoxTags
            // 
            this.textBoxTags.Location = new System.Drawing.Point(549, 98);
            this.textBoxTags.Name = "textBoxTags";
            this.textBoxTags.Size = new System.Drawing.Size(196, 20);
            this.textBoxTags.TabIndex = 4;
            // 
            // textBoxNotes
            // 
            this.textBoxNotes.Location = new System.Drawing.Point(445, 186);
            this.textBoxNotes.Multiline = true;
            this.textBoxNotes.Name = "textBoxNotes";
            this.textBoxNotes.Size = new System.Drawing.Size(300, 118);
            this.textBoxNotes.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(442, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "My Tags:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(442, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "My Notes:";
            // 
            // numericUpDownRating
            // 
            this.numericUpDownRating.Location = new System.Drawing.Point(549, 125);
            this.numericUpDownRating.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownRating.Name = "numericUpDownRating";
            this.numericUpDownRating.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownRating.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(442, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "My Rating:";
            // 
            // checkBoxIsFavourite
            // 
            this.checkBoxIsFavourite.AutoSize = true;
            this.checkBoxIsFavourite.Location = new System.Drawing.Point(549, 152);
            this.checkBoxIsFavourite.Name = "checkBoxIsFavourite";
            this.checkBoxIsFavourite.Size = new System.Drawing.Size(64, 17);
            this.checkBoxIsFavourite.TabIndex = 9;
            this.checkBoxIsFavourite.Text = "Favorite";
            this.checkBoxIsFavourite.UseVisualStyleBackColor = true;
            // 
            // labelEpisodeTitle
            // 
            this.labelEpisodeTitle.AutoSize = true;
            this.labelEpisodeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEpisodeTitle.ForeColor = System.Drawing.Color.DarkGray;
            this.labelEpisodeTitle.Location = new System.Drawing.Point(442, 13);
            this.labelEpisodeTitle.Name = "labelEpisodeTitle";
            this.labelEpisodeTitle.Size = new System.Drawing.Size(126, 25);
            this.labelEpisodeTitle.TabIndex = 10;
            this.labelEpisodeTitle.Text = "{{IN CODE}}";
            // 
            // labelPublicationDate
            // 
            this.labelPublicationDate.AutoSize = true;
            this.labelPublicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPublicationDate.Location = new System.Drawing.Point(442, 44);
            this.labelPublicationDate.Name = "labelPublicationDate";
            this.labelPublicationDate.Size = new System.Drawing.Size(67, 13);
            this.labelPublicationDate.TabIndex = 11;
            this.labelPublicationDate.Text = "{{IN CODE}}";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(442, 61);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(67, 13);
            this.labelDescription.TabIndex = 12;
            this.labelDescription.Text = "{{IN CODE}}";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(764, 381);
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
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBoxEpisodes);
            this.Controls.Add(this.listBoxPodcasts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "My Podcasts";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
            this.Load += new System.EventHandler(this.OnFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRating)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxPodcasts;
        private System.Windows.Forms.ListBox listBoxEpisodes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBoxTags;
        private System.Windows.Forms.TextBox textBoxNotes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownRating;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxIsFavourite;
        private System.Windows.Forms.Label labelEpisodeTitle;
        private System.Windows.Forms.Label labelPublicationDate;
        private System.Windows.Forms.Label labelDescription;
    }
}

