/* DirectoryTree
 * =============
 * 
 * Author: Michael Valdron
 * Build: 1.0
 * Licence: MIT 
 * Copyright (c) 2021-2023 Michael Valdron
 */
using System.IO;
using System.Text.RegularExpressions;

namespace DirectoryTree
{
    public sealed class DirectoryUtils
    {
        public static string TrimPathSep(string path)
        {
            var sep = Path.DirectorySeparatorChar;
            var rootIdent = (sep == '\\') ? ":" : "";
            
            if (Path.IsPathRooted(path))
                return Regex.Replace(path, $"{rootIdent}\\{sep}", rootIdent);
            else
                return path;
        }
    }
}
