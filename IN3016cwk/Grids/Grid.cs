using System.Collections.Generic;
using IN3016cwk.Grids.Cells;

namespace IN3016cwk.Grids
{
    public class Grid : List<List<Cell>>
    {
        public Bot Bot { get; set; }

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

        public bool ContainsCell(int row, int column)
        {
            return row >= 0 && row < Count && column >=0 && column < this[row].Count;
        }

        public int RowCount => Count;

        public int ColumnCount => this[0].Count;
    }
}
