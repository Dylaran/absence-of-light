using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotate : MonoBehaviour
{
    public GameObject hand;

    // Update is called once per frame
    void Update()
    {
        transform.position = hand.transform.position;
        transform.rotation = hand.transform.rotation;
    }
}
