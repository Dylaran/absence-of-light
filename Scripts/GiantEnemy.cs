using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantEnemy : MonoBehaviour {
    [SerializeField] GameObject giant;
    [SerializeField] Light lt;
    
    public float waveTime = 15f;
    float waitTime = 0.05f;

    void Start()
    {
        lt.intensity = 0;
        StartCoroutine("PulseGlow");
	}

    IEnumerator PulseGlow()
    {
        while (true)
        {
            yield return new WaitForSeconds(waveTime);
            giant.SetActive(true);

            for (int i = 0; i < 3; i++)
            {
                while (lt.intensity < 1)
                {
                    yield return new WaitForSeconds(waitTime);
                    lt.intensity += 0.2f;
                }
                yield return new WaitForSeconds(1.0f);
                while (lt.intensity > 0)
                {
                    yield return new WaitForSeconds(waitTime);
                    lt.intensity -= 0.1f;
                }
            }

            giant.SetActive(false);
        }
    }

    IEnumerator RedGlow()
    {
        giant.SetActive(true);
        lt.color = Color.red;

        while (lt.intensity < 2)
        {
            yield return new WaitForSeconds(waitTime);
            lt.intensity += 0.1f;
        }

        while (lt.intensity > 0)
        {
            yield return new WaitForSeconds(waitTime);
            lt.intensity -= 0.1f;
        }

        lt.color = Color.white;
        giant.SetActive(false);
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
