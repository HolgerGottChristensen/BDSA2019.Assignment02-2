using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BDSA2019.Assignment02
{
    public static class RegExpr
    {
        public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
        {
            string pattern = @"\S+";
            foreach (var line in lines)
            {
                foreach (Match m in Regex.Matches(line, pattern))
                {
                    yield return m.Value;
                }
            }
        }

        public static IEnumerable<(int width, int height)> Resolution(string resolutions)
        {
            string pattern = @"(?<width>\d+)x(?<height>\d+)";
            foreach (Match m in Regex.Matches(resolutions, pattern))
                {
                    Int32.TryParse(m.Groups["width"].Value, out int width);
                    Int32.TryParse(m.Groups["height"].Value, out int height);
                    yield return (width, height);
                }
        }

        public static IEnumerable<string> InnerText(string html, string tag)
        {
            string pattern = @"<(" + tag + @") ?.*?>(.*?)<\/\1>";
            string pattern2 = @"<.*?>";
        
            foreach (Match m in Regex.Matches(html, pattern))
            {
                var match = m.Groups[2].Value;
                match = Regex.Replace(match, pattern2, "");
                yield return match;
            }
        }
    }
}
