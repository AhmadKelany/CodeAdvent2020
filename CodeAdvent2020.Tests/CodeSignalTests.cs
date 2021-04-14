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
    }
}
