using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent.Code._2024;

public static class Day4
{
    static string[] GetInput() => File.ReadAllLines("2024/InputFiles/Day4.txt");
    static string[] GetSampleInput() => File.ReadAllLines("2024/InputFiles/Day4Sample.txt");
    static char[][] GetMatrix(string[] input)
    {
        char[][] matrix = new char[input.Length][];
        for (int i = 0; i < input.Length; i++)
        {
            matrix[i] = input[i].ToArray();
        }
        return matrix;
    }

    static bool IsValidX(char[][] matrix, int x, int y)
    {
        char topLeft = matrix[y - 1][x - 1];
        char topRight = matrix[y - 1][x + 1];
        char bottomLeft = matrix[y + 1][x - 1];
        char bottomRight = matrix[y + 1][x + 1];
        char[] chars = new char[] { topLeft, topRight, bottomLeft, bottomRight };
        if (chars.Any(c => c is 'X' or 'A')) return false;
        return topLeft != bottomRight && topRight != bottomLeft;
    }

    static int GetPossibleCount(char[][] matrix, int x,int y)
    {
        int count = 0;

        int xStart = x < 3 ? x : x - 3;
        int xEnd = x >= matrix[0].Length - 3 ? x : x + 3;

        int yStart = y < 3 ? y : y - 3;
        int yEnd = y >= matrix.Length - 3 ? y : y + 3;
        for (int xc = xStart; xc <= xEnd; xc += 3)
        {
            for(int yr = yStart; yr <= yEnd; yr += 3)
            {
                if (matrix[yr][xc] == 'S')
                {
                    int xFactor = Math.Sign(xc - x);
                    int yFactor = Math.Sign(yr - y);
                    int ax = x + (xFactor * 2);
                    int ay = y + (yFactor * 2);
                    int mx = x + xFactor;
                    int my = y + yFactor;
                    char achar = matrix[ay][ax];
                    char mchar = matrix[my][mx];
                    if (achar == 'A' && mchar == 'M')
                    {
                        count++;
                    }
                }
            }
        }

        return count;
    }
    public static void Part1()
    {
        string[] input = GetInput();
        char[][] matrix = GetMatrix(input);
        int count = 0;
        for (int y = 0; y < matrix.Length; y++)
        {
            for (int x = 0; x < matrix[y].Length; x++)
            {
                if (matrix[y][x] == 'X')
                {
                    count += GetPossibleCount(matrix, x, y);
                }
            }
        }
        Screen.WriteLine($"Part 1 Result = {count}", ConsoleColor.Cyan);
    }

    public static void Part2()
    {
        string[] input = GetInput();
        char[][] matrix = GetMatrix(input);
        int count = 0;
        for (int y = 1; y < matrix.Length-1; y++)
        {
            for (int x = 1; x < matrix[y].Length-1; x++)
            {
                if (matrix[y][x] == 'A')
                {
                    if (IsValidX(matrix, x, y))
                    {
                        count++;
                    }
                }
            }
        }
        Screen.WriteLine($"Part 2 Result = {count}", ConsoleColor.Cyan);
    }
}
