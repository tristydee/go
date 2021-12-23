using System;
using UnityEngine;

namespace Logic
{
    [Flags]
    public enum CellOccupationState
    {
        Empty = 1,
        Player1 = 2,
        Player2 = 4,
        Any = Empty | Player1 | Player2,
        Occupied = Player1 | Player2
    }

    public static class OccupationStateExtensions
    {
        public static CellOccupationState OtherPlayer(this CellOccupationState occupationState)
        {
            switch (occupationState)
            {
                case CellOccupationState.Player1:
                    return CellOccupationState.Player2;
                case CellOccupationState.Player2:
                    return CellOccupationState.Player1;
                default:
                    throw new ArgumentOutOfRangeException(nameof(occupationState), occupationState, null);
            }
        }

        public static Color Color(this CellOccupationState occupationState)
        {
            switch (occupationState)
            {
                case CellOccupationState.Empty:
                    return UnityEngine.Color.clear;
                case CellOccupationState.Player1:
                    return UnityEngine.Color.black;
                case CellOccupationState.Player2:
                    return UnityEngine.Color.white;
                default:
                    throw new ArgumentOutOfRangeException(nameof(occupationState), occupationState, null);
            }
        }
    }
}