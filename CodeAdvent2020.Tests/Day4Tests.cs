using CodeAdvent2020.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CodeAdvent2020.Tests
{
    public class Day4Tests
    {
        [Fact]
        public void InputsValid()
        {
            var inputs = Day4.GetInputs();
            Assert.True(inputs.Any());
        }
        [Fact]
        public void Part1()
        {
            var result = Day4.Part1();
            Assert.True(result > 0);
        }

    }
}
