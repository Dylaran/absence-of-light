using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject lightBleed;
    public GameObject LightPrefab;

    Gun bulletTime;
    LightFade lightF;
    NeutralBehaviour enemyAI;
    ScannerEffectDemo SED;

    public float timeWaited = 0;
    public bool isHalo = false;

    // Use this for initialization
    void Start()
    {
        SED = Singleton_Service.GetSingleton<ScannerEffectDemo>();
        bulletTime = Singleton_Service.GetSingleton<Gun>();
        StartCoroutine("BulletDeath");
        StartCoroutine("bulletLifespan");
    }

    IEnumerator BulletDeath()
    {
        yield return new WaitForSeconds(bulletTime.destroyBulletTime);
        isHalo = true;
        GameObject newLight = Instantiate(LightPrefab, transform.position, Quaternion.identity);
        lightF = newLight.GetComponent<LightFade>();
        lightF.bullet = this;
        lightF.setLightRange();
        Destroy(this.gameObject);
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Neutral")
        {
            isHalo = false;
            enemyAI = col.gameObject.transform.parent.gameObject.GetComponent<NeutralBehaviour>();
            Explode();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            isHalo = false;
            GameObject newLight = Instantiate(LightPrefab, transform.position, Quaternion.identity);
            lightF = newLight.GetComponent<LightFade>();
            lightF.GetComponent<Light>().flare = null;
            lightF.bullet = this;
            lightF.setLightRange();
            SED.StartScan(transform.position);
            Destroy(this.gameObject);
        }
    }

    IEnumerator bulletLifespan()
    {
        while (true)
        {   
            yield return new WaitForSeconds(0.1f);
            timeWaited += 0.1f;
        }
    }

    void Explode()
    {
        Instantiate(lightBleed, transform.position, transform.rotation);
        enemyAI.StartCoroutine("EnemyHit");
        Destroy(this.gameObject);
    }
}
