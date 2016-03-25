using System;
using System.Text;
using IN3016cwk.Grids;
using IN3016cwk.Helpers;

namespace IN3016cwk
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputStr = IoHelper.GetInput();
            var grid = GridBuilder.BuildGrid(inputStr);
            var bot = new Bot(grid);
            var sb = new StringBuilder();
            for (var i = 0; i < 100000; i++)
            {
                BotPosHelper.PlaceBot(bot);
                var shortestPath = ShortestPathHelper.GetMinStepCount(bot);
                var botSteps = bot.FindPrincess();
                if (botSteps > -1)
                    sb.AppendFormat("{0:0.00}\n", botSteps / ((double)shortestPath));
                
            }
            OutputQMatrix(bot.qMatrix);
            IoHelper.OuputText(sb.ToString(), "performace.txt");
            OutputProperQMatrix(bot);
        }

        private static void OutputProperQMatrix(Bot bot)
        {
            var matrixStr = MatrixStringBuilder.GenerateProperQMatrix(bot.grid, bot.qMatrix);
            IoHelper.OuputText(matrixStr, "qMatrixProper.txt");
        }

        private static void OutputQMatrix(QMatrix qMatrix)
        {
            var matrixStr = MatrixStringBuilder.GenerateQMatrix(qMatrix);
            IoHelper.OuputText(matrixStr, "qMatrix.txt");
        }

        private static void OutputRewardMatrix(Grid grid)
        {
            var matrixStr = MatrixStringBuilder.GenerateRewardMatrix(grid);
            IoHelper.OuputText(matrixStr, "matrix.txt");
        }
    }
}
