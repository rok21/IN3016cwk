namespace IN3016cwk.Grids.Cells
{
    public abstract class Cell : Point
    { 
        public override string ToString()
        {
            return string.Format("({0},{1})", X + 1, Y + 1);
        }

        public abstract bool CanStepIn();

        public abstract double GetReward();
    }
}
