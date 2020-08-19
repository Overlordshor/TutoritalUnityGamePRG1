using System.Linq;
using UnityEngine;
using UnityScript.Scripting;

namespace CustomTileMap
{
    public class TileMapRender : MonoBehaviour
    {
        public void Render(ITileMap tileMap)
        {
            foreach (Transform child in transform.OfType<Transform>().ToList())
            {
#if UNITY_EDITOR
                DestroyImmediate(child.gameObject);
#else
                Destroy(child.gameObject);
#endif
            }
            for (int x = 0; x < tileMap.Width; x++)
            {
                for (int y = 0; y < tileMap.Height; y++)
                {
                    var position = new Vector2Int(x, y);
                    var cell = tileMap.GetCell(position);

                    var cellGo = CreateEmpty(position);
                    cell?.Refresh(position, tileMap, cellGo);
                }
            }
        }

        private GameObject CreateEmpty(Vector2Int position)
        {
            GameObject result = new GameObject(position.ToString());
            var transform = result.GetComponent<Transform>();
            transform.parent = GetComponent<Transform>();
            transform.localPosition = new Vector3(position.x, position.y, 200);
            result.AddComponent<SpriteRenderer>();

            return result;
        }
    }
}