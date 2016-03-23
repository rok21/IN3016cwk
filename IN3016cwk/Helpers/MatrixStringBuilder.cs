﻿using System.Text;
using IN3016cwk.Grids;

namespace IN3016cwk.Helpers
{
    class MatrixStringBuilder
    {
        public static string GenerateRewardMatrix(Grid grid)
        {
            var matrixBuilder = new StringBuilder();
            matrixBuilder.AppendLine(GetHeaderRow(grid));
            for (var y = 0; y < grid.RowCount; y++)
            {
                for (var x = 0; x < grid.ColumnCount; x++)
                {
                    var cell = grid.GetCell(y, x);
                    var rowBuilder = new StringBuilder();
                    rowBuilder.AppendFormat("{0}\t", cell);
                    for (var y1 = 0; y1 < grid.RowCount; y1++)
                    {
                        for (var x1 = 0; x1 < grid.ColumnCount; x1++)
                        {
                            var otherCell = grid.GetCell(y1, x1);
                            if (!cell.IsAdjecant(otherCell) || !otherCell.CanStepIn())
                            {
                                rowBuilder.AppendFormat("-\t");
                            }
                            else
                            {
                                rowBuilder.AppendFormat("{0}\t", otherCell.GetReward());
                            }
                        }
                    }
                    matrixBuilder.AppendLine(rowBuilder.ToString());
                }
            }

            return matrixBuilder.ToString();
        }

        public static string GenerateQMatrixString(QMatrix qMatrix)
        {
            var matrixBuilder = new StringBuilder();
            matrixBuilder.AppendLine(GetHeaderRow(qMatrix));
            foreach (var cell in qMatrix.Keys)
            {
                var rowBuilder = new StringBuilder();
                rowBuilder.AppendFormat("{0}\t", cell);
                foreach (var otherCell in qMatrix[cell].Keys)
                {
                    rowBuilder.AppendFormat("{0}\t", qMatrix[cell][otherCell]);
                }
                matrixBuilder.AppendLine(rowBuilder.ToString());
            }
            return matrixBuilder.ToString();
        }


        private static string GetHeaderRow(QMatrix qMatrix)
        {
            var rowBuilder = new StringBuilder();
            rowBuilder.Append("\t");
            foreach(var cell in qMatrix.Keys)
            {
                rowBuilder.AppendFormat("{0}\t", cell);
            }

            return rowBuilder.ToString();
        }

        private static string GetHeaderRow(Grid grid)
        {
            var rowBuilder = new StringBuilder();
            rowBuilder.Append("\t");
            for (var y = 0; y < grid.RowCount; y++)
            {
                for (var x = 0; x < grid.ColumnCount; x++)
                {
                    rowBuilder.AppendFormat("{0}\t", grid.GetCell(y, x));
                }
            }
            return rowBuilder.ToString();
        }
    }
}