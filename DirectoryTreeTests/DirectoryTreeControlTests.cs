/* DirectoryTree
 * =============
 * 
 * Author: Michael Valdron
 * Build: 1.0
 * Licence: MIT 
 * Copyright (c) 2023 Michael Valdron
 */
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DirectoryTree.Tests
{
    [TestClass()]
    public class DirectoryTreeControlTests
    {
        private const int T_SIZE = 10;
        private const string ROOT = "testing";

        [ClassInitialize()]
        public static void Initialize(TestContext context)
        {
            var root = Directory.CreateDirectory(Path.GetFullPath(ROOT)).FullName;

            for (int i = 1; i <= T_SIZE; i++)
                Directory.CreateDirectory(Path.Combine(root, $"subdir_{i}"));
        }

        [ClassCleanup()]
        public static void Cleanup()
        {
            Directory.Delete(Path.GetFullPath(ROOT), true);
        }

        [TestMethod()]
        public void SelectedPathTest()
        {
            var directoryTree = new DirectoryTreeControl();
            var root = Path.GetFullPath(ROOT);
            Assert.AreEqual("", directoryTree.SelectedPath);
            directoryTree.SelectedPath = root;
            Assert.AreEqual(root, directoryTree.SelectedPath);
        }

        [TestMethod()]
        public void SelectedNodeTest()
        {
            var directoryTree = new DirectoryTreeControl
            {
                SelectedPath = Path.GetFullPath(ROOT)
            };
            Assert.AreEqual(directoryTree.SelectedPath, directoryTree.SelectedNode.FullPath);
        }
    }
}