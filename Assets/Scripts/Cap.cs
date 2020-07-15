using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cap : MonoBehaviour
{
    public Texture2D Texture;

    public IEnumerator Regenegate(float timeout)
    {
        while (true)
        {
            yield return new WaitForSeconds(timeout);
            Generate();
        }
    }

    private void Start()
    {
        StartCoroutine(Regenegate(0.5f));
    }

    private void Generate()
    {
        Texture2D texture = new Texture2D(30, 30, TextureFormat.ARGB32, false);

        var heighMap = CreateCanvas(texture);

        Crop(heighMap, texture);
        texture.Apply();
        Texture = texture;
        texture.mipMapBias = 0;
        texture.filterMode = FilterMode.Trilinear;
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        GetComponent<SpriteRenderer>().sprite = sprite;
    }

    private void Crop(Dictionary<float, float> heighMap, Texture2D texture)
    {
        for (int x = 0; x < texture.width; x++)
        {
            for (int y = 0; y > heighMap[x]; y--)
            {
                texture.SetPixel(x, y, Color.clear);
            }
        }
    }

    private Dictionary<float, float> CreateCanvas(Texture2D empty)
    {
        Color[] fill = new Color[empty.width * empty.height];
        Dictionary<float, float> heightMap = new Dictionary<float, float>();

        for (int i = 0; i < fill.Length; i++)
        {
            fill[i] = new Color(0, 0, 0, 0);
        }

        Color baseColor = RandomColor();
        Color shadeBaseColor = Color.Lerp(RandomColor(), Color.black, 0.5f);

        for (int l = 0; l < empty.width; l++)
        {
            float x = (float)l / (empty.width / 3);
            float m = Mathf.Pow(Mathf.Sqrt(x + 1 - Mathf.Pow(x - 1, 2)), 0.2f);

            m += 0.5f;
            int y = (int)(m * (empty.width / 3));
            heightMap.Add(l, y);

            while (--y > 0) // нарисовать шапку
            {
                empty.SetPixel(l, y, Color.Lerp(shadeBaseColor, baseColor, (float)y / empty.height));
            }
        }

        return heightMap;
    }

    private Color RandomColor()
    {
        return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
}