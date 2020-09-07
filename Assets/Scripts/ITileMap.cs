using UnityEngine;

namespace CustomTileMap
{
    public interface ITileMap
    {
        int Count { get; }
        int Height { get; }
        int Width { get; }

        ICell GetCell(Vector2Int position);

        Vector2[] GetClosedMesh();
    }
}