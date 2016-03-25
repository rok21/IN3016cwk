using System;
using System.Collections.Generic;
using System.Linq;
using IN3016cwk.Grids.Cells;
using IN3016cwk.Helpers;

namespace IN3016cwk.Grids
{
    public class Bot : Point
    {
        public Grid grid { get; set; }
        public QMatrix qMatrix { get; set; }

        public double epsilon = 1;

        private double discountFactor = 0.8;
        private double learningRate = 1.0;

        public Bot(Grid grid)
        {
            this.grid = grid;
            qMatrix = new QMatrix(grid);
        }

        public int FindPrincess()
        {
            var stepCount = 0;
            while(!grid.GetCurrCell(this).IsFinal())
            {
                Move();
                stepCount++;
            }
            return grid.GetCurrCell(this) is IceKingCell ? -1 : stepCount;
        }

        private void Move()
        {
            var possibleMoves = grid.GetAdjecantCells(this).Where(cell => cell.CanStepIn()).ToList();
            var nextCell = ChooseNextCell(possibleMoves);
            UpdateQMatrix(nextCell);
            MoveTo(nextCell);
            //Console.WriteLine(GridStringHelper.GenerateGridString(grid, this));
        }

        private void UpdateQMatrix(Cell nextCell)
        {
            var oldQValue = qMatrix[grid.GetCurrCell(this)][nextCell];
            var movesFromNextCell = grid.GetAdjecantCells(nextCell);
            var maxQValueFromNextCell = movesFromNextCell.Where(c => c.CanStepIn()).Max(c => qMatrix[nextCell][c]);

            var predictionError = (nextCell.GetReward() + discountFactor*maxQValueFromNextCell) - oldQValue;

            qMatrix[grid.GetCurrCell(this)][nextCell] = oldQValue + learningRate*predictionError;
        }

        private void MoveTo(Cell cell)
        {
            X = cell.X;
            Y = cell.Y;
        }

        private Cell ChooseNextCell(List<Cell> cells)
        {
            var randomDouble = RandHelper.GetRand().NextDouble();
            var nextCell = randomDouble < epsilon ? ChooseRandom(cells) : ChooseHighestRewardValue(cells);
            UpdateEpsilon();
            return nextCell;
        }

        private Cell ChooseHighestRewardValue(List<Cell> cells)
        {
            return cells.Where(x => QValueToStepTo(x) == cells.Max(c => QValueToStepTo(c))).Random();
        }

        private double QValueToStepTo(Cell cell)
        {
            return qMatrix[grid.GetCurrCell(this)][cell];
        }

        private Cell ChooseRandom(List<Cell> cells)
        {
            return cells.Random();
        }

        private void UpdateEpsilon()
        {
            var k = epsilon >= 0.5 ? 0.99999 : 0.9999;
            epsilon *= k;
        }
    }
}
