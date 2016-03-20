﻿namespace IN3016cwk.Grids.Cells
{
    public abstract class Cell : Point
    { 
        public override string ToString()
        {
            return $"({Y+1},{X+1})";
        }

        public abstract bool CanStepIn();

        public abstract int GetReward();
    }
}
