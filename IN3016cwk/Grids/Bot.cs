using System;
using System.Collections.Generic;
using IN3016cwk.Grids.Cells;

namespace IN3016cwk.Grids
{
    public class Bot : Point
    {
        private Grid grid;
        private QMatrix qMatrix;

        private double discountFactor = 0.8;
        private double learningRate = 1.0;

        public Bot(Grid grid)
        {
            this.grid = grid;
            qMatrix = new QMatrix(grid);
        }

        public void Learn()
        {
            var nextCell = ChooseRandom(grid.GetAdjecantCells(this));


        }

        private void UpdateQMatrix(Cell nextCell)
        {
            qMatrix[grid.GetCurrPoint(this)][nextCell] = 
        }

        private Cell ChooseRandom(List<Cell> cells)
        {
            var rand = new Random();
            return cells[rand.Next(cells.Count - 1)];
        }
    }
}
