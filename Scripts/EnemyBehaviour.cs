using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour {
    [SerializeField] Player playerRig;
    [SerializeField] GameObject deathExplosion;
    [SerializeField] GameObject enemyBleed;
    [SerializeField] AudioSource soundDistortion;
    Gun gunLight;
    NavMeshAgent agent;
    NeutralMovement targetArray;
    Vector3 targetPos;
    GiantEnemy bigEnemy;
   

    int enemyHP;

    // Use this for initialization
    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        playerRig = Singleton_Service.GetSingleton<Player>();
        bigEnemy = Singleton_Service.GetSingleton<GiantEnemy>();
        targetArray = Singleton_Service.GetSingleton<NeutralMovement>();
        gunLight = Singleton_Service.GetSingleton<Gun>();
        agent.SetDestination(playerRig.transform.position);
        enemyHP = 3;
    }

    void Update()
    {
        var distance = Vector3.Distance(this.transform.position, playerRig.transform.position);
        agent.SetDestination(playerRig.transform.position);

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            gunLight.GetComponent<Light>().range--;
            bigEnemy.StartCoroutine("RedGlow");
            bigEnemy.waveTime += 5.0f;
            targetPos = targetArray.emptyGameObjectList[Random.Range(0, targetArray.emptyGameObjectList.Count)].transform.localPosition;
            agent.SetDestination(playerRig.transform.position);
            agent.Warp(targetPos);
        }

        if (col.gameObject.tag == "Bullet")
        {
            enemyHP--;
            Instantiate(enemyBleed, transform.position, transform.rotation);
            if (enemyHP == 0)
            {
                targetPos = targetArray.emptyGameObjectList[Random.Range(0, targetArray.emptyGameObjectList.Count)].transform.localPosition;
                agent.SetDestination(playerRig.transform.position);
                agent.Warp(targetPos);
                enemyHP = 3;
            }
        }
    }
}
