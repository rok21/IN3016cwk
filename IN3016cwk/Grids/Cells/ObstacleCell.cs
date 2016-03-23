namespace IN3016cwk.Grids.Cells
{
    public class ObstacleCell : Cell
    {
        public override bool CanStepIn()
        {
            return false;
        }

        public override double GetReward()
        {
            throw new System.NotImplementedException();
        }
    }
}
