using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CodeAdvent.Code.Other;

namespace CodeAdvent.Tests.OtherTests;

public class LongestCommonSubsequenceTests
{
    [Fact]
    public void LCS()
    {
        Assert.Equal("helod", LongestCommonSubsequence.GetLongestCommonSubsequence("hello world", "ohelod"));
    }
}
