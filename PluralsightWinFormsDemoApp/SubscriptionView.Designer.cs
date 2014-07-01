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
            this.treeViewPodcasts = new System.Windows.Forms.TreeView();
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
            this.buttonAddSubscription.Text = "&Add";
            this.buttonAddSubscription.UseVisualStyleBackColor = true;
            // 
            // treeViewPodcasts
            // 
            this.treeViewPodcasts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewPodcasts.Location = new System.Drawing.Point(0, 0);
            this.treeViewPodcasts.Name = "treeViewPodcasts";
            this.treeViewPodcasts.Size = new System.Drawing.Size(199, 360);
            this.treeViewPodcasts.TabIndex = 7;
            // 
            // SubscriptionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeViewPodcasts);
            this.Controls.Add(this.buttonRemoveSubscription);
            this.Controls.Add(this.buttonAddSubscription);
            this.Name = "SubscriptionView";
            this.Size = new System.Drawing.Size(199, 396);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button buttonRemoveSubscription;
        public System.Windows.Forms.Button buttonAddSubscription;
        public System.Windows.Forms.TreeView treeViewPodcasts;
    }
}
