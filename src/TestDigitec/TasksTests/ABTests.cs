using System;
using Tasks;
using Xunit;

namespace TasksTests
{
    public class ABTests
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData("A", 0)]
        [InlineData("B", 0)]
        [InlineData("AAAA", 0)]
        [InlineData("BBBB", 0)]
        [InlineData("AB", 0)]
        [InlineData("AAAAABBBBBBB", 0)]
        [InlineData("AABAABBBBBBB", 1)]
        [InlineData("AAAAABBBABBB", 1)]
        [InlineData("AABBABB", 1)]
        [InlineData("AAABABB", 1)]
        [InlineData("AAABBBAABB", 2)]
        public void CalcNumberOfRequiredDeleteActions_PredefinedString_ReturnsExpectedNumber(string abString, int expectedResult)
        {
            // Arrange
            var candidate = new AB();

            // Act
            var result = candidate.CalcNumberOfRequiredDeleteActions(abString);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}