using UnityEngine;

namespace CustomTileMap
{
    public interface ITileMap
    {
        int Count { get; }

        ICell GetGetCell(Vector2Int position);
    }
}