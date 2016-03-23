using IN3016cwk.Grids;

namespace IN3016cwk.Helpers
{
    class BotBuilder
    {
        public static Bot BuildBot(Grid grid)
        {
            return new Bot(grid) { Y = 6, X = 5 };
        }
    }
}
