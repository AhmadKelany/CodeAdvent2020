using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent.Code.Other
{
    public class NumberPositions
    {
        public int Number { get; set; }
        public int RightPosition { get; set; }
        public HashSet<int> WrongPositions { get; set; } = new();
        public override string ToString()
        {
            return $"n={Number}, right={RightPosition}, wrong={string.Join(',',WrongPositions)}";
        }
    }
}
