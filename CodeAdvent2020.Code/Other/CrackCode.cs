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
        /* In this dictionary, the key is the digit of the final solution, the value is the index of that digit in the final solution
         * e.g. if the final solution is: 042, we want the dictionary to be {0(this is the digit) : 0(this is the index of the digit in the solution) , 4:1 , 2:2} */
        Dictionary<int, int> result = new();


        Clue allWrongClue = clues.First(c => c.CorrectNumberCount == 0 && c.CorrectPlaceCount == 0);
        HashSet<int> wrongNumbers = allWrongClue.Numbers.ToHashSet();
        clues.Remove(allWrongClue);


        List<int> positions = new() { 0, 1, 2 };
        List<NumberPositions> numberPositionsInfos = new();
        List<int> uniqueNumbers = clues.SelectMany(c => c.Numbers).Where(n => !wrongNumbers.Contains(n)).Distinct().ToList();


        foreach (int number in uniqueNumbers)
        {
            NumberPositions numberPosistions = new NumberPositions { Number = number, RightPosition = -1 }; // -1 index indicate that the index is unknow
            numberPositionsInfos.Add(numberPosistions);
            foreach (var clue in clues)
            {
                if (!clue.Numbers.Contains(number)) continue;
                int index = Array.IndexOf(clue.Numbers, number);
                switch (clue.CorrectPlaceCount)
                {
                    case 1:
                        numberPosistions.RightPosition = index;
                        break;
                    default:
                        numberPosistions.WrongPositions.Add(index);
                        break;
                }

            }


        }

        numberPositionsInfos = numberPositionsInfos.
            Where(n => !n.WrongPositions.Contains(n.RightPosition) &&
                                            !(n.WrongPositions.Count == 0)).
            ToList();

        NumberPositions firstNumberPositionInfo = numberPositionsInfos.First(n => n.RightPosition != -1 && !wrongNumbers.Contains(n.Number));
        result[firstNumberPositionInfo.Number] = firstNumberPositionInfo.RightPosition;


        NumberPositions secondNumberPositionInfo = numberPositionsInfos.First(n => n.WrongPositions.Count == 2);
        result[secondNumberPositionInfo.Number] = positions.Except(secondNumberPositionInfo.WrongPositions).Single();

        IEnumerable<Clue> cluesWithOneCorrectDigitThatIsOneOfFoundDigits = clues.
            Where(c => c.CorrectNumberCount == 1 &&
            c.CorrectPlaceCount == 0 &&
            (c.Numbers.Contains(firstNumberPositionInfo.Number) || c.Numbers.Contains(secondNumberPositionInfo.Number)));

        foreach (var c in cluesWithOneCorrectDigitThatIsOneOfFoundDigits) 
        {
            // in a clue that has one correct digit and has one of the two solution digits we discoverd, the remaining digits in that clue are obviously wrong
            IEnumerable<int> digitsOtherThanTheCorrectDigits = c.Numbers.Where(n => n != firstNumberPositionInfo.Number && n != secondNumberPositionInfo.Number);
            foreach (int d in digitsOtherThanTheCorrectDigits)
            {
                wrongNumbers.Add(d);
            }
        }
        positions.Remove(result[firstNumberPositionInfo.Number]);
        positions.Remove(result[secondNumberPositionInfo.Number]);
        numberPositionsInfos.Remove(firstNumberPositionInfo);
        numberPositionsInfos.Remove(secondNumberPositionInfo);
        NumberPositions thirdNumberPositionInfo = numberPositionsInfos.
            Where(n => !wrongNumbers.Contains(n.Number) &&
            n.WrongPositions.Intersect(positions).Count() == 0).
            First();
        result[thirdNumberPositionInfo.Number] = positions[0];
        return string.Concat(result.OrderBy(d => d.Value).ToDictionary(d => d.Key, d => d.Value).Select(d => d.Key));
    }
}
