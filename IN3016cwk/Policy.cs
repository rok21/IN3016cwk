namespace IN3016cwk
{
    public class Policy
    {
        public double epsilon = 1;
        public double update1 = 0.999999;
        public double update2 = 0.99999;

        public void UpdateEpsilon()
        {
            var k = epsilon >= 0.5 ? update1 : update2;
            epsilon *= k;
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", update1, update2);
        }
    }
}
