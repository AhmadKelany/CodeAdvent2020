using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent.Code._2023;

public class Day2
{
    static List<string> GetInput() => File.ReadAllLines("2023/InputFiles/Day2.txt").ToList();
    public static Cubes AvailabeCubesForPart1 => new Cubes(12, 13, 14);

    public record Cubes(int Red, int Green, int Blue);
    public class Game
    {
        public int Id { get; set; }
        public List<Cubes> Cubes { get; set; }
    }



    public static bool IsValidGame(Game game, Cubes availableCubes)
    {
        bool isInvalid = game.
            Cubes.
            Any(d => d.Red > availableCubes.Red ||
                             d.Green > availableCubes.Green ||
                             d.Blue > availableCubes.Blue);

        return !isInvalid;
    }


    public static Cubes GetMinimumRequiredCubes(IEnumerable<Cubes> draws)
    {
        return new Cubes(draws.Max(d => d.Red),
            draws.Max(d => d.Green),
            draws.Max(d => d.Blue));
    }


    public static int GetPowerOfCubes(Cubes cubes)
    {
        return cubes.Red * cubes.Green * cubes.Blue;
    }

    public static Game GetGame(string gameLine)
    {
        var parts = gameLine.Split(':');
        int gameId = int.Parse(parts[0].Substring(5));
        List<Cubes> cubes = parts[1].Split(';').Select(GetCubes).ToList();
        var game = new Game()
        {
            Id = gameId,
            Cubes = cubes,
        };
        return game;
    }
    public static Cubes GetCubes(string cubesText)
    {
        var parts = cubesText.Trim().Split(',');
        int red = 0, green = 0, blue = 0;
        foreach (string part in parts)
        {
            var valueAndColor = part.Trim().Split(' ');
            int value = int.Parse(valueAndColor[0]);
            string color = valueAndColor[1];
            switch(color)
            {
                case "red":
                    red = value;
                    break;
                case "green":
                    green = value;
                    break;
                case "blue":
                    blue = value;
                    break;
                    default:
                    throw new NotSupportedException("The text value is not supported.");
            }
        }
        return new(Red : red, Blue: blue, Green: green);
    }

    public static void Part1()
    {

        var validGames = GetInput().
            Select(GetGame).
            Where(g => IsValidGame(g, AvailabeCubesForPart1));

        int result = validGames.Sum(g => g.Id);
        Screen.WriteLine($"Part 1 Result = {result}", ConsoleColor.Green);

    }

    public static void Part2()
    {
        int result = GetInput().
            Select(GetGame).
            Select(g => GetMinimumRequiredCubes(g.Cubes)).
            Select(GetPowerOfCubes).
            Sum();

        Screen.WriteLine($"Part 2 Result = {result}", ConsoleColor.Green);

    }
}
