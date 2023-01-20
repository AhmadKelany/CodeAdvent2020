using System.Collections.Generic;
using System.Linq;
using Xunit;
using CodeAdvent.Code._2020;

namespace CodeAdvent2020.Tests
{
    public class Day7Tests
    {
        [Fact]
        public void InputsValid()
        {
            var rules = Day7.GetRules();
            var colors = Day7.GetBagColors();
            var containing = Day7.GetColorsContaining(new List<string> { "shiny gold" });
            Assert.True(rules.Any());
        }
        [Fact]
        public void Part1()
        {
            var rules = Day7.GetRules();
            var colors = Day7.GetBagColors();
            var containing = Day7.GetColorsContaining(new List<string> { "shiny gold" });

            var result = Day7.Part1();
            Assert.True(result > 0);
        }
        [Fact]
        public void Part2()
        {
            var result = Day7.Part2();
            Assert.True(result > 0);
        }

    }
}
