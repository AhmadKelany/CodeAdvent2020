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
        [Fact]
        public void minNumOfCoinsTest2()
        {
            var symbols = new string[] { "#", "$" };
            var expected = "a\n b\nc";
            var input = "a \n b \nc ";
            Assert.Equal(expected, Logic.StripComments(input, symbols));
        }
        
        [Fact]
        public void minNumOfCoinsTest3()
        {
            var symbols = new string[] { "a"};
            var expected = string.Empty;
            var input = "a";
            Assert.Equal(expected, Logic.StripComments(input, symbols));
        }
        
        [Fact]
        public void minNumOfCoinsTest4()
        {
            var symbols = new string[] { "#"};
            var expected = string.Empty;
            var input = "# some text";
            Assert.Equal(expected, Logic.StripComments(input, symbols));
        }
        [Fact]
        public void minNumOfCoinsTest5()
        {
            var symbols = new string[] { "#","$","!", "-"};
            var expected = "DAEE\nCAF\n\nDF\n\nCB\n\n\n\nB\n\nB";
            var input = "DAEE\nCAF\n\nDF\n\nCB\n\n#CA\n\nB\n\nB";
            Assert.Equal(expected, Logic.StripComments(input, symbols));
        }
    }
}
