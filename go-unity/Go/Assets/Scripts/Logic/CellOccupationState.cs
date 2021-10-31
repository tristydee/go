using System;

namespace Logic
{
    [Flags]
    public enum CellOccupationState
    {
        Empty = 0,
        Player1 = 1,
        Player2 = 2,
        Any = Empty | Player1 | Player2 //todo: correct? or should it be &
    }
}