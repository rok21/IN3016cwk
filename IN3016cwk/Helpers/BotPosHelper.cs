using System;
using IN3016cwk.Grids;

namespace IN3016cwk.Helpers
{
    class BotPosHelper
    {
        public static void PlaceBot(Bot bot)
        {
            var rand = RandHelper.GetRand();
            do
            {
                bot.X = rand.Next(bot.grid.ColumnCount);
                bot.Y = rand.Next(bot.grid.RowCount);
            } while (!bot.grid.GetCurrCell(bot).CanStepIn() || bot.grid.GetCurrCell(bot).IsFinal());
        }
    }
}
