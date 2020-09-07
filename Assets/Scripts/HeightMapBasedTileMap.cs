using Boo.Lang;
using System.Linq;
using UnityEngine;

namespace CustomTileMap
{
    public class HeightMapBasedTileMap : ITileMap
    {
        public int Count => heights.Sum();

        public int Height => heights.Max();

        public int Width => heights.Length;

        private readonly int[] heights;
        private readonly ICell cell;

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

        public Vector2[] GetClosedMesh()
        {
            List<Vector2> points = new List<Vector2>();
            for (int x = 0; x < Width; x++)
            {
                points.Add(new Vector2(x - 0.5f, heights[x] - 0.5f));
                points.Add(new Vector2(x + 0.5f, heights[x] - 0.5f));
            }

            points.Add(new Vector2(Width - 0.5f, -0.5f));
            points.Add(new Vector2(-0.5f, -0.5f));

            return points.ToArray();
        }
    }
}