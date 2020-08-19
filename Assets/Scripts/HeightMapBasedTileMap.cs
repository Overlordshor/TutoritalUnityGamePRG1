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
            heights[x] = value;
        }

        public ICell GetCell(Vector2Int position)
        {
            return position.y < heights[position.x] ? cell : null;
        }
    }
}