using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralMovement : MonoBehaviour {

    public List<GameObject> emptyGameObjectList = new List<GameObject>();
    public GameObject floorParent;
    public GameObject newSpawn;

    public int spawns;

    // Use this for initialization
    void Awake ()
    {   
        goalSpawner();
        
    }
	
    void goalSpawner()
    {
        for (int i = 0; i < spawns; i++)
        {
            newSpawn = new GameObject("Pos");
            newSpawn.transform.position = floorParent.transform.GetChild(Random.Range(0, floorParent.transform.childCount)).transform.position;
            emptyGameObjectList.Add(newSpawn);  
        }
    }

    void OnEnable()
    {
        Singleton_Service.RegisterSingletonInstance(this);
    }
    void OnDisable()
    {
        Singleton_Service.UnregisterSingletonInstance(this);
    }
}
