using CodeAdvent.Code._2015;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace CodeAdvent.Tests._2015Tests;

public class Day9Tests
{
    [Fact]
    public void ShouldSolveTestDataCorrectly()
    {
        var testInput = Day9.GetTestInput();
        int result = Day9.GetShortestDistance(testInput);
        int expected = 605;
        Assert.Equal(expected, result);
    }
}
