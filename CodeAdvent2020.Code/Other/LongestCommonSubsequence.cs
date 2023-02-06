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
        
        return "lo";
    }

    public static int[][] GetArray(string s1, string s2)
    {
        int n = s1.Length + 1;
        int m = s2.Length + 1;
        int[][] a = new int[m][];
        for (int i = 0; i < m; i++)
        {
            a[i] = new int[n];
        }
        for (int r = 1; r < m - 1; r++)
        {
            for (int c = 1; c < n - 1; c++)
            {
                if (s1[c] == s2[r])
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
