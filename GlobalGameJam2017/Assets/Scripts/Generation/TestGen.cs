using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGen : MonoBehaviour
{
    public List<Sector> BuildingPrefabs;
    public List<GameObject> RoadPrefabs;
    public Dictionary<long, List<GameObject>> buildingMap;

    public const int CellWidth = 10;
    public const int CityWidth = 15;
    public const int CityHeight = 15;
    public const int BlockWidth = 4;
    public static int citySeed;
    public static int citySeed2;
    public GameObject player;

    // Use this for initialization
    void Start()
    {
        buildingMap = new Dictionary<long, List<GameObject>>();
        citySeed = Random.Range(0, 100000) * BlockWidth;
        citySeed2 = Random.Range(0, 100000) * BlockWidth;
        for (int i = 0; i < CityWidth; i++)
        {
            for (int j = 0; j < CityHeight; j++)
            {
                GenChunk(i, j);
            }
        }
    }

    void GenChunk(int i, int j)
    {
        long hash = i + (long)(j) * int.MaxValue;
        buildingMap[hash] = new List<GameObject>();
        //Debug.Log("Creating Hash " + hash + " for point " + i + " " + j);
        bool iRoad = i % BlockWidth == 0;
        bool jRoad = j % BlockWidth == 0;
        int streetVal = iRoad || jRoad ? 0 : 1;

        int buildingPick = (((i + citySeed) / BlockWidth) ^ ((j + citySeed2) / BlockWidth));//Random.Range(0, BuildingPrefabs.Count);
        buildingPick %= BuildingPrefabs.Count;

        if (streetVal == 0)
        {
            int roadPick = 0;
            if (iRoad && jRoad)
                roadPick = 2;
            else if (iRoad)
                roadPick = 0;
            else if (jRoad)
                roadPick = 1;
            GameObject obj = Instantiate(RoadPrefabs[roadPick]);
            obj.transform.position = new Vector3(i * CellWidth, 0, j * CellWidth);
            buildingMap[hash].Add(obj);
        }
        if (streetVal == 1)
        {
            var building = BuildingPrefabs[buildingPick].buildings[Random.Range(0, BuildingPrefabs[buildingPick].buildings.Count)];
            var prefabs = building.parts;
            int minHeight = building.minHeight;
            int maxHeight = building.maxHeight;
            var buildingHeight = Random.Range(minHeight, maxHeight);
            if (prefabs.Count > 0)
            {
                float height = 0;
                GameObject obj = Instantiate(prefabs[0]);
                obj.transform.position = new Vector3(i * CellWidth, height, j * CellWidth);
                buildingMap[hash].Add(obj);
                height += obj.transform.lossyScale.y;
                for (int n = 0; n < Random.Range(0, buildingHeight); n++)
                {
                    obj = Instantiate(prefabs[1]);
                    obj.transform.position = new Vector3(i * CellWidth, height, j * CellWidth);
                    height += obj.transform.lossyScale.y;
                    buildingMap[hash].Add(obj);
                }
                obj = Instantiate(prefabs[2]);
                obj.transform.position = new Vector3(i * CellWidth, height, j * CellWidth);
                buildingMap[hash].Add(obj);
            }
        }
    }

    void DestroyChunk(int i, int j)
    {
        long hash = i + (long)(j) * int.MaxValue;
        foreach (GameObject obj in buildingMap[hash])
        {
            Destroy(obj);
        }
        buildingMap[hash].Clear();
        buildingMap.Remove(hash);
    }

    void DestroyChunk(long hash)
    {
        foreach (GameObject obj in buildingMap[hash])
        {
            Destroy(obj);
        }
        buildingMap[hash].Clear();
        buildingMap.Remove(hash);
    }

    // Update is called once per frame
    void Update()
    {
        List<long> toDestroy = new List<long>();
        foreach (long key in buildingMap.Keys)
        {
            //toDestroy.Add(key);
        }
        foreach (long key in toDestroy)
        {
            DestroyChunk(key);
        }
    }
}
