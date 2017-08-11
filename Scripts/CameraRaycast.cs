using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour {
    [SerializeField] Camera cam;
    [SerializeField] GameObject FireScene;
    [SerializeField] GameObject MainScene;
    [SerializeField] GameObject particleEffectStars;
    // public GameObject[] starList;

    bool switchToMain;

    void Start()
    {
        StartCoroutine("WaitForParticles");
    }

    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (switchToMain)
            {
                if (hit.transform.name == "Box")
                {
                    particleEffectStars.GetComponent<ParticleEffectDuration>().enabled = true;
                    FireScene.SetActive(false);
                    MainScene.SetActive(true);
                }
            }
        }
    }
    IEnumerator WaitForParticles()
    {
        switchToMain = false;
        yield return new WaitForSeconds(10.0f);
        switchToMain = true;
    }
}
