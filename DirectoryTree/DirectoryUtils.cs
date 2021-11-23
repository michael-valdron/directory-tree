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
