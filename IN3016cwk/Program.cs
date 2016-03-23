using System.Runtime.InteropServices;
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
            var bot = BotBuilder.BuildBot(grid);
            bot.Learn();
            OutputQMatrix(bot.qMatrix);
            
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
