using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotlight : MonoBehaviour {

    [SerializeField] AudioSource spotlightSound;
    [SerializeField] Light spotlightLight;
    [SerializeField] GameObject lightParticles;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine("StartLight");
        spotlightLight = GetComponent<Light>();
        lightParticles.SetActive(false);
        lightParticles.GetComponent<ParticleEffectDuration>().enabled = false;
    }

    public IEnumerator StartLight()
    {
        yield return new WaitForSeconds(10.0f);
        spotlightSound.Play();
        lightParticles.SetActive(true);
        while (true)
        {
            spotlightLight.spotAngle += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
