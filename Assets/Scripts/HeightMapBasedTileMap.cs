using System;
using System.Linq;
using UnityEngine;

namespace CustomTileMap
{
    public class HeightMapBasedTileMap : ITileMap
    {
        public int Count => heights.Sum();

        public int Height => heights.Max();

        public int Width => heights.Length;

        private int[] heights;
        private ICell cell;

        public HeightMapBasedTileMap(int width, ICell cell)
        {
            heights = new int[width];
            this.cell = cell;
        }

        public void SetHeight(int x, int value)
        {
            if (x < 0 && x >= heights.Length)
            {
                throw new ArgumentOutOfRangeException("x");
            }

            heights[x] = value;
        }

        public ICell GetGetCell(Vector2Int position)
        {
            if (position.x < 0 && position.x >= heights.Length)
            {
                throw new ArgumentOutOfRangeException("x");
            }

            if (position.y <= heights[position.x])
            {
                return cell;
            }
            else
            {
                return null;
            }
        }
    }
}