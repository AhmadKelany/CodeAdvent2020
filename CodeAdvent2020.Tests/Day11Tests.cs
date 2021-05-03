using CodeAdvent.Code._2020;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CodeAdvent2020.Tests
{
    public class Day11Tests
    {
        [Fact]
        public void Part1()
        {
            var result = Day11.Part1();
            Assert.True(result > 0);
        }

    }
}
