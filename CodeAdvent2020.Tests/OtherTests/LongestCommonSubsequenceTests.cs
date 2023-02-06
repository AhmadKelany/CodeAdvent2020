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
    [Theory]
    [InlineData("helod" , "hello world" , "ohelod")]
    [InlineData("elwrd" , "hello world" ,  "elwrd")]
    public void LCS(string expected,string first , string second)
    {
        Assert.Equal(expected, LongestCommonSubsequence.GetLongestCommonSubsequence(first, second));
    }
}
