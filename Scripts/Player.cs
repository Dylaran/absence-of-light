using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public GameObject emptyPosition;

    int PlayerHp;

    // Use this for initialization
    void Start ()
    {
        placeHolderCreation();
	}


    void placeHolderCreation()
    {
        emptyPosition = new GameObject("OGPlaceHolder");
        emptyPosition.transform.position = this.transform.position;
        emptyPosition.transform.rotation = this.transform.rotation;
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
