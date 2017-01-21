using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGen : MonoBehaviour
{
    public List<GameObject> BuildingPrefabs;
    public List<GameObject> RoadPrefabs;

    private const int CellWidth = 10;
    private const int CityWidth = 200;
    private const int CityHeight = 200;
    private const int BlockWidth = 16;

	// Use this for initialization
	void Start ()
    {
        for (int i = 0; i < CityWidth; i++)
        {
            for (int j = 0; j < CityHeight; j++)
            {
                int streetVal = (i % BlockWidth == 0) || (j % BlockWidth) == 0 ? 0 : 1;
                int buildingPick = Random.Range(0, BuildingPrefabs.Count);
                int roadPick = Random.Range(0, RoadPrefabs.Count);
                GameObject obj = Instantiate(streetVal == 0 ? RoadPrefabs[roadPick] : BuildingPrefabs[buildingPick]);
                obj.transform.position = new Vector3(i * CellWidth, 0, j * CellWidth);
                if (streetVal == 1)
                {
                    Vector3 scale = obj.transform.localScale;
                    scale.y *= Random.value * 5 * (buildingPick + 1);
                    scale.y++;
                    obj.transform.localScale = scale;
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
