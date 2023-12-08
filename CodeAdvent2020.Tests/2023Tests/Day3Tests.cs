using CodeAdvent.Code;
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
        
        
        
        
        //Assert.Equal( new(467 , 0 , [0,1,2] ) , parts[0]);
        
        //Assert.Equal( new(114 , [new (0,5),new (0,6),new (0,7)]) , parts[1]);
        //Assert.Equal( new(35 , [new (2,2),new (2,3)]) , parts[2]);
        //Assert.Equal( new(633 , [new (2,6),new (2,7),new (2,8)]) , parts[3]);
        //Assert.Equal( new(617 , [new (4,0),new (4,1),new (4,2)]) , parts[4]);
        //Assert.Equal( new(58 , [new (5,7),new (5,8)]) , parts[5]);
        //Assert.Equal( new(592 , [new (6,2),new (6,3),new (6,4)]) , parts[6]);
        //Assert.Equal( new(755 , [new (7,6),new (7,7),new (7,8)]) , parts[7]);
        //Assert.Equal( new(664 , [new (9,1),new (9,2),new (9,3)]) , parts[8]);
        //Assert.Equal( new(598 , [new (9,5),new (9,6),new (9,7)]) , parts[9]);
    }


}
