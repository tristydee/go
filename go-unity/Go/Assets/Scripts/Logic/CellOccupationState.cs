using System;

namespace Logic
{
    [Flags]
    public enum CellOccupationState
    {
        Empty = 1,
        Player1 = 2,
        Player2 = 4,
        Any = Empty | Player1 | Player2
    }
}