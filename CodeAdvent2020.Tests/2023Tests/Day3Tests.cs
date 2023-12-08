using CodeAdvent.Code;
using CodeAdvent.Code._2023;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

using static CodeAdvent.Code._2020.Day8;

namespace CodeAdvent.Tests._2023Tests;

public class Day3Tests
{
    [Fact]
    public void GetPartNumbersTestSampleInput()
    {
        string[] sampleInput = "467..114..\r\n...*......\r\n..35..633.\r\n......#...\r\n617*......\r\n.....+.58.\r\n..592.....\r\n......755.\r\n...$.*....\r\n.664.598..".Split("\r\n");
        var parts = Day3.GetPartNumbers(sampleInput);
        Assert.Equal(10, parts.Count);

        var p0 = parts[0];
        Assert.Equal( 467 , p0.Number);
        Assert.Equal( 0 , p0.X);
        Assert.True(p0.Ys.SequenceEqual([0,1,2]));

        var p9 = parts[9];
        Assert.Equal( 598 , p9.Number);
        Assert.Equal( 9 , p9.X);
        Assert.True(p9.Ys.SequenceEqual([5,6,7]));
        
    }
    [Fact]
    public void PassesPart1WithSampleInput()
    {
        string[] sampleInput = "467..114..\r\n...*......\r\n..35..633.\r\n......#...\r\n617*......\r\n.....+.58.\r\n..592.....\r\n......755.\r\n...$.*....\r\n.664.598..".Split("\r\n");
        var parts = Day3.GetPartNumbers(sampleInput);
        var symbolPoints = Day3.GetSymbolPoints(sampleInput, @"!@#$%^&*+-*/\=_(){}[]?><;'".ToArray());
        var symbolsAdjacentPoints = Day3.GetPointsAdjacentToSymbols(symbolPoints);
        int result = parts.Where(p => Day3.PartInPoints(p, symbolsAdjacentPoints)).Sum(p => p.Number);
        Assert.Equal(4361, result);
    }

    [Fact]
    public void PassesPart2WithSampleInput()
    {
        string[] sampleInput = "467..114..\r\n...*......\r\n..35..633.\r\n......#...\r\n617*......\r\n.....+.58.\r\n..592.....\r\n......755.\r\n...$.*....\r\n.664.598..".Split("\r\n");
        var parts = Day3.GetPartNumbers(sampleInput);
        var symbolPoints = Day3.GetSymbolPoints(sampleInput, @"*".ToArray());

        int result = 0;
        foreach (var point in symbolPoints)
        {
            var adjacentPoints = Day3.GetPointsAdjacentTo(point);
            var adjacentParts = parts.Where(p => Day3.PartInPoints(p, adjacentPoints)).ToArray();

            if (adjacentParts.Length == 2)
            {
                result += (adjacentParts.First().Number * adjacentParts.Last().Number);
            }
        }
        Assert.Equal(467835, result);
    }


}
