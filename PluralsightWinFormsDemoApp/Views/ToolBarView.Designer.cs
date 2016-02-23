﻿namespace PluralsightWinFormsDemoApp.Views
{
    partial class ToolBarView
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buttonAddSubscription = new System.Windows.Forms.ToolStripButton();
            this.buttonRemoveSubscription = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonPlay = new System.Windows.Forms.ToolStripButton();
            this.buttonPause = new System.Windows.Forms.ToolStripButton();
            this.buttonStop = new System.Windows.Forms.ToolStripButton();
            this.buttonFavourite = new System.Windows.Forms.ToolStripButton();
            this.buttonSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonAddSubscription,
            this.buttonRemoveSubscription,
            this.toolStripSeparator1,
            this.buttonPlay,
            this.buttonPause,
            this.buttonStop,
            this.buttonFavourite,
            this.buttonSettings});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(487, 39);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // buttonAddSubscription
            // 
            this.buttonAddSubscription.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonAddSubscription.Image = global::PluralsightWinFormsDemoApp.IconResources.add_icon_32;
            this.buttonAddSubscription.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonAddSubscription.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAddSubscription.Name = "buttonAddSubscription";
            this.buttonAddSubscription.Size = new System.Drawing.Size(36, 36);
            this.buttonAddSubscription.Text = "Add Subscription";
            // 
            // buttonRemoveSubscription
            // 
            this.buttonRemoveSubscription.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonRemoveSubscription.Image = global::PluralsightWinFormsDemoApp.IconResources.remove_icon_32;
            this.buttonRemoveSubscription.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonRemoveSubscription.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRemoveSubscription.Name = "buttonRemoveSubscription";
            this.buttonRemoveSubscription.Size = new System.Drawing.Size(36, 36);
            this.buttonRemoveSubscription.Text = "Remove Subscription";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // buttonPlay
            // 
            this.buttonPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonPlay.Image = global::PluralsightWinFormsDemoApp.IconResources.play_icon_32;
            this.buttonPlay.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(36, 36);
            this.buttonPlay.Text = "Play";
            // 
            // buttonPause
            // 
            this.buttonPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonPause.Image = global::PluralsightWinFormsDemoApp.IconResources.pause_icon_32;
            this.buttonPause.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(36, 36);
            this.buttonPause.Text = "Pause";
            // 
            // buttonStop
            // 
            this.buttonStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonStop.Image = global::PluralsightWinFormsDemoApp.IconResources.stop_icon_32;
            this.buttonStop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(36, 36);
            this.buttonStop.Text = "Stop";
            // 
            // buttonFavourite
            // 
            this.buttonFavourite.CheckOnClick = true;
            this.buttonFavourite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonFavourite.Image = global::PluralsightWinFormsDemoApp.IconResources.star_icon_32;
            this.buttonFavourite.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonFavourite.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonFavourite.Name = "buttonFavourite";
            this.buttonFavourite.Size = new System.Drawing.Size(36, 36);
            this.buttonFavourite.Text = "Favourite";
            // 
            // buttonSettings
            // 
            this.buttonSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonSettings.Image = global::PluralsightWinFormsDemoApp.IconResources.settings_icon_32;
            this.buttonSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(36, 36);
            this.buttonSettings.Text = "Settings";
            // 
            // ToolBarView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.toolStrip1);
            this.Name = "ToolBarView";
            this.Size = new System.Drawing.Size(487, 39);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton buttonAddSubscription;
        private System.Windows.Forms.ToolStripButton buttonRemoveSubscription;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton buttonPlay;
        private System.Windows.Forms.ToolStripButton buttonPause;
        private System.Windows.Forms.ToolStripButton buttonStop;
        private System.Windows.Forms.ToolStripButton buttonFavourite;
        private System.Windows.Forms.ToolStripButton buttonSettings;
    }
}
