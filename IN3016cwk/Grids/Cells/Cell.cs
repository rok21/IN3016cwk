namespace IN3016cwk.Grids.Cells
{
    public abstract class Cell : Point
    { 
        public abstract bool CanStepIn();

        public abstract double GetReward();

        public abstract char GetChar();
    }
}