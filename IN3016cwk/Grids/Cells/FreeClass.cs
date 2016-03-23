﻿using IN3016cwk.Constants;

namespace IN3016cwk.Grids.Cells
{
    public class FreeCell : Cell
    {
        public override bool CanStepIn()
        {
            return true;
        }

        public override int GetReward()
        {
            return RewardsConstants.SteppingOnFreeCell;
        }
    }
}
