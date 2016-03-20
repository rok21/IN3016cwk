namespace IN3016cwk.Grids.Cells
{
    public class IceKingCell : Cell
    {
        public override bool CanStepIn()
        {
            return true;
        }

        public override int GetReward()
        {
            return RewardsConstants.GettingKilledByIceKing;
        }
    }
}
