using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static CodeAdvent.Code.Other.CrackCode;

namespace CodeAdvent.Tests.OtherTests;

public class CrackCodeTests
{
    [Fact]
    public void ShouldSolvePattern1()
    {
        List<Clue> clues = new() {
            new Clue(new int[]{6,8,2} ,CorrectNumberCount:1 ,CorrectPlaceCount:1) ,
            new Clue(new int[]{2,0,6} ,CorrectNumberCount:2 ,CorrectPlaceCount:0) ,
            new Clue(new int[]{6,1,4} ,CorrectNumberCount:1 ,CorrectPlaceCount:0) ,
            new Clue(new int[]{7,3,8} ,CorrectNumberCount:0 ,CorrectPlaceCount:0) ,
            new Clue(new int[]{7,8,0} ,CorrectNumberCount:1 ,CorrectPlaceCount:0) ,
        };
        string solution = Solve(clues);
        Assert.Equal("042", solution);
    }
    [Fact]
    public void ShouldSolvePattern2()
    {
        List<Clue> clues = new() {
            new Clue(new int[]{0,7,9} ,CorrectNumberCount:1 ,CorrectPlaceCount:1) ,
            new Clue(new int[]{9,6,8} ,CorrectNumberCount:2 ,CorrectPlaceCount:0) ,
            new Clue(new int[]{7,3,8} ,CorrectNumberCount:1 ,CorrectPlaceCount:0) ,
            new Clue(new int[]{1,0,5} ,CorrectNumberCount:0 ,CorrectPlaceCount:0) ,
            new Clue(new int[]{5,2,0} ,CorrectNumberCount:1 ,CorrectPlaceCount:0) ,
        };
        string solution = Solve(clues);
        Assert.Equal("289", solution);
    }
    [Fact]
    public void ShouldSolvePattern3()
    {
        List<Clue> clues = new() {
            new Clue(new int[]{2,9,1} ,CorrectNumberCount:1 ,CorrectPlaceCount:1) ,
            new Clue(new int[]{4,6,3} ,CorrectNumberCount:2 ,CorrectPlaceCount:0) ,
            new Clue(new int[]{2,4,5} ,CorrectNumberCount:1 ,CorrectPlaceCount:0) ,
            new Clue(new int[]{5,7,8} ,CorrectNumberCount:0 ,CorrectPlaceCount:0) ,
            new Clue(new int[]{5,6,9} ,CorrectNumberCount:1 ,CorrectPlaceCount:0) ,
        };
        string solution = Solve(clues);
        Assert.Equal("394", solution);
    }
}
