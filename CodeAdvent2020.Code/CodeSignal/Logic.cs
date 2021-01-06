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

    }
}
