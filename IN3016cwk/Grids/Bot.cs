using System;
using System.Collections.Generic;
using System.Linq;
using IN3016cwk.Grids.Cells;
using IN3016cwk.Helpers;

namespace IN3016cwk.Grids
{
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
            for(int i = 0; i < 1000; i++)
            {
                var possibleMoves = grid.GetAdjecantCells(this).Where(cell => cell.CanStepIn()).ToList();
                var nextCell = ChooseRandom(possibleMoves);
                UpdateQMatrix(nextCell);
                X = nextCell.X;
                Y = nextCell.Y;
                Console.WriteLine(GridStringHelper.GenerateGridString(grid, this));
            }

        }

        private void UpdateQMatrix(Cell nextCell)
        {
            if (nextCell.GetChar() == 'p')
            {
                Console.WriteLine("yay!!");
            }
            var oldQValue = qMatrix[grid.GetCurrPoint(this)][nextCell];
            qMatrix[grid.GetCurrPoint(this)][nextCell] = oldQValue +
                                                         learningRate*
                                                         ((nextCell.GetReward() +
                                                           discountFactor*
                                                           grid.GetAdjecantCells(nextCell)
                                                               .Where(c => c.CanStepIn())
                                                               .Max(c => qMatrix[nextCell][c])) - oldQValue);
        }

        private Cell ChooseRandom(List<Cell> cells)
        {
            var rand = new Random();
            return cells[rand.Next(cells.Count)];
        }
    }
}
