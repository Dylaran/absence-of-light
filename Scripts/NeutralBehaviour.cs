using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NeutralBehaviour : MonoBehaviour {
    [SerializeField] GameObject playerPos;
    [SerializeField] GameObject lightExplosion;
    [SerializeField] GameObject enemyExplosion;
    Gun gunLight;
    NavMeshAgent agent;
    NeutralMovement targetArray;
    GiantEnemy bigEnemy;

    Vector3 targetPos;
    float distanceToTarget;

    public float enemyHP = 5.0f;
    int check;

    // Use this for initialization
    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        targetArray = Singleton_Service.GetSingleton<NeutralMovement>();
        bigEnemy = Singleton_Service.GetSingleton<GiantEnemy>();
        gunLight = Singleton_Service.GetSingleton<Gun>();
        targetPos = targetArray.emptyGameObjectList[Random.Range(0, targetArray.emptyGameObjectList.Count)].transform.position;
        agent.SetDestination(targetPos);
        check = 0;

    }
	
	// Update is called once per frame
	void Update ()
    {
        var distance = Vector3.Distance(this.transform.position, targetPos);
        if (distance < 7)
        {
            targetPos = targetArray.emptyGameObjectList[Random.Range(0, targetArray.emptyGameObjectList.Count)].transform.position;
            agent.SetDestination(targetPos);
        }
 	}

    IEnumerator EnemyHit()
    {
        enemyHP--;
        while (true)
        {
            agent.SetDestination(playerPos.transform.position);
            if (enemyHP == 0)
            {
                gunLight.GetComponent<Light>().range++;
                Instantiate(lightExplosion, transform.position, transform.rotation);
                // Destroy(this.gameObject);
                this.gameObject.SetActive(false);
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (check < 1)
        {
            if (col.gameObject.tag == "Player")
            {
                check++;
                StartCoroutine("ShrinkEnemy");
            }
        }

    }

    IEnumerator ShrinkEnemy()
    {
        bool enemyAlive = true;
        float sizeShrinkXZ = 0.75f;
        float sizeShrinkY = 1.0f;
        yield return new WaitForSeconds(0.5f);
        while (enemyAlive)
        {
            this.gameObject.transform.localScale = new Vector3(sizeShrinkXZ, sizeShrinkY, sizeShrinkXZ);
            yield return new WaitForEndOfFrame();
            sizeShrinkXZ -= 0.001f;
            sizeShrinkY -= 0.001f;
            if (sizeShrinkXZ < 0.35)
            {
                Instantiate(enemyExplosion, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
        }

    }
}
