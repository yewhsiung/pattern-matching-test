using PatternMatchingConsole;
using Xunit;

namespace PatternMatchingTests
{
    public class PatternMatcherTest
    {
        [Theory]
        [InlineData("abc", "abc")]
        [InlineData("", "")]
        public void IsMatch_WithExactSameString_ReturnsTrue(string input, string pattern)
        {
            //arrange

            //act
            var result = PatternMatcher.IsMatch(input, pattern);

            //assert
            Assert.True(result);
        }

        [Fact]
        public void IsMatch_WithDifferentStringAndNoWildcard_ReturnsFalse()
        {
            //arrange

            //act
            var result = PatternMatcher.IsMatch("abc", "abcd");

            //assert
            Assert.False(result);
        }

        [Theory]
        [InlineData("abc", "a_c")]
        [InlineData("abcd", "a_c_")]
        [InlineData("abcd", "_bc_")]
        [InlineData("cd", "__")]
        public void IsMatch_WithUnderscore_MatchesAnyCharsWithSameCount(string input, string pattern)
        {
            //arrange

            //act
            var result = PatternMatcher.IsMatch(input, pattern);

            //assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("abdgdgdgd", "ab%d")]
        [InlineData("abd", "ab%d")]
        [InlineData("abdasdasdasdasdasdasdas", "%")]
        public void IsMatch_WithPercentageSign_MatchesAnyCharsWithAnyCount(string input, string pattern)
        {
            //arrange

            //act
            var result = PatternMatcher.IsMatch(input, pattern);

            //assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("axbxxxxxxdd", @"a_b%d")]
        public void IsMatch_WithMixedWildcards_MatchesValidInput(string input, string pattern)
        {
            //arrange

            //act
            var result = PatternMatcher.IsMatch(input, pattern);

            //assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("ab%", @"ab\%")]
        [InlineData("ab_", @"ab\_")]
        public void IsMatch_WithEscapeChar_MatchesInputWithoutEscape(string input, string pattern)
        {
            //arrange

            //act
            var result = PatternMatcher.IsMatch(input, pattern);

            //assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("&underscore;", @"&underscore;")]
        [InlineData("&amp;amp;underscore;", @"&amp;amp;underscore;")]
        [InlineData("[]<>{}&;", @"[]<>{}&;")]
        public void IsMatch_WithHtmlEncodeChars_Success(string input, string pattern)
        {
            //arrange

            //act
            var result = PatternMatcher.IsMatch(input, pattern);

            //assert
            Assert.True(result);
        }

        [Fact]
        public void IsMatch_WithRegexSpecialChars_Success()
        {
            //arrange

            //act
            var result = PatternMatcher.IsMatch("<>{}[]*?.()|", "<>{}[]*?.()|");

            //assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("", null)]
        [InlineData(null, "")]
        [InlineData(null, null)]
        public void IsMatch_WithNullParams_Success(string input, string pattern)
        {
            //arrange

            //act
            var result = PatternMatcher.IsMatch(input, pattern);

            //assert
            Assert.False(result);
        }
    }
}
