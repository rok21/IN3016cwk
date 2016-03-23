using System;
using System.Collections.Generic;
using IN3016cwk.Grids.Cells;

namespace IN3016cwk.Grids
{
    using System.Linq;

    public class Bot : Point
    {
        private Grid grid;
        public QMatrix qMatrix { get; set; }

        private double discountFactor = 0.8;
        private double learningRate = 1.0;

        public Bot(Grid grid)
        {
            this.grid = grid;
            qMatrix = new QMatrix(grid);
        }

        public void Learn()
        {
            for (int i = 0; i < 1000; i++)
            {
                var nextCell = ChooseRandom(grid.GetAdjecantCells(this));
                UpdateQMatrix(nextCell);
                X = nextCell.X;
                Y = nextCell.Y;
            }
        }

        private void UpdateQMatrix(Cell nextCell)
        {
            var oldQValue = qMatrix[grid.GetCurrPoint(this)][nextCell];

            var maxNextQValue = grid.GetAdjecantCells(nextCell).Where(x => x.CanStepIn()).Max(x => x.GetReward());

            qMatrix[grid.GetCurrPoint(this)][nextCell] = oldQValue + learningRate * ((nextCell.GetReward() + discountFactor * maxNextQValue) - oldQValue);
        }

        private Cell ChooseRandom(List<Cell> cells)
        {
            var rand = new Random();
            return cells[rand.Next(cells.Count - 1)];
        }
    }
}
