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
    static int GetPossibleCount(char[][] matrix, int x,int y)
    {
        int count = 0;
        for (int c = x < 3 ? x : x - 3; c <= (x >= matrix[0].Length -3 ? x : x + 3); c += 3)
        {
            for(int r = y < 3 ? y : y - 3; r <=(y >= matrix.Length - 3 ? y : y + 3); r += 3)
            {
                if (matrix[r][c] == 'S')
                {
                    int xFactor = Math.Sign(r - x);
                    int yFactor = Math.Sign(c - y);
                    if (matrix[x + xFactor * 2][y+ yFactor * 2] == 'A' && matrix[x + xFactor ][y + yFactor ] == 'M')
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
        string[] input = GetSampleInput();
        char[][] matrix = GetMatrix(input);
        int count = 0;
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                if (matrix[i][j] == 'X')
                {
                    count += GetPossibleCount(matrix, i, j);
                }
            }
        }
        Screen.WriteLine($"Part 1 Result = {count}", ConsoleColor.Cyan);
    }

}
