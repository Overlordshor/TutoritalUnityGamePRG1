using UnityEngine;

namespace CustomTileMap
{
    public interface ICell
    {
        void Refresh(Vector2Int position, ITileMap tileMap, GameObject gameObject);
    }
}