using System.Runtime.InteropServices;
using IN3016cwk.Helpers;

namespace IN3016cwk
{
    using Grids;

    class Program
    {
        static void Main(string[] args)
        {
            var inputStr = IoHelper.GetInput();
            var grid = GridBuilder.BuildGrid(inputStr);
            var bot = BotBuilder.BuildBot(grid);
            bot.Learn();
            IoHelper.OuputText(MatrixStringBuilder.GenerateQMatrixString(bot.qMatrix), "qMatrix.txt");


        }

        private static void OutputRewardMatrix(Grid grid)
        {
            var matrixStr = MatrixStringBuilder.GenerateRewardMatrix(grid);
            IoHelper.OuputText(matrixStr, "matrix.txt");
        }
    }
}
