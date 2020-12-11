using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CodeAdvent2020.Code;

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

    }
}
