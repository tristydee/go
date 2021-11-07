using System;

namespace Logic.Scoring
{
    public interface IScoringCommand
    {
        public Score[] Execute();
    }
}