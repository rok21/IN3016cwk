namespace IN3016cwk
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputStr = IoHelper.GetInput();
            var grid = GridBuilder.BuildGrid(inputStr);
            var matrixStr = RewardMatrixHelper.GenerateRewardMatrix(grid);
            IoHelper.OuputText(matrixStr, "matrix.txt");
        }
    }
}
