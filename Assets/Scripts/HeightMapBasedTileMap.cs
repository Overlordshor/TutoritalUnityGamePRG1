using System;
using System.Linq;
using UnityEngine;

namespace CustomTileMap
{
    internal class HeightMapBasedTileMap : ITileMap
    {
        public int Count => heights.Sum();

        private int[] heights;

        public HeightMapBasedTileMap(int width)
        {
            heights = new int[width];
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
            throw new System.NotImplementedException();
        }
    }
}