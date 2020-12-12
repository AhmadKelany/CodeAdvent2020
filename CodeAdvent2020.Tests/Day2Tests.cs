using CodeAdvent2020.Code;
using System.Linq;
using Xunit;
using static CodeAdvent2020.Code.Day2;

namespace CodeAdvent2020.Tests
{
    public class Day2Tests
    {

        [Fact]
        public void InputsValid()
        {
            var inputs = Day2.GetInputs();
            Assert.True(inputs.Any());
        }
        [Fact]
        public void GetInputValid()
        {
            string line1 = "1-3 a: ololpa";
            string line2 = "10-13 g: lkjujhhdhdhh";
            string line3 = "9-125 i: lkikk";
            var input1 = Day2.GetInput(line1);
            var input2 = Day2.GetInput(line2);
            var input3 = Day2.GetInput(line3);
            Assert.Equal(new Input(1, 3, 'a', "ololpa"), input1);
            Assert.Equal(new Input(10, 13, 'g', "lkjujhhdhdhh"), input2);
            Assert.Equal(new Input(9, 125, 'i', "lkikk"), input3);
        }

        [Theory]
        [InlineData("1-3 a: ololpa" , true)]
        [InlineData("1-3 a: ololp" , false)]
        [InlineData("1-3 a: ololpaaa" , true)]
        [InlineData("1-3 a: aololpaaa" , false)]
        public void Part1Valid(string line , bool expected)
        {
            Assert.Equal(expected, Day2.Part1Valid(GetInput(line)));
        }

        [Fact]
        public void Part1Count()
        {
            var result = Day2.Part1Count();
            Assert.True(result > 0);
        }
[Fact]
        public void Part2Count()
        {
            var result = Day2.Part2Count();
            Assert.True(result > 0);
        }
    }
}
