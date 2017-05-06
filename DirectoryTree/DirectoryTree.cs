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

namespace DirectoryTree
{
    public partial class DirectoryTree : UserControl
    {
        private TreeNode currNode;

        public DirectoryTree()
        {
            InitializeComponent();
        }

        public TreeView Tree
        {
            get
            {
                return tvDirView;
            }
        }

        public TreeNode SelectedNode
        {
            get
            {
                return currNode;
            }
            set
            {
                currNode = value;
            }
        }

        public TreeNode buildDir(DirectoryInfo dirInfo)
        {
            TreeNode topNode;

            topNode = buildDirParents(dirInfo, tvDirView.Nodes);

            buildSubDirs(dirInfo, topNode.Nodes);

            return topNode;
        }

        private TreeNode buildDirParents(DirectoryInfo dirInfo, TreeNodeCollection tree)
        {
            TreeNode selNode;

            if (dirInfo.FullName == dirInfo.Root.FullName)
            {
                return tree.Add(dirInfo.Name);
            }
            else
            {
                selNode = buildDirParents(dirInfo.Parent, tree);
                return selNode.Nodes.Add(dirInfo.Name);
            }
        }

        private void buildSubDirs(DirectoryInfo dirInfo, TreeNodeCollection tree)
        {
            foreach (DirectoryInfo subDir in dirInfo.GetDirectories())
            {
                tree.Add(subDir.Name);
            }
        }

        public DirectoryInfo findParentNode(DirectoryInfo currDir, TreeNode tarNode)
        {
            if (currDir.Name.Equals(tarNode.Text))
            {
                return currDir;
            }
            else if (currDir.Parent == null)
            {
                return null;
            }
            else
            {
                return findParentNode(currDir.Parent, tarNode);
            }
        }

        public DirectoryInfo findChildNode(DirectoryInfo currDir, TreeNode tarNode)
        {
            DirectoryInfo result = null;

            foreach (DirectoryInfo subDir in currDir.GetDirectories())
            {
                if (subDir.Name.Equals(tarNode.Text))
                {
                    return subDir;
                }
            }

            return result;
        }

        public void removeNodes()
        {
            foreach (TreeNode aNode in tvDirView.Nodes)
            {
                aNode.Remove();
            }
        }
    }
}
