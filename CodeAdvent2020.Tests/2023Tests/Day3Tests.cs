using CodeAdvent.Code._2023;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace CodeAdvent.Tests._2023Tests;

public class Day3Tests
{
    static List<string> lines = ["467..114..", "...*......", "..35..633.", "......#...", "617*......", ".....+.58.", "..592.....", "......755.", "...$.*....", ".664.598.."];
    [Fact]
    public void GetPartNumbersTest()
    {
        var parts = Day3.GetPartNumbers(lines);
        Assert.Equal(10, parts.Count);
        Assert.Equal( new(467 , [new (0,0),new (0,1),new (0,2)]) , parts[0]);
        
        Assert.Equal( new(114 , [new (0,5),new (0,6),new (0,7)]) , parts[1]);
        Assert.Equal( new(35 , [new (2,2),new (2,3)]) , parts[2]);
        Assert.Equal( new(633 , [new (2,6),new (2,7),new (2,8)]) , parts[3]);
        Assert.Equal( new(617 , [new (4,0),new (4,1),new (4,2)]) , parts[4]);
        Assert.Equal( new(58 , [new (5,7),new (5,8)]) , parts[5]);
        Assert.Equal( new(592 , [new (6,2),new (6,3),new (6,4)]) , parts[6]);
        Assert.Equal( new(755 , [new (7,6),new (7,7),new (7,8)]) , parts[7]);
        Assert.Equal( new(664 , [new (9,1),new (9,2),new (9,3)]) , parts[8]);
        Assert.Equal( new(598 , [new (9,5),new (9,6),new (9,7)]) , parts[9]);
    }
}
