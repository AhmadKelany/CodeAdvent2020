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
