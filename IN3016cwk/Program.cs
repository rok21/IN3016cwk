using System;
using System.Collections.Generic;
using System.Text;
using IN3016cwk.Grids;
using IN3016cwk.Helpers;

namespace IN3016cwk
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassicMode();
        }


        private static void ExperimentWithPolicies()
        {
            var failsLog = new StringBuilder();
            var inputStr = IoHelper.GetInput();
            var grid = GridBuilder.BuildGrid(inputStr);
            var rowBuilders = new List<StringBuilder> { new StringBuilder() };
            var policies = new List<Policy>
            {
                new Policy {epsilon = 1, update1 = 0.99999, update2 = 0.9999},
                new Policy {epsilon = 1, update1 = 0.9999, update2 = 0.9999},
                new Policy {epsilon = 1, update1 = 0.999, update2 = 0.999},
                new Policy {epsilon = 1, update1 = 0.99, update2 = 0.99},
            };
            foreach (var policy in policies)
            {
                var stepCountLog = new StringBuilder();
                var bot = new Bot(grid) { Policy = policy };
                Execute(bot, failsLog, stepCountLog, true);

                rowBuilders[0].AppendFormat("policy={0}\t", policy);
                var stepCountLogLines = stepCountLog.ToString().Split('\n');
                for (int i = 0; i < stepCountLogLines.Length; i++)
                {
                    if (rowBuilders.Count - 1 == i)
                        rowBuilders.Add(new StringBuilder());

                    rowBuilders[i + 1].AppendFormat("{0}\t", stepCountLogLines[i]);
                }
            }

            var finalBuilder = new StringBuilder();
            foreach (var rowBuilder in rowBuilders)
            {
                finalBuilder.AppendLine(rowBuilder.ToString());
            }

            IoHelper.OuputText(finalBuilder.ToString(), "performace_per_policy.txt");
        }

        private static void ExperimentWithLambdas()
        {
            var failsLog = new StringBuilder();
            var inputStr = IoHelper.GetInput();
            var grid = GridBuilder.BuildGrid(inputStr);
            var rowBuilders = new List<StringBuilder> { new StringBuilder() };
            foreach (var lambda in new [] { 0.1, 0.3, 0.7, 1 })
            {
                var stepCountLog = new StringBuilder();
                var bot = new Bot(grid) { learningRate = lambda };
                Execute(bot, failsLog, stepCountLog, true);

                rowBuilders[0].AppendFormat("lambda={0}\t", lambda);
                var stepCountLogLines = stepCountLog.ToString().Split('\n');
                for (int i = 0; i < stepCountLogLines.Length; i++)
                {
                    if (rowBuilders.Count - 1 == i)
                        rowBuilders.Add(new StringBuilder());

                    rowBuilders[i + 1].AppendFormat("{0}\t", stepCountLogLines[i]);
                }
            }

            var finalBuilder = new StringBuilder();
            foreach (var rowBuilder in rowBuilders)
            {
                finalBuilder.AppendLine(rowBuilder.ToString());
            }

            IoHelper.OuputText(finalBuilder.ToString(), "performace_per_lambda.txt");
        }

        private static void ExperimentWithGammas()
        {
            var failsLog = new StringBuilder();
            var inputStr = IoHelper.GetInput();
            var grid = GridBuilder.BuildGrid(inputStr);
            var rowBuilders = new List<StringBuilder> { new StringBuilder() };
            foreach (var gamma in new[] { 0.1, 0.3, 0.7, 0.9 })
            {
                var stepCountLog = new StringBuilder();
                var bot = new Bot(grid) {discountFactor = gamma};
                Execute(bot, failsLog, stepCountLog, true);

                rowBuilders[0].AppendFormat("gamma={0}\t", gamma);
                var stepCountLogLines = stepCountLog.ToString().Split('\n');
                for (int i = 0; i < stepCountLogLines.Length; i++)
                {
                    if(rowBuilders.Count-1 == i)
                        rowBuilders.Add(new StringBuilder());

                    rowBuilders[i+1].AppendFormat("{0}\t", stepCountLogLines[i]);
                }
            }

            var finalBuilder = new StringBuilder();
            foreach (var rowBuilder in rowBuilders)
            {
                finalBuilder.AppendLine(rowBuilder.ToString());
            }
            
            IoHelper.OuputText(finalBuilder.ToString(), "performace_per_gamma.txt");
        }

        private static void ClassicMode()
        {
            var inputStr = IoHelper.GetInput();
            var grid = GridBuilder.BuildGrid(inputStr);
            var bot = new Bot(grid);
            var stepCountLog = new StringBuilder();
            var failsLog = new StringBuilder();
            Execute(bot, failsLog, stepCountLog, true);
            IoHelper.OuputText(failsLog.ToString(), "fails.txt");
            IoHelper.OuputText(stepCountLog.ToString(), "performace.txt");
            OutputProperQMatrix(bot);
        }

        private static void Execute(Bot bot, StringBuilder failsLog, StringBuilder stepCountLog, bool logAverage = false)
        {
            var failedCount = 0;
            var performanceSum = 0.0;
            var successfulEpisodes = 0;
            for (var episode = 0; episode < 200000; episode++)
            {
                if (episode % 10 == 0 && episode != 0)
                {
                    if (logAverage)
                    {
                        stepCountLog.AppendFormat("{0}\n", performanceSum/successfulEpisodes);
                        successfulEpisodes = 0;
                        performanceSum = 0;
                    }
                    failsLog.AppendFormat("{0}\t{1}\n", episode, failedCount);
                    failedCount = 0;
                }
                BotPosHelper.PlaceBot(bot);
                var shortestPath = ShortestPathHelper.GetMinStepCount(bot);
                var botSteps = bot.FindPrincess();
                if (botSteps > -1 && !logAverage)
                    stepCountLog.AppendFormat("{0:0.00}\n", GetPerformance(botSteps, shortestPath));
                else if (botSteps == -1)
                    failedCount++;
                if (botSteps > -1 && logAverage)
                {
                    performanceSum += GetPerformance(botSteps, shortestPath);
                    successfulEpisodes++;
                }
            }
        }

        private static double GetPerformance(int botSteps, int shortestPath)
        {
            return shortestPath/((double)botSteps);
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
