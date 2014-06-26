namespace PluralsightWinFormsDemoApp
{
    partial class SubscriptionView
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
            this.buttonRemoveSubscription = new System.Windows.Forms.Button();
            this.buttonAddSubscription = new System.Windows.Forms.Button();
            this.listBoxEpisodes = new System.Windows.Forms.ListBox();
            this.listBoxPodcasts = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // buttonRemoveSubscription
            // 
            this.buttonRemoveSubscription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRemoveSubscription.Location = new System.Drawing.Point(94, 366);
            this.buttonRemoveSubscription.Name = "buttonRemoveSubscription";
            this.buttonRemoveSubscription.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveSubscription.TabIndex = 5;
            this.buttonRemoveSubscription.Text = "Remove";
            this.buttonRemoveSubscription.UseVisualStyleBackColor = true;
            // 
            // buttonAddSubscription
            // 
            this.buttonAddSubscription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddSubscription.Location = new System.Drawing.Point(13, 366);
            this.buttonAddSubscription.Name = "buttonAddSubscription";
            this.buttonAddSubscription.Size = new System.Drawing.Size(75, 23);
            this.buttonAddSubscription.TabIndex = 6;
            this.buttonAddSubscription.Text = "Add";
            this.buttonAddSubscription.UseVisualStyleBackColor = true;
            // 
            // listBoxEpisodes
            // 
            this.listBoxEpisodes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxEpisodes.FormattingEnabled = true;
            this.listBoxEpisodes.Location = new System.Drawing.Point(211, 12);
            this.listBoxEpisodes.Name = "listBoxEpisodes";
            this.listBoxEpisodes.Size = new System.Drawing.Size(216, 342);
            this.listBoxEpisodes.TabIndex = 4;
            // 
            // listBoxPodcasts
            // 
            this.listBoxPodcasts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxPodcasts.FormattingEnabled = true;
            this.listBoxPodcasts.Location = new System.Drawing.Point(13, 12);
            this.listBoxPodcasts.Name = "listBoxPodcasts";
            this.listBoxPodcasts.Size = new System.Drawing.Size(191, 342);
            this.listBoxPodcasts.TabIndex = 3;
            // 
            // SubscriptionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonRemoveSubscription);
            this.Controls.Add(this.buttonAddSubscription);
            this.Controls.Add(this.listBoxEpisodes);
            this.Controls.Add(this.listBoxPodcasts);
            this.Name = "SubscriptionView";
            this.Size = new System.Drawing.Size(444, 396);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button buttonRemoveSubscription;
        public System.Windows.Forms.Button buttonAddSubscription;
        public System.Windows.Forms.ListBox listBoxEpisodes;
        public System.Windows.Forms.ListBox listBoxPodcasts;
    }
}
