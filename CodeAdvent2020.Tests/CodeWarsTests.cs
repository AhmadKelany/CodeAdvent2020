using CodeAdvent.Code.CodeWars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CodeAdvent.Tests
{
    public class CodeWarsTests
    {
        [Fact]
        public void minNumOfCoinsTest1()
        {
            var symbols = new string[] { "#", "!" };
            var expected = "apples, pears\ngrapes\nbananas";
            var input = "apples, pears # and bananas\ngrapes\nbananas !apples";
            Assert.Equal(expected, Logic.StripComments(input, symbols));
        }
    }
}
