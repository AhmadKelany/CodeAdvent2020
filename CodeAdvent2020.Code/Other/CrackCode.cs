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
        Clue allWrongClue = clues.First(c => c.CorrectNumberCount == 0 && c.CorrectPlaceCount == 0);
        HashSet<int> wrongNumbers = allWrongClue.Numbers.ToHashSet();
        clues.Remove(allWrongClue);
        List<int> positions = new() { 0, 1, 2 };
        List<NumberPositions> numberPositionsInfos = new();
        List<int> uniqueNumbers = clues.SelectMany(c => c.Numbers).Where(n => !wrongNumbers.Contains(n)).Distinct().ToList();
        foreach (int number in uniqueNumbers)
        {
            NumberPositions np = new NumberPositions { Number = number, RightPosition = -1 };
            numberPositionsInfos.Add(np);
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
               
        numberPositionsInfos = numberPositionsInfos.
            Where(n =>   !n.WrongPositions.Contains(n.RightPosition) &&
                                              !(n.WrongPositions.Count == 0)).
            ToList();

        var firstNumber = numberPositionsInfos.First(n =>  n.RightPosition != -1 && !wrongNumbers.Contains(n.Number));
        result[firstNumber.Number] = firstNumber.RightPosition;
        var secondNumber = numberPositionsInfos.First(n => n.WrongPositions.Count == 2);
        result[secondNumber.Number] = positions.Except(secondNumber.WrongPositions).Single();
        foreach (var c in clues.
            Where(c => c.CorrectNumberCount == 1 &&
                               c.CorrectPlaceCount == 0 && 
                               (c.Numbers.Contains(firstNumber.Number) || c.Numbers.Contains(secondNumber.Number))))
        {
            var ns = c.Numbers.Where(n => n != firstNumber.Number && n != secondNumber.Number);
            foreach (var w in ns)
            {
                wrongNumbers.Add(w);
            }
        }
        positions.Remove(result[firstNumber.Number]);
        positions.Remove(result[secondNumber.Number]);
        numberPositionsInfos.Remove(firstNumber);
        numberPositionsInfos.Remove(secondNumber);
        var thirdNumber = numberPositionsInfos.
            Where(n => !wrongNumbers.Contains(n.Number) &&
                                            n.WrongPositions.Intersect(positions).Count() == 0).
                                            First();
        result[thirdNumber.Number] = positions[0];
        return string.Concat( result.OrderBy(d => d.Value).ToDictionary(d => d.Key, d => d.Value).Select(d => d.Key)) ;
    }
}
