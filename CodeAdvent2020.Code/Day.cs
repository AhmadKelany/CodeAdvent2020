using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent.Code;

public abstract class Day
{
    public static string GetInputPath(Type type)
    {
        return $"{GetNamespaceYear(type)}/InputFiles/Day{GetClassNameDay(type)}.txt";
    }

    public static string GetSampleInputPath(Type type)
    {
        return $"{GetNamespaceYear(type)}/InputFiles/Day{GetClassNameDay(type)}Sample.txt";
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