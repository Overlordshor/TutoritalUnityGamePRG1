using UnityEngine;

namespace CustomTileMap
{
    public class TileMapRender : MonoBehaviour
    {
        public void Render(ITileMap tileMap)
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            for (int x = 0; x < tileMap.Width; x++)
            {
                for (int y = 0; y < tileMap.Height; y++)
                {
                    var position = new Vector2Int(x, y);
                    var cell = tileMap.GetGetCell(position);

                    var cellGo = CreateEmpty(position);
                    cell?.Refresh(position, tileMap, cellGo);
                }
            }
        }

        public GameObject CreateEmpty(Vector2Int position)
        {
            GameObject result = new GameObject(position.ToString());
            var transform = result.GetComponent<Transform>();
            transform.parent = GetComponent<Transform>();
            transform.localPosition = new Vector3(position.x, position.y, 0);
            result.AddComponent<SpriteRenderer>();

            return result;
        }
    }
}