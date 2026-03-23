using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_VT
{
    public class GameField
    {
        public int rows { get; set; }
        public int columns { get; set; }
        public Tower[,] grid;
    }
}
