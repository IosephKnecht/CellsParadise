using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellsParadise
{
    delegate void pushQueue(ICell cell);

    class Epoch
    {
        ICell[,] cells;

        List<ICell> queueCells;

        static Epoch epoch;

        pushQueue push;

        protected Epoch(int width,int height)
        {
            cells = new ICell[width, height];
            queueCells = new List<ICell>();
            push = new pushQueue(pushQueue);

            cells[4, 3] = new LiveCell(4, 3,push);
            cells[4, 4] = new LiveCell(4, 4, push);
            cells[4, 5] = new LiveCell(4, 5, push);
            cells[4, 6] = new LiveCell(4, 6, push);
            cells[4, 7] = new LiveCell(4, 7, push);
        }

        public static Epoch Incstance(int width = 0, int height = 0)
        {
            if (epoch != null) return epoch;
            else
            {
                return epoch = new Epoch(width,height);
            }
        }

        private void pushQueue(ICell cell)
        {
            queueCells.Add(cell);
        }

        public void CalculEpoch()
        {
            for(int i=0;i<queueCells.Count;i++)
            {
                ICell cell = queueCells[i];

                cell.Search(ref cells);
            }

            for (int i = 0; i < queueCells.Count; i++)
            {
                ICell cell = queueCells[i];

                switch (cell.State)
                {
                    case 0:
                        cells[cell._X, cell._Y] = null;
                        queueCells.RemoveAt(i);
                        i--;
                        break;

                    case 1:
                        cells[cell._X, cell._Y] = new LiveCell(cell._X, cell._Y, push);
                        break;
                }
            }
            string a = null;
        }
    }
}
