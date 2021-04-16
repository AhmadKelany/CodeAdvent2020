using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CodeAdvent2020.Code.CodeSignal;

namespace CodeAdvent2020.Tests
{
    public class CodeSignalTests
    {
        [Theory]
        [InlineData(5,2,9)]
        [InlineData(1,2,1)]
        public void candlesTest(int candlesCount , int newMake , int expected)
        {
            Assert.Equal(expected, Code.CodeSignal.Logic.candles(candlesCount, newMake));
        }

        [Theory]
        [InlineData(6, "crossword","square","formation","something")]
        [InlineData(0, "anaesthetist","thatch","ethnics","sabulous")]
        [InlineData(4, "eternal","texas","chainsaw","massacre")]
        public void crossWordFormation(int expected , string w1 , string w2, string w3, string w4 )
        {
            string[] words = new string[] { w1, w2, w3, w4 };
            Assert.Equal(6, Logic.crosswordFormation(words));
        }
    }
}
