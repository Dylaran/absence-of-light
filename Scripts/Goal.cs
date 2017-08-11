using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource audioSource1;

    void Start()
    {
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Bullet")
        {
            StartCoroutine("EndGame");
        }
    }

    IEnumerator EndGame()
    {
        bool spin = true;
        float rotSpeed = 0;
        audioSource.Play();
        audioSource1.Play();
        while (spin)
        {
            this.gameObject.transform.Rotate(0, rotSpeed, 0);
            yield return new WaitForEndOfFrame();
            rotSpeed += 0.05f;
            if (rotSpeed > 37.5) 
            {
                spin = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
