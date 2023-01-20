using CodeAdvent.Code._2020;
using System.Linq;
using Xunit;

namespace CodeAdvent2020.Tests
{
    public class Day3Tests
    {
        [Fact]
        public void InputsValid()
        {
            var inputs = Day3.GetInputs();
            Assert.True(inputs.Any());
        }
        [Fact]
        public void Part1()
        {
            var result = Day3.Part1();
            Assert.True(result > 0);
        }
        [Fact]
        public void Part2()
        {
            var result = Day3.Part2();
            Assert.True(result > 0);
        }

    }
}
