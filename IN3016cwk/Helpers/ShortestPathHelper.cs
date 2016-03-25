using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using IN3016cwk.Grids;
using IN3016cwk.Grids.Cells;

namespace IN3016cwk.Helpers
{
    public class ShortestPathHelper
    {
        public static int GetMinStepCount(Bot bot)
        {
            var grid = bot.grid;
            var toBeChecked = new Queue<Cell>();
            var checkedCells = new Dictionary<Cell, bool>();
            var distances = new Dictionary<Cell, int>();
            var botCell = bot.grid.GetCell(bot.Y, bot.X);
            distances.Add(botCell, 0);
            toBeChecked.Enqueue(botCell);
            while (toBeChecked.Any())
            {
                var cell = toBeChecked.Dequeue();
                if (checkedCells.ContainsKey(cell))
                    continue;
                grid.GetAdjecantCells(cell).GoodCells().Where(c => !checkedCells.ContainsKey(c)).ForEach(toBeChecked.Enqueue);
                if (cell is PrincessCell)
                {
                    return distances[cell];
                }
                foreach (var adjecantCell in grid.GetAdjecantCells(cell).GoodCells())
                {
                    if(!distances.ContainsKey(adjecantCell))
                        distances.Add(adjecantCell, int.MaxValue);
                    distances[adjecantCell] = Math.Min(distances[adjecantCell], distances[cell] + 1);
                }
                checkedCells.Add(cell, true);
            }
            throw new Exception();
        }
    }
}
