using CodeAdvent2020.Code;
using System.Linq;
using Xunit;

namespace CodeAdvent2020.Tests
{
    public class Day6Tests
    {
        [Fact]
        public void InputsValid()
        {
            var inputs = Day6.GetAnswers();
            Assert.True(inputs.Any());
        }
        [Fact]
        public void Part1()
        {
            var result = Day6.Part1();
            Assert.True(result > 0);
        }
        [Fact]
        public void Part2()
        {
            var result = Day6.Part2();
            Assert.True(result > 0);
        }

    }
}
