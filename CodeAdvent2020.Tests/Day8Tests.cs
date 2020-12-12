using CodeAdvent2020.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CodeAdvent2020.Tests
{
    public class Day8Tests
    {
        [Fact]
        public void Part1()
        {
            var result = Day8.Part1();
            Assert.True(result > 0);
        }
        [Fact]
        public void Part2()
        {
            var result = Day8.Part2();
            Assert.True(result == 0);
        }

    }
}
