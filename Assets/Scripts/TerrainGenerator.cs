using CustomTileMap;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public GroundTile Tile;

    private int height, width;

    public ITileMap Generate()
    {
        int groundHeight = 4;

        HeightMapBasedTileMap tileMap = new HeightMapBasedTileMap(width, Tile);

        for (int x = 0; x < width; x++)
        {
            if (x % 2 == 0)
            {
                groundHeight += Random.Range(-1, height);
            }

            tileMap.SetHeight(x, groundHeight);
        }

        return tileMap;
    }

    private void Start()
    {
        height = 2;
        width = 50;
        var tileMap = Generate();
        GetComponent<TileMapRender>().Render(tileMap);
    }
}