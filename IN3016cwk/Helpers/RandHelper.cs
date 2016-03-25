using System;

namespace IN3016cwk.Helpers
{
    public class RandHelper
    {
        public static Random GetRand()
        {
            return new Random(Guid.NewGuid().GetHashCode());
        }
    }
}
