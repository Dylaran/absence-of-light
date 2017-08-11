using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    [SerializeField] AudioSource gunShot;

    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float nextFire = 0.0f;
    [SerializeField] private int bulletVelocity = 15;
    public float destroyBulletTime = 2.5f;

    Input_Listeners IPL;

    [SerializeField] Right_VR_cont rightCont;

    // Use this for initialization
    void Start()
    {
        IPL = Singleton_Service.GetSingleton<Input_Listeners>();
    }

    void Update()
    {
        if (IPL.GetRightTriggerInteracting() && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Fire();
            // rightCont.GetComponent<Right_VR_cont>().controller.TriggerHapticPulse(500);
        }
    }

    private void OnEnable()
    {
        Singleton_Service.RegisterSingletonInstance(this);
    }

    void OnDisable()
    {
        Singleton_Service.UnregisterSingletonInstance(this);
    }

    void Fire()
    {
        rightCont.StartCoroutine(rightCont.vibrateRight(0.1f));

        gunShot.Play();

        // Create bullet from the prefab
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        // Add velocity to bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletVelocity;

        // IPL.GetRightTriggerInteracting();
    }
}
