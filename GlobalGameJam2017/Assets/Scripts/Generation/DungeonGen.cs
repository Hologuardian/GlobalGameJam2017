using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGen : MonoBehaviour
{
    public int floors;
    public List<GameObject> tiles;
    public GameObject wallPrefab;
    public GameObject floorPrefab;
    public GameObject stairPrefab;
    public Vector3 spawn;
    private const float yOffset = -0.1f;
    public int width = 64;
    public int halfWidth = 32;
    // Use this for initialization
    void Start ()
    {
        GenerateFloor(0);
    }

    List<Tile> TestGen()
    {

        List<Tile> preGeneratedTiles = new List<Tile>();

        if (spawn.x < 0 && spawn.z > -0.1f && spawn.z < 0.1f)
        {
            for (int n = 0; n <= width; n++)
            {
                if (n != halfWidth - 1 && n != halfWidth && n != halfWidth + 2 && n != halfWidth + 3)
                {
                    preGeneratedTiles.Add(new Tile(n, halfWidth - 5, 2));
                    preGeneratedTiles.Add(new Tile(n, halfWidth + 5, 3));
                }
                for (int m = halfWidth - 4; m <= halfWidth + 4; m++)
                {
                    preGeneratedTiles.Add(new Tile(n, m, 4));
                }
                if (n == halfWidth + 1)
                {
                    for (int m = 3; m <= width - 3; m++)
                    {
                        preGeneratedTiles.Add(new Tile(n, m, 1));
                    }
                }
            }
        }
        if (spawn.x > 0 && spawn.z > -0.1f && spawn.z < 0.1f)
        {

        }
        if (spawn.z < 0 && spawn.x > -0.1f && spawn.x < 0.1f)
        {

        }
        if (spawn.z > 0 && spawn.x > -0.1f && spawn.x < 0.1f)
        {

        }

        return preGeneratedTiles;
    }

    //0 - x wall
    //1 + x wall
    //2 - z wall
    //3 + z wall
    //4 floor
    void GenerateFloor(int floor)
    {
        int stairX = Random.Range(1, width - 2);
        int stairZ = Random.Range(1, width - 2);
        spawn = new Vector3(-16.0f, 0, 0);
        List<Tile> preGeneratedTiles = TestGen();

        for (int i = 0; i <= width; i++)
        {
            for(int j = 0; j <= width; j++)
            {
                #region Exterior Walls
                if (i == 0)
                {
                    for(int n = 0; n < 3; n++)
                    {
                        GameObject w = Instantiate(wallPrefab);
                        w.transform.position = new Vector3(-halfWidth, yOffset + n, j - halfWidth);
                        w.transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
                        tiles.Add(w);
                    }
                }
                else if (i == width)
                {
                    for (int n = 0; n < 3; n++)
                    {
                        GameObject w = Instantiate(wallPrefab);
                        w.transform.position = new Vector3(halfWidth, yOffset + n, j - halfWidth);
                        w.transform.rotation = Quaternion.AngleAxis(-90, Vector3.up);
                        tiles.Add(w);
                    }
                }
                else if (j == 0)
                {
                    for (int n = 0; n < 3; n++)
                    {
                        GameObject w = Instantiate(wallPrefab);
                        w.transform.position = new Vector3(i - halfWidth, yOffset + n, -halfWidth);
                        tiles.Add(w);
                    }
                }
                else if (j == width)
                {
                    for (int n = 0; n < 3; n++)
                    {
                        GameObject w = Instantiate(wallPrefab);
                        w.transform.position = new Vector3(i - halfWidth, yOffset + n, halfWidth);
                        tiles.Add(w);
                    }
                }
                #endregion
                #region PreGen
                else if(preGeneratedTiles.Contains(new Tile(i, j, 0 )))
                {
                    for (int n = 0; n < 3; n++)
                    {
                        GameObject w = Instantiate(wallPrefab);
                        w.transform.position = new Vector3(i - halfWidth, yOffset + n, j - halfWidth);
                        w.transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
                        tiles.Add(w);
                    }
                    preGeneratedTiles.Remove(new Tile(i, j, 0));
                }
                else if (preGeneratedTiles.Contains(new Tile(i, j, 1 )))
                {
                    for (int n = 0; n < 3; n++)
                    {
                        GameObject w = Instantiate(wallPrefab);
                        w.transform.position = new Vector3(i - halfWidth, yOffset + n, j - halfWidth);
                        w.transform.rotation = Quaternion.AngleAxis(-90, Vector3.up);
                        tiles.Add(w);
                    }
                    preGeneratedTiles.Remove(new Tile(i, j, 1));
                }
                else if (preGeneratedTiles.Contains(new Tile(i, j, 2 )))
                {
                    for (int n = 0; n < 3; n++)
                    {
                        GameObject w = Instantiate(wallPrefab);
                        w.transform.position = new Vector3(i - halfWidth, yOffset + n, j - halfWidth);
                        tiles.Add(w);
                    }
                    preGeneratedTiles.Remove(new Tile(i, j, 2));
                }
                else if (preGeneratedTiles.Contains(new Tile(i, j, 3 )))
                {
                    for (int n = 0; n < 3; n++)
                    {
                        GameObject w = Instantiate(wallPrefab);
                        w.transform.position = new Vector3(i - halfWidth, yOffset + n, j - halfWidth);
                        tiles.Add(w);
                    }
                    preGeneratedTiles.Remove(new Tile(i, j, 3));
                }
                else if (preGeneratedTiles.Contains(new Tile( i, j, 4 )))
                {
                    GameObject f = Instantiate(floorPrefab);
                    f.transform.position = new Vector3(i - halfWidth, yOffset, j - halfWidth);
                    tiles.Add(f);
                    preGeneratedTiles.Remove(new Tile(i, j, 4));
                }
                #endregion
                #region Fill
                else if (i == stairX && j == stairZ && floor < floors - 1)
                {
                    for (int n = 0; n < 3; n++)
                    {
                        GameObject s = Instantiate(stairPrefab);
                        s.transform.position = new Vector3(i - halfWidth, yOffset + n, j - halfWidth);
                        tiles.Add(s);
                    }
                }
                else
                {
                    GameObject f = Instantiate(floorPrefab);
                    f.transform.position = new Vector3(i - halfWidth, yOffset, j - halfWidth);
                    tiles.Add(f);
                }
                #endregion
            }
        }
    }
}
