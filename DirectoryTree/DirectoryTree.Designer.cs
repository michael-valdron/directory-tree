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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DirectoryTree));
            this.tvDirView = new System.Windows.Forms.TreeView();
            this.imglstDirIco = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // tvDirView
            // 
            this.tvDirView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDirView.ImageIndex = 0;
            this.tvDirView.ImageList = this.imglstDirIco;
            this.tvDirView.Location = new System.Drawing.Point(0, 0);
            this.tvDirView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tvDirView.Name = "tvDirView";
            this.tvDirView.SelectedImageIndex = 0;
            this.tvDirView.Size = new System.Drawing.Size(443, 390);
            this.tvDirView.TabIndex = 2;
            this.tvDirView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDirView_AfterSelect);
            // 
            // imglstDirIco
            // 
            this.imglstDirIco.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglstDirIco.ImageStream")));
            this.imglstDirIco.TransparentColor = System.Drawing.Color.Transparent;
            this.imglstDirIco.Images.SetKeyName(0, "directory-98516_1280.png");
            // 
            // DirectoryTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvDirView);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DirectoryTree";
            this.Size = new System.Drawing.Size(443, 390);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvDirView;
        private System.Windows.Forms.ImageList imglstDirIco;
    }
}
