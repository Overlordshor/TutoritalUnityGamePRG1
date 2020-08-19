using UnityEngine;

namespace CustomTileMap
{
    [CreateAssetMenu(menuName = "GroundTile")]
    public class GroundTile : ScriptableObject, ICell
    {
        public Sprite Left, Right, Top, Bottom, TopLeft, TopRight, BottomLeft, BottomRight, Other;

        public void Refresh(Vector2Int position, ITileMap tileMap, GameObject gameObject)
        {
            SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
            renderer.sprite = Other;
            if (!Exist(position + Vector2Int.right, tileMap)
                && Exist(position + Vector2Int.left, tileMap)
                && !Exist(position + Vector2Int.up, tileMap))
            {
                renderer.sprite = TopRight;
            }
            else if (Exist(position + Vector2Int.right, tileMap)
                && Exist(position + Vector2Int.left, tileMap)
                && !Exist(position + Vector2Int.up, tileMap))
            {
                renderer.sprite = Top;
            }
            else if (Exist(position + Vector2Int.right, tileMap)
                && !Exist(position + Vector2Int.left, tileMap)
                && !Exist(position + Vector2Int.up, tileMap))
            {
                renderer.sprite = TopLeft;
            }
            else if (Exist(position + Vector2Int.right, tileMap)
                && Exist(position + Vector2Int.left, tileMap)
                && Exist(position + Vector2Int.up, tileMap)
                && !Exist(position + Vector2Int.up + Vector2Int.left, tileMap))
            {
                renderer.sprite = Left;
            }
            else if (Exist(position + Vector2Int.right, tileMap)
                && Exist(position + Vector2Int.left, tileMap)
                && Exist(position + Vector2Int.up, tileMap)
                && !Exist(position + Vector2Int.up + Vector2Int.right, tileMap))
            {
                renderer.sprite = Right;
            }
            else if (!Exist(position + Vector2Int.left, tileMap)
                && Exist(position + Vector2Int.up, tileMap))
            {
                renderer.sprite = BottomLeft;
            }
            else if (!Exist(position + Vector2Int.right, tileMap)
                && Exist(position + Vector2Int.up, tileMap))
            {
                renderer.sprite = BottomRight;
            }
        }

        private bool Exist(Vector2Int position, ITileMap tileMap)
        {
            if (position.x < 0 || position.x >= tileMap.Width) return false;

            var tile = tileMap.GetCell(position);

            return tile != null;
        }
    }
}