namespace DirectoryTree
{
    partial class DirectoryTree
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
            this.tvDirView = new System.Windows.Forms.TreeView();
            this.imglstDirIco = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // tvDirView
            // 
            this.tvDirView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvDirView.Location = new System.Drawing.Point(0, 0);
            this.tvDirView.Name = "tvDirView";
            this.tvDirView.Size = new System.Drawing.Size(354, 481);
            this.tvDirView.TabIndex = 2;
            // 
            // imglstDirIco
            // 
            this.imglstDirIco.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imglstDirIco.ImageSize = new System.Drawing.Size(16, 16);
            this.imglstDirIco.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // DirectoryTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvDirView);
            this.Name = "DirectoryTree";
            this.Size = new System.Drawing.Size(354, 481);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvDirView;
        private System.Windows.Forms.ImageList imglstDirIco;
    }
}
