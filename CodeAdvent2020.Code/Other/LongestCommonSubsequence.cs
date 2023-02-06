using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent.Code.Other;

public class LongestCommonSubsequence
{
    public static string GetLongestCommonSubsequence(string s1, string s2)
    {
        
        int[][] a = GetArray(s1,s2);
        int columnIndex = a[0].Length - 1;
        int rowIndex = a.Length - 1;
        string solution = "";
        while (columnIndex > 0 && rowIndex > 0)
        {
            int current = a[rowIndex][columnIndex];
            int left = a[rowIndex][columnIndex - 1];
            int top = a[rowIndex - 1][columnIndex];
            if (current > left)
            {
                if (current == top)
                {
                    rowIndex--;
                    columnIndex--;
                    continue;
                }
                else
                {
                    solution = $"{s1[columnIndex - 1]}{solution}";
                    rowIndex--;
                    columnIndex--;
                    continue;
                }
            }
            columnIndex--;
        }
        return solution;
    }

    public static int[][] GetArray(string s1, string s2)
    {
        
        s1 = " " + s1;
        s2 = " " + s2;
        int n = s1.Length;
        int m = s2.Length;
        int[][] a = new int[m][];
        for (int i = 0; i < m; i++)
        {
            a[i] = new int[n];
        }
        for (int r = 0; r < m ; r++)
        {
            for (int c = 0; c < n ; c++)
            {
                if (r == 0 || c == 0)
                {
                    a[r][c] = 0;
                }
                else if (s1[c] == s2[r])
                {
                    a[r][ c] = a[r - 1][ c - 1] + 1;
                }
                else
                {
                    a[r][c] = Math.Max(a[r - 1][c], a[r][c - 1]);
                }
            }
        }
        return a;
    }
}
