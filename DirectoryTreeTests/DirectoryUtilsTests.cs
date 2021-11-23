﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DirectoryTree.Tests
{
    [TestClass()]
    public class DirectoryUtilsTests
    {
        [TestMethod()]
        public void TrimPathSepTest()
        {
            var input = "C:\\";
            var expected = "C:";
            Assert.AreEqual(expected, DirectoryUtils.TrimPathSep(input));
        }
    }
}