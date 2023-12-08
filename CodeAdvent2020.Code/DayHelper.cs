using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent.Code;

public static class DayHelper
{
    public static string GetInputPath(Type type)
    {
        string year = GetNamespaceYear(type);
        string day = GetClassNameDay(type);
        return $"{year}/InputFiles/Day{day}.txt";
    }

    public static string GetSampleInputPath(Type type)
    {
        string year = GetNamespaceYear(type);
        string day = GetClassNameDay(type);

        return $"{year}/InputFiles/Day{day}Sample.txt";
    }

    public static string[] GetInput(Type type)
    {
        return File.ReadAllLines(GetInputPath(type));
    }

    public static string[] GetSampleInput(Type type)
    {
        return File.ReadAllLines(GetSampleInputPath(type));
    }

    private static string GetNamespaceYear(Type type)
    {
        string fullName = type.Namespace;
        string[] parts = fullName.Split('.');
        return parts.Last();
    }

    private static string GetClassNameDay(Type type)
    {
        string fullName = type.Name;
        return fullName.Replace("Day", "");
    }
}