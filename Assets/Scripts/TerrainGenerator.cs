using CustomTileMap;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public GroundTile Tile;

    private int height, width;

    [SerializeField] private bool isGenerateOnStart = true;

    public ITileMap Generate()
    {
        int groundHeight = 1;

        HeightMapBasedTileMap tileMap = new HeightMapBasedTileMap(width, Tile);

        for (int x = 0; x < width; x++)
        {
            if (x % 2 == 0)
            {
                groundHeight += Random.Range(-1, height);
                if (groundHeight < 1)
                {
                    groundHeight++;
                }
            }

            tileMap.SetHeight(x, groundHeight);
        }

        return tileMap;
    }

    public void Render()
    {
        var tileMap = Generate();
        GetComponent<TileMapRender>().Render(tileMap);
    }

    private void Start()
    {
        height = 2;
        width = 50;
        if (isGenerateOnStart)
        {
            Render();
        }
    }
}