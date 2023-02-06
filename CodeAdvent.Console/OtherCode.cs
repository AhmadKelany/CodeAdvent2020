using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent.UI;

public class OtherCode
{
    public static void ShowLCSArray()
    {
        string s1 = "helloworld";
        string s2 = "ohelod";
        var a = CodeAdvent.Code.Other.LongestCommonSubsequence.GetArray(s1, s2);
        var table = new Table();
        table.AddColumn("/");
        table.AddColumn("/");
        for (int i = 0; i < s1.Length+1; i++)
        {
            table.AddColumn($"[red]{i}[/]");
        }
        string[] row = new string[s1.Length + 3];
        row[0] = "/";
        row[1] = "/";       
        row[2] = "/";       
        for (int i = 0; i < s1.Length; i++)
        {
            row[i + 3] = s1[i].ToString();
        }

        
        
        
        
        table.AddRow(row);
        table.AddRow(row.Select(v => "0").ToArray());
        for (int i = 1; i < a.Length ; i++)
        {
            table.AddRow(row.Select((x,index) => index switch {
                0 => $"{i}",
                1 => s2[i-1].ToString(),               
                _ => a[i][index-2].ToString(),
             }).ToArray());
        }
        AnsiConsole.Write(table);
        
    }
}
