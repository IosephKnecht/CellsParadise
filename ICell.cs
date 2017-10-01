using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellsParadise
{
    interface ICell
    {
        void Search(ref ICell[,] cells);

        sbyte State { get; }

        int _X { get; }

        int _Y { get; }
    }
}
