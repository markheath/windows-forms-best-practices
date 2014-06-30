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
            this.treeViewPodcasts = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonAddSubscription = new System.Windows.Forms.Button();
            this.buttonRemoveSubscription = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewPodcasts
            // 
            this.treeViewPodcasts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewPodcasts.Location = new System.Drawing.Point(0, 0);
            this.treeViewPodcasts.Name = "treeViewPodcasts";
            this.treeViewPodcasts.Size = new System.Drawing.Size(199, 357);
            this.treeViewPodcasts.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonRemoveSubscription);
            this.panel1.Controls.Add(this.buttonAddSubscription);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 357);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(199, 39);
            this.panel1.TabIndex = 8;
            // 
            // buttonAddSubscription
            // 
            this.buttonAddSubscription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddSubscription.Location = new System.Drawing.Point(3, 9);
            this.buttonAddSubscription.Name = "buttonAddSubscription";
            this.buttonAddSubscription.Size = new System.Drawing.Size(75, 23);
            this.buttonAddSubscription.TabIndex = 7;
            this.buttonAddSubscription.Text = "Add";
            this.buttonAddSubscription.UseVisualStyleBackColor = true;
            // 
            // buttonRemoveSubscription
            // 
            this.buttonRemoveSubscription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRemoveSubscription.Location = new System.Drawing.Point(84, 9);
            this.buttonRemoveSubscription.Name = "buttonRemoveSubscription";
            this.buttonRemoveSubscription.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveSubscription.TabIndex = 8;
            this.buttonRemoveSubscription.Text = "Remove";
            this.buttonRemoveSubscription.UseVisualStyleBackColor = true;
            // 
            // SubscriptionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeViewPodcasts);
            this.Controls.Add(this.panel1);
            this.Name = "SubscriptionView";
            this.Size = new System.Drawing.Size(199, 396);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TreeView treeViewPodcasts;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button buttonRemoveSubscription;
        public System.Windows.Forms.Button buttonAddSubscription;
    }
}
