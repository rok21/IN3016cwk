using IN3016cwk.Constants;

namespace IN3016cwk.Grids.Cells
{
    public class PrincessCell : Cell
    {
        public override bool CanStepIn()
        {
            return true;
        }

        public override double GetReward()
        {
            return RewardsConstants.SavingThePrincess;
        }

        public override char GetChar()
        {
            return 'p';
        }
    }
}
