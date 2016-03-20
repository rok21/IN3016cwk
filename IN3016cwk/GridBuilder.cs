using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using IN3016cwk.Grids;
using IN3016cwk.Grids.Cells;

namespace IN3016cwk
{
    public class GridBuilder
    {
        public static Grid BuildGrid(string input)
        {
            var rows = input.Split('\n').Select(ln => ln.Trim());

            var grid = new Grid();

            var y = 0;
            foreach(var row in rows)
            {
                var x = 0;
                foreach (var cellChar in row)
                {
                    var cell = CreateCell(cellChar);
                    cell.X = x;
                    cell.Y = y;
                    grid.AddCell(cell);

                    x++;
                }
                y++;
            }

            return grid;
        }

        private static Cell CreateCell(char cellChar)
        {
            switch (cellChar)
            {
                case 'x': 
                    return new ObstacleCell();
                case 'p':
                    return new PrincessCell();
                case 'k':
                    return new IceKingCell();
                default:
                    return new FreeCell();
            }
        }
    }
}
