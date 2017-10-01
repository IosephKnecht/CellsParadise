using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellsParadise
{
    class FutureCell:ICell
    {
        int X;
        int Y;

        sbyte state = -1;

        public FutureCell(int X,int Y,pushQueue push)
        {
            this.X = X;
            this.Y = Y;
            push(this);
        }

        public void Search(ref ICell[,] cells)
        {
            KeyValuePair<int, int>[] positions = new KeyValuePair<int, int>[8];

            positions[0] = new KeyValuePair<int, int>(X + 1, Y);
            positions[1] = new KeyValuePair<int, int>(X - 1, Y);
            positions[2] = new KeyValuePair<int, int>(X, Y + 1);
            positions[3] = new KeyValuePair<int, int>(X, Y - 1);
            positions[4] = new KeyValuePair<int, int>(X + 1, Y + 1);
            positions[5] = new KeyValuePair<int, int>(X + 1, Y - 1);
            positions[6] = new KeyValuePair<int, int>(X - 1, Y + 1);
            positions[7] = new KeyValuePair<int, int>(X - 1, Y - 1);

            int neighbors = 0;

            for (int i = 0; i < 8; i++)
            {
                if (cells[positions[i].Key,positions[i].Value] != null&&
                    cells[positions[i].Key,positions[i].Value].GetType() != this.GetType()) neighbors++;

            }

            if (neighbors == 3) state = 1; else state = 0;
        }

        public sbyte State { get { return state; } }

        public int _X { get { return X; } }
        public int _Y { get { return Y; } }
    }
}
