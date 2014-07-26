using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PathSplit
{
    public class Splitter
    {
        public static string[] SplitPath(string path, char splitChar = Constants.Delimitter)
        {
            IList<string> listPath = new List<string>(3);
            if (path == null) return listPath.ToArray();
            path = path.TrimStart(splitChar);

            var start = 0;
            var end = 0;
            var length = path.Length;

            string element;
            string backSlashReplaceStr = Constants.BlackSlash + Constants.BlackSlash;
            string slashReplaceStr = Constants.BlackSlash + splitChar;

            while (end < length - 1)
            {
                if (path[end] == splitChar)
                {
                    // Capture path element
                    element = path.Substring(start, end - start).Replace(backSlashReplaceStr, Constants.BlackSlash).Replace(slashReplaceStr, splitChar.ToString());
                    if (String.IsNullOrEmpty(element))
                    {
                        throw new ArgumentException("Invalid Path.");
                    }
                    listPath.Add(element);
                    start = ++end;
                }
                else if (path[end] == Constants.BlackSlashChar)
                {
                    ++end;
                    if (path[end] == splitChar || path[end] == Constants.BlackSlashChar)
                    {
                        end++;
                    }
                    else
                    {
                        throw new ArgumentException("Invalid Path.");
                    }
                }
                else
                {
                    end++;
                }
            }

            if (end == length - 1)
            {
                // Remove last split character
                if (path.EndsWith(splitChar.ToString()))
                {
                    path = path.Remove(end);
                    length = path.Length;
                }
            }

            // Capture last path element
            element = path.Substring(start, length - start).Replace(backSlashReplaceStr, Constants.BlackSlash).Replace(slashReplaceStr, splitChar.ToString());
            listPath.Add(element);

            return listPath.ToArray();
        }
    }

    class Constants
    {
        public const char Delimitter = '/';
        public const string BlackSlash = @"\";
        public const char BlackSlashChar = '\\';
    }
}
