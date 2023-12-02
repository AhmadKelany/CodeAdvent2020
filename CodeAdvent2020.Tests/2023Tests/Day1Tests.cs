using CodeAdvent.Code._2023;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace CodeAdvent.Tests._2023Tests;

public class Day1Tests
{
    
    [Theory]
    [InlineData("1abc2" , 12)]
    [InlineData("pqr3stu8vwx" , 38)]
    [InlineData("a1b2c3d4e5f" , 15)]
    [InlineData("treb7uchet" , 77)]
    public void GetNumberShouldReturnFirstAndLastDigitCombined(string line, int expectedResult)
    {
        int actual = Day1.GetNumber(line);
        Assert.Equal(expectedResult, actual);
    }
    
    [Theory]
    [InlineData("two1nine" , "2wo19ine")]
    [InlineData("abcone2threexyz", "abc1ne23hreexyz")]
    [InlineData("xtwone3four", "x2wone34our")]
    [InlineData("4nineeightseven2", "49ineeight7even2")]
    [InlineData("zoneight234", "z1n8ight234")]
    [InlineData("7pqrstsixteen", "7pqrst6ixteen")]
    [InlineData("twone", "2w1ne")]
    public void GetModifiedLineShouldReplaceFirstAndLastNumberWordsWithDigits(string line, string expectedResult)
    {
        string actual = Day1.GetModifiedLine(line);
        Assert.Equal(expectedResult, actual);
    }
    // 29, 83, 13, 24, 42, 14, and 76
    [Theory]
    [InlineData("two1nine" , 29)]
    [InlineData("eightwothree", 83)]
    [InlineData("abcone2threexyz", 13)]
    [InlineData("xtwone3four", 24)]
    [InlineData("4nineeightseven2", 42)]
    [InlineData("zoneight234", 14)]
    [InlineData("7pqrstsixteen", 76)]
    public void GetModifiedLineShouldReturnCorrectNumbers(string line, int expectedResult)
    {
        string modified = Day1.GetModifiedLine(line);
        int actualResult = Day1.GetNumber(modified);
        Assert.Equal(expectedResult, actualResult);
    }
}
