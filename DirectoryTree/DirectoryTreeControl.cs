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
    public partial class DirectoryTreeControl : UserControl
    {
        private string prevDir;
        private DirectoryInfo selDir;
        private bool initialized;

        public DirectoryTreeControl()
        {
            InitializeComponent();
            prevDir = null;
            selDir = null;
            initialized = false;
        }

        public string SelectedPath
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
                        SelectedPath = prevDir;
                }
                catch (IOException e)
                {
                    MessageBox.Show(e.Message, "IO Error.",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (prevDir != null)
                        SelectedPath = prevDir;
                }
            }
        }

        public TreeNode SelectedNode => tvDirView.SelectedNode;

        private void BuildDir()
        {
            TreeNode selNode = new TreeNode(DirectoryUtils.TrimPathSep(selDir.Name));
            TreeNode root = BuildParents(selNode);

            BuildChildren(selNode);

            tvDirView.Nodes.Add(root);
            tvDirView.SelectedNode = selNode;
        }

        private TreeNode BuildParents(TreeNode bottom)
        {
            Stack<TreeNode> hierarchy = new Stack<TreeNode>();
            var currDir = selDir;

            while (currDir.Parent != null)
            {
                currDir = currDir.Parent;
                hierarchy.Push(new TreeNode(DirectoryUtils.TrimPathSep(currDir.Name)));
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

        private void BuildChildren(TreeNode root)
        {
            foreach (DirectoryInfo subDir in selDir.GetDirectories())
            {
                root.Nodes.Add(DirectoryUtils.TrimPathSep(subDir.Name));
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
                SelectedPath = tvDirView.SelectedNode.FullPath;
            }
            else
                initialized = true;
        }
    }
}
