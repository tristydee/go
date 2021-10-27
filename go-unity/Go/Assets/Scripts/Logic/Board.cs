using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public class Board
    {
        public List<Cell> Cells = new List<Cell>();
        
        private readonly Vector2Int size;

        public Board(Vector2Int size)
        {
            this.size = size;

            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    Cells.Add(new Cell(new Vector2Int(x,y),null)); //todo: pass in view
                }
            }
        }
    }
}