using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace PatternMatchingConsole
{
    public static class StringExtensions
    {
        private static readonly Dictionary<string, string> EscapedPatternToPlaceholderMap =
            new Dictionary<string, string>
            {
                ["\\_"] = "&underscore;",
                ["\\%"] = "&percentage;"
            };

        private static readonly Dictionary<string, string> PlaceholderToUnescapedPatternMap =
            new Dictionary<string, string>
            {
                ["&underscore;"] = "_",
                ["&percentage;"] = "%"
            };

        public static string RegexEscape(this string input)
        {
            return string.IsNullOrEmpty(input) ? input : Regex.Escape(input);
        }

        public static string EncodeEscapedPatterns(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            //first encode to make sure no unwanted & in input
            var result = new StringBuilder(HttpUtility.HtmlEncode(input));

            //then replace escaped pattern(s) with correspnnding placeholders
            foreach (var map in EscapedPatternToPlaceholderMap)
            {
                result.Replace(map.Key, map.Value);
            }

            return result.ToString();
        }

        public static string DecodeAndUnescapePatterns(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            //first replace placeholder(s) with unescaped pattern(s)
            var result = new StringBuilder(input);
            foreach (var map in PlaceholderToUnescapedPatternMap)
            {
                result.Replace(map.Key, map.Value);
            }

            //then decode since it was  encoded
            return HttpUtility.HtmlDecode(result.ToString());
        }
    }
}
