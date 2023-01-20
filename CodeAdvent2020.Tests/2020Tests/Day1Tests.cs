using CodeAdvent.Code._2020;
using System.Linq;
using Xunit;

namespace CodeAdvent2020.Tests
{
    public class Day1Tests
    {
        [Fact]
        public void InputsValid()
        {
            var inputs = Day1.GetInputs();
            Assert.True(inputs.Any());
        }
        [Fact]
        public void Part1ReturnsValue()
        {
            var result = Day1.Part1();
            
            Assert.True(result > 0 );
        }
        [Fact]
        public void Part2ReturnsValue()
        {
            var result = Day1.Part2();
            
            Assert.True(result > 0 );
        }
    }
}
