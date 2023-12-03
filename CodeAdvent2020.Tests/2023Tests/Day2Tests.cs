using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAdvent.Code._2023;

using Xunit;
using static CodeAdvent.Code._2023.Day2;

namespace CodeAdvent.Tests._2023Tests;

public class Day2Tests
{
    [Theory]
    [InlineData("3 green, 6 red" , 6,3,0)]
    [InlineData("3 green, 4 blue, 1 red", 1 , 3 , 4)]
    public void GetDrawTest(string drawText , int red , int green , int blue)
    {
        Assert.Equal(new Cubes(red, green, blue), GetCubes(drawText));
    }

    [Fact]
    public void GetGameTest()
    {
        string line = "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red";
        Game game = GetGame(line);
        Assert.Equal(4, game.Id);
        Assert.Equal(3, game.Cubes.Count);
        Assert.Equal(new(3 , 1, 6), game.Cubes[0]);
        Assert.Equal(new(6 , 3, 0), game.Cubes[1]);
        Assert.Equal(new(14 , 3 , 15), game.Cubes[2]);
    }
   
    [Theory]
    [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", true)]
    [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", true)]
    [InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", false)]
    [InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red" , false)]
    [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", true)]
    public void IsValidGameTest(string gameLine, bool isValidExpected)
    {
        Game game = GetGame(gameLine);
        bool isValidActual = IsValidGame(game , Day2.AvailabeCubesForPart1);
        Assert.Equal(isValidExpected, isValidActual);
    }

    [Fact]
    public void GetPowerOfDrawTest()
    {
        Cubes draw = new(14, 5, 3);
        Assert.Equal(210, GetPowerOfCubes(draw));
    }

    [Theory]
    [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 48)]
    [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", 12)]
    [InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", 1560)]
    [InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", 630)]
    [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", 36)]
    public void GetMinimumRequiredCubesPowerTest(string gameLine , int expectedPower)
    {

        Game game = GetGame(gameLine);
        Cubes minimumRequiredCubes = GetMinimumRequiredCubes(game.Cubes);
        int actualPower = GetPowerOfCubes(minimumRequiredCubes);
        Assert.Equal(expectedPower, actualPower);
    }
}
