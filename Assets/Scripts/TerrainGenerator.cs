using CustomTileMap;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public GroundTile Tile;

    private int /*height,*/ width;

    [SerializeField] private bool isGenerateOnStart = true;

    public void Render()
    {
        var tileMap = Generate();
        GetComponent<TileMapRender>().Render(tileMap);
    }

    private void Start()
    {
        /*height = 2;*/ // Mountainousness
        width = 5; // Width of ground
        if (isGenerateOnStart)
        {
            Render();
        }
    }

    private ITileMap Generate()
    {
        int groundHeight = 1; // Start height of ground

        HeightMapBasedTileMap tileMap = new HeightMapBasedTileMap(width, Tile);

        for (int x = 0; x < width; x++)
        {
            //if (x % 2 == 0)
            //{
            //    groundHeight += Random.Range(-1, height);
            //    if (groundHeight < 1)
            //    {
            //        groundHeight++;
            //    }
            //}
            groundHeight = 1;
            tileMap.SetHeight(x, groundHeight);
        }

        return tileMap;
    }
}