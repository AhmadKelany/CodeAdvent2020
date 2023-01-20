using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent.Code.Other;

public class CrackCode
{
    
    public record Clue(int[] Numbers, int CorrectNumberCount, int CorrectPlaceCount);

    public static string Solve(List<Clue> clues)
    {
        Dictionary<int, int> result = new();
        List<int> wrongNumbers = clues.
        First(c => c.CorrectNumberCount == 0 && c.CorrectPlaceCount == 0).
        Numbers.ToList();
        clues = clues.Where(c => c.CorrectNumberCount > 0 || c.CorrectPlaceCount > 0).ToList();
        List<int> positions = new() { 0, 1, 2 };
        List<NumberPositions> numberIndixes = new();
        List<int> uniqueNumbers = clues.SelectMany(c => c.Numbers).Where(n => !wrongNumbers.Contains(n)).Distinct().ToList();
        foreach (int number in uniqueNumbers)
        {
            NumberPositions np = new NumberPositions { Number = number, RightPosition = -1 };
            numberIndixes.Add(np);
            foreach (var clue in clues)
            {

                if (clue.Numbers.Contains(number))
                {
                    int index = Array.IndexOf(clue.Numbers, number);
                    if (clue.CorrectPlaceCount == 1)
                    {
                        np.RightPosition = index;
                    }
                    else
                    {
                        np.WrongPositions.Add(index);
                    }
                }
            }


        }
        numberIndixes = numberIndixes.Where(n => !n.WrongPositions.Contains(n.RightPosition)).ToList();
        var firstNumber = numberIndixes.First(n => n.RightPosition != -1);
        result[firstNumber.Number] = firstNumber.RightPosition;
        var secondNumber = numberIndixes.First(n => n.WrongPositions.Count == 2);
        result[secondNumber.Number] = positions.Except(secondNumber.WrongPositions).Single();
        positions.Remove(result[firstNumber.Number]);
        positions.Remove(result[secondNumber.Number]);
        numberIndixes.Remove(firstNumber);
        numberIndixes.Remove(secondNumber);
        var thirdNumber = numberIndixes.Where(n => n.WrongPositions.Intersect(positions).Count() == 0).First();
        result[thirdNumber.Number] = positions[0];
        return string.Concat( result.OrderBy(d => d.Value).ToDictionary(d => d.Key, d => d.Value).Select(d => d.Key)) ;
    }
}
