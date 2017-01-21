using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGen : MonoBehaviour
{
    public int floors;
    public GameObject[][] tiles;
    public GameObject wallPrefab;
    public GameObject floorPrefab;
    public GameObject stairPrefab;
    public Vector3 spawn;
    private const float yOffset = -0.1f;
    public int width = 32;
    public int halfWidth = 16;
    // Use this for initialization
    void Start ()
    {
        tiles = new GameObject[floors][];
        for(int i = 0; i < floors; i++)
        {
            tiles[i] = GenerateFloor(i);
        }
    }

    GameObject[] GenerateFloor(int floor)
    {
        GameObject[] data = new GameObject[short.MaxValue];
        int stairX = Random.Range(1, 11);
        int stairZ = Random.Range(1, 11);

        for (int i = 0; i < width; i++)
        {
            for(int j = 0; j < width; j++)
            {
                if (i == 0)
                {
                    GameObject w = Instantiate(wallPrefab);
                    w.transform.position = new Vector3(-halfWidth + 0.5f, yOffset, j - halfWidth);
                    w.transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
                    data[i + j * width] = w;
                }
                else if (i == width - 1)
                {
                    GameObject w = Instantiate(wallPrefab);
                    w.transform.position = new Vector3(halfWidth - 1.5f, yOffset, j - halfWidth);
                    w.transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
                    data[i + j * width] = w;
                }
                else if (j == 0)
                {
                    GameObject w = Instantiate(wallPrefab);
                    w.transform.position = new Vector3(i - halfWidth, yOffset, -halfWidth + 0.5f);
                    data[i + j * width] = w;
                }
                else if (j == width - 1)
                {
                    GameObject w = Instantiate(wallPrefab);
                    w.transform.position = new Vector3(i - halfWidth, yOffset, halfWidth - 1.5f);
                    data[i + j * width] = w;
                }
                else if (i == stairX && j == stairZ && floor < floors)
                {
                    GameObject s = Instantiate(stairPrefab);
                    s.transform.position = new Vector3(i - halfWidth, yOffset, j - halfWidth);
                    data[i + j * width] = s;
                }
                else
                {
                    GameObject f = Instantiate(floorPrefab);
                    f.transform.position = new Vector3(i - halfWidth, yOffset, j - halfWidth);
                    data[i + j * width] = f;
                }
            }
        }



        return data;
    }
}
