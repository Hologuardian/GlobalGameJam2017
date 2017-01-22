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

    void GenerateFloor(int floor)
    {

    }
}
