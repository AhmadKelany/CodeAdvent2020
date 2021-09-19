using CodeAdvent.Code._2015;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CodeAdvent.Tests._2015Tests
{
    public class Day8Tests
    {
        [Theory]
        [InlineData("", 2, 0)]
        [InlineData("abc", 5, 3)]
        [InlineData("aaa\"aaa", 10, 7)]
        [InlineData("\x27", 6, 1)]
        public void GetStringLengthsTest(string s, int expectedCodeLength, int expectedMemoryLength)
        {
            var lengths = Day8.GetStringLengths(s);
            Assert.Equal(expectedMemoryLength, lengths.memoryLength);

            Assert.Equal(expectedCodeLength , lengths.codeLength);
        }
    }
}
