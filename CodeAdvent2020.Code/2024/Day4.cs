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
    static void GetPossibleCount(int[][] matrix, int x,int y)
    {
        int count = 0;
        int startX = x <= 3 ? 0 : x - 3;
        int endX = x >= matrix[0].Length - 3 ? matrix[0].Length : x + 3;
        int startY = y <= 3 ? 0 : y - 3;
        int endY = y >= matrix.Length - 3 ? matrix.Length : y + 3;
        for (int c = startX; c <= endX; c++)
        {
            for(int r = startY; r <= endY; r++)
            {
                
            }
        }
    }
}
