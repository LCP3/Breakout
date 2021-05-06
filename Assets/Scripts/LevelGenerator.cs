using System;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;
    public ColorToPrefab[] colorMaps;

    private void Start()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                CreateTile(x, y);
            }
        }
    }

    private void CreateTile(int x, int y)
    {
        //Get pixel color at x,y
        Color pixelColor = map.GetPixel(x, y);

        if (pixelColor.a == 0)
        {
            //Transparent, ignore.
            return;
        }

        foreach (ColorToPrefab colorMap in colorMaps)
        {
            if (colorMap.color == pixelColor)
            {
                Vector3 position = new Vector2(x*.7f, y*.35f);
                print(position);
                Instantiate(colorMap.prefab, transform.position + position, Quaternion.identity, transform);
            }
        }
    }
}
