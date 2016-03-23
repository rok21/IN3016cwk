using System.Collections.Generic;
using IN3016cwk.Grids.Cells;

namespace IN3016cwk.Grids
{
    public class Grid : List<List<Cell>>
    {
        public void AddCell(Cell cell)
        {
            while(cell.Y >= Count)
            {
                Add(new List<Cell>());
            }

            this[cell.Y].Add(cell);
        }

        public Cell GetCell(int row, int column)
        {
            return this[row][column];
        }

        public Point GetCurrPoint(Bot bot)
        {
            return this[bot.Y][bot.X];
        }

        public bool ContainsCell(int row, int column)
        {
            return row >= 0 && row < Count && column >=0 && column < this[row].Count;
        }

        public List<Cell> GetAdjecantCells(Point p)
        {
            var adjecant = new List<Cell>();
            if (p.X > 0)
                adjecant.Add(this[p.Y][p.X-1]);
            if(p.Y > 0)
                adjecant.Add(this[p.Y - 1][p.X]);
            if (p.X < ColumnCount-1)
                adjecant.Add(this[p.Y][p.X + 1]);
            if (p.Y < RowCount)
                adjecant.Add(this[p.Y + 1][p.X]);

            return adjecant;
        }

        public int RowCount => Count;

        public int ColumnCount => this[0].Count;
    }
}
