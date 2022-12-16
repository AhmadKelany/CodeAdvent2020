using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CodeAdvent.Tests._2022Tests;

public class Day1Tests
{
    [Fact]
    public void Part1ShouldWork()
    {
        int i = CodeAdvent.Code._2022.Day1.Part1();
        Assert.Equal(0,i);  
    }
}
