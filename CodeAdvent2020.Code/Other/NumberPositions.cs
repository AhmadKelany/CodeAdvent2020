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
        public List<int> WrongPositions { get; set; } = new();
    }
}
