/* DirectoryTree
 * =============
 * 
 * Author: Michael Valdron
 * Build: 1.0
 * Licence: MIT 
 * Copyright (c) 2017 Michael Valdron
 */

using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System;

namespace DirectoryTree
{
    public partial class DirectoryTree : UserControl
    {
        private string prevDir;
        private DirectoryInfo selDir;
        private bool initialized;

        public DirectoryTree()
        {
            InitializeComponent();
            prevDir = null;
            selDir = null;
            initialized = false;
        }

        public string Path
        {
            get => (selDir != null) ? selDir.FullName : "";
            set
            {
                try
                {
                    if (value != null && Directory.Exists(value))
                    {
                        if (selDir != null)
                            prevDir = selDir.FullName;
                        selDir = new DirectoryInfo(value);
                        RemoveNodes();
                        BuildDir();
                    }
                    else
                    {
                        if (selDir != null)
                            prevDir = selDir.FullName;
                        selDir = null;
                    }
                }
                catch (UnauthorizedAccessException e)
                {
                    MessageBox.Show(e.Message, "Access Denied.", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (prevDir != null)
                        Path = prevDir;
                }
                catch (IOException e)
                {
                    MessageBox.Show(e.Message, "IO Error.",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (prevDir != null)
                        Path = prevDir;
                }
            }
        }

        public TreeNode SelectedNode
        {
            get
            {
                return tvDirView.SelectedNode;
            }
        }

        private void BuildDir()
        {
            TreeNode selNode = new TreeNode(selDir.Name);
            TreeNode root = BuildParents(ref selNode);

            BuildChildren(ref selNode);

            tvDirView.Nodes.Add(root);
            tvDirView.SelectedNode = selNode;
        }

        private TreeNode BuildParents(ref TreeNode bottom)
        {
            Stack<TreeNode> hierarchy = new Stack<TreeNode>();
            var currDir = selDir;

            while (currDir.Parent != null)
            {
                currDir = currDir.Parent;
                hierarchy.Push(new TreeNode(currDir.Name));
            }

            if (hierarchy.Count == 0)
            {
                return bottom;
            }
            else
            {
                var root = hierarchy.Pop();
                var currNode = root;

                while (hierarchy.Count != 0)
                {
                    var nextNode = hierarchy.Pop();
                    currNode.Nodes.Add(nextNode);
                    currNode = nextNode;
                }

                currNode.Nodes.Add(bottom);

                return root;
            }
        }

        private void BuildChildren(ref TreeNode root)
        {
            foreach (DirectoryInfo subDir in selDir.GetDirectories())
            {
                root.Nodes.Add(subDir.Name);
            }
        }

        private void RemoveNodes()
        {
            foreach (TreeNode aNode in tvDirView.Nodes)
            {
                aNode.Remove();
            }
        }

        private void TvDirView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (initialized)
            {
                initialized = false;
                Path = tvDirView.SelectedNode.FullPath;
            }
            else
                initialized = true;
        }
    }
}
