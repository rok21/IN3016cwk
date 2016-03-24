using System.Text;
using IN3016cwk.Grids;

namespace IN3016cwk.Helpers
{
    public class GridStringHelper
    {
        public static string GenerateGridString(Grid grid, Point botPosition)
        {
            var stringBuilder = new StringBuilder();
            foreach (var row in grid)
            {
                foreach (var cell in row)
                {
                    if (cell.Equals(botPosition))
                    {
                        stringBuilder.Append('b');
                    }
                    else
                    {
                        stringBuilder.Append(cell.GetChar());
                    }
                }
                stringBuilder.AppendLine();
            }
            return stringBuilder.ToString();
        }
    }
}
