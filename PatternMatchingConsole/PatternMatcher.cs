using System.Text.RegularExpressions;

namespace PatternMatchingConsole
{
    public static class PatternMatcher
    {
        public static bool IsMatch(string input, string pattern)
        {
            if (input == null || pattern == null)
            {
                return false;
            }

            return Regex.IsMatch(input, ToRegexPattern(pattern));            
        }

        private static string ToRegexPattern(string pattern)
        {
            return "^" +
                   pattern
                       .EncodeEscapedPatterns()
                       .RegexEscape()
                       .Replace("_", ".")
                       .Replace("%", ".*")
                       .DecodeAndUnescapePatterns()
                   + "$";
        }
    }
}
