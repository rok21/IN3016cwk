using System;
using System.Collections.Generic;
using System.Linq;
using IN3016cwk.Grids.Cells;

namespace IN3016cwk.Helpers
{
    public static class MyExtensionMethods
    {
        public static T Random<T>(this IEnumerable<T> enumerable)
        {
            var list = enumerable.ToList();
            var rand = RandHelper.GetRand();
            return list[rand.Next(list.Count)];
        }

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            enumerable.ToList().ForEach(action);
        }

        public static IEnumerable<Cell> GoodCells(this IEnumerable<Cell> enumerable)
        {
            return enumerable.Where(c => c.CanStepIn() && !(c is IceKingCell));
        }
    }
}
