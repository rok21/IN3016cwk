using System.Collections.Generic;
using IN3016cwk.Grids;

namespace IN3016cwk
{
    class QMatrix : Dictionary<Point, Dictionary<Point, int>>
    {
        public QMatrix(Grid grid)
        {
            foreach (var row in grid)
            {
                foreach (var cell in row)
                {
                    Add(cell, new Dictionary<Point, int>());
                    foreach (var row1 in grid)
                    {
                        foreach (var cell1 in row1)
                        {
                            this[cell].Add(cell1, 0);
                        }
                    }
                }
            }
        }
    }
}
