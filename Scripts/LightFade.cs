using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFade : MonoBehaviour {
    [SerializeField] private Light lt;
    [SerializeField] private float waitTime = 0.05f;

    Behaviour halo;

    public Bullet bullet;

    // Use this for initialization
    void Start ()
    {
        halo = (Behaviour)gameObject.GetComponent("Halo");
        haloToggle();
        lt = GetComponent<Light>();
        lt.intensity = 0;
        StartCoroutine("fadeIn");
	}

    public void setLightRange()
    {
        lt.range = bullet.timeWaited * 2;
    }
    IEnumerator fadeIn()
    {
        while (lt.intensity < 3)
        {
            yield return new WaitForSeconds(waitTime);
            lt.intensity += 0.2f;
        }

        StartCoroutine("fadeOut");
    }
    IEnumerator fadeOut()
    {
        while (lt.intensity != 0)
        {
            yield return new WaitForSeconds(waitTime);
            lt.intensity -= 0.1f;
        }

        Destroy(this.gameObject);

    }

    public void haloToggle()
    {
        if (bullet.isHalo == true)
        {
            //  (gameObject.GetComponent("Halo") as Behaviour).enabled = true;
            halo.enabled = true;
        }
        else
        {
            // (gameObject.GetComponent("Halo") as Behaviour).enabled = false;
            halo.enabled = false;
        }
    }
 
}
