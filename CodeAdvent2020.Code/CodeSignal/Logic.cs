using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2020.Code.CodeSignal
{
    public class Logic
    {
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
