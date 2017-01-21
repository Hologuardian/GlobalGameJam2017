using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGen : MonoBehaviour
{
    public List<GameObject> BuildingPrefabs;
    public List<GameObject> RoadPrefabs;
    public List<GameObject> Test;

    private const int CellWidth = 10;
    private const int CityWidth = 200;
    private const int CityHeight = 200;
    private const int BlockWidth = 10;

	// Use this for initialization
	void Start ()
    {
        for (int i = 0; i < CityWidth; i++) ;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
