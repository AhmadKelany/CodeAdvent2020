using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2020.Code.CodeSignal
{
    public class Logic
    {
        public static int numbersGrouping(int[] a)
        {
            var groups = a.GroupBy(i =>   (i-1)/10_000 );
            return a.Count() + groups.Count();
        }

        public static int mostFrequentDigitSum(int n)
        {
            var l = new List<int>();
            while (n > 0)
            {
                l.Add(n);
                n = n - digitSUm(n);
            }
            return l.Select(digitSUm).GroupBy(x => x).OrderByDescending(g => g.Count()).ThenByDescending(g => g.Key).First().Key;
        }

        static int digitSUm(int x) => $"{x}".Sum(c => int.Parse($"{c}"));


        public static int constructSquare(string s)
        {
            int minSquare = (int)Math.Pow(10,s.Length-1);
            int maxSquare = (int)Math.Pow(10, s.Length ) - 1;
            int minNum = (int)Math.Sqrt(minSquare);
            int maxNum = (int)Math.Sqrt(maxSquare);
            for (int i = maxNum; i >= minNum; i--)
            {
                int sqr =(int)Math.Pow(i, 2);
                string sqrString = $"{sqr}";
                var sCounts = s.GroupBy(c => c).Select(g => g.Count()).OrderBy(x => x).Aggregate("" ,(s , x) => s + $"{x}");
                var sqrCounts = sqrString.GroupBy(c => c).Select(g => g.Count()).OrderBy(x => x).Aggregate("" ,(s , x) => s + $"{x}");
                if (sqrCounts == sCounts)
                {
                    return sqr;
                }
            }
            return -1;
        }

        public static bool isSubstitutionCipher(string s1, string s2)
        {
            if (s1.Distinct().Count() == s1.Length && s2.Distinct().Count() == s2.Length) return true;
            var r = verify(s1, s2);
            return r ? verify(s2, s1) : r;
        }


        static bool verify(string s1, string s2)
        {
            bool result = true;
            for (int i = 0; i < s1.Length; i++)
            {
                var a = s1[i];
                var b = s2[i];
                var aindexes = s1.Select((c, i) => c == a ? i : -1).Where(i => i >= 0);
                result = s2.Where((c, i) => aindexes.Contains(i)).All(c => c == b);
                if (!result) return result;
            }
            return result;
        }

        public static bool isUnstablePair(string f1, string f2)
        {



            var m = Math.Min(f1.Length, f2.Length);
            int index = -1;
            for (int i = 0; i < m; i++)
            {
                if (f1[i] != f2[i])
                {
                    index = i;
                    break;
                }
            }
            if(index == -1)
            {
                return false;
            }
            else
            {
                return f1[index] < f2[index] ? string.Compare(f1,f2) > 0 : string.Compare(f2, f1) > 0;
            }
            
        }

        public static int candles(int candlesNumber, int makeNew)
        {
            int leftCount = 0;
            int burnCount = 0;
            do
            {
                burnCount += candlesNumber;
                leftCount += candlesNumber;
                candlesNumber = leftCount / makeNew;
                leftCount -= candlesNumber * makeNew;
            } while (candlesNumber > 0 );

            return burnCount;
        }

        public static int crosswordFormation(string[] words)
        {
            var formations = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        for (int l = 0; l < 4; l++)
                        {
                            var f = new List<int> { i, j, k, l };
                            if (f.Distinct().Count() != 4) continue;
                            formations += GetPossibleFormations(words[i], words[j], words[k], words[l]);
                        }
                    }
                }
            }





            return formations;
        }
        public static int GetPossibleFormations(string h1 , string h2 , string v1 , string v2)
        {
            var formations = 0;
            for(int ih1 = 0; ih1 < h1.Length; ih1++) 
            {
                for(int iv1 = 0; iv1 < v1.Length; iv1++)
                {
                    if (h1[ih1] == v1[iv1])
                    {
                        for (int i2v1 = iv1+2; i2v1 < v1.Length; i2v1++)
                        {
                            for (int ih2 = 0; ih2 < h2.Length; ih2++)
                            {
                                if (v1[i2v1] == h2[ih2])
                                {
                                    int height = i2v1 - iv1;
                                    for (int i2h2 = ih2  +2 ; i2h2 < h2.Length; i2h2++)
                                    {
                                        for (int iv2 = v2.Length-1; iv2  >= height; iv2 --)
                                        {
                                            if (h2[i2h2] == v2[iv2] )
                                            {
                                                int width = i2h2 - ih2;
                                                if (ih1+width < h1.Length && h1[ih1+width] == v2[iv2-height] )
                                                {
                                                    formations++;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return formations;
        }

    }
}
