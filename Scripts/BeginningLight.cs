using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginningLight : MonoBehaviour
{
    [SerializeField] GameObject bigLight;
    [SerializeField] Light lt;
    [SerializeField] float waitTime = 0.05f;

    // Use this for initialization
    void Start ()
    {
        StartCoroutine("BeginningGlow");
    }
	
	IEnumerator BeginningGlow()
    {
        bigLight.SetActive(true);

        while (lt.intensity > 0)
        {
            yield return new WaitForSeconds(waitTime);
            lt.intensity -= 0.1f;
        }

        bigLight.SetActive(false);
    }
}
