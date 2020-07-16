using UnityEngine;

namespace CustomTileMap
{
    public interface ITileMap
    {
        int Count { get; }
        int Height { get; }
        int Width { get; }

        ICell GetGetCell(Vector2Int position);
    }
}