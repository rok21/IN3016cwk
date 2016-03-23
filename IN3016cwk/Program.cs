using System.Runtime.InteropServices;
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
            
            
            
        }

        private static void OutputRewardMatrix(GridBuilder grid)
        {
            var matrixStr = RewardMatrixStringBuilder.GenerateRewardMatrix(grid);
            IoHelper.OuputText(matrixStr, "matrix.txt");
        }
    }
}
