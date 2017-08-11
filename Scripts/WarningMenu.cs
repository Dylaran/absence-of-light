using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarningMenu : MonoBehaviour {
    [SerializeField] GameObject WarningText;
    Input_Listeners IPL;

    bool switchTime;
    // Use this for initialization
    void Start ()
    {
        IPL = Singleton_Service.GetSingleton<Input_Listeners>();
        WarningText.SetActive(false);
        switchTime = false;
        StartCoroutine("SwitchToFire");
    }

    void Update()
    {
        if (switchTime)
        {
            if (IPL.GetRightTriggerInteracting())
            {
                SceneManager.LoadScene("Main");
            }
        }
    }
    
    IEnumerator SwitchToFire()
    {
        yield return new WaitForSeconds(3.0f);
        WarningText.SetActive(true);
        switchTime = true;
    }

    private void OnEnable()
    {
        Singleton_Service.RegisterSingletonInstance(this);
    }

    void OnDisable()
    {
        Singleton_Service.UnregisterSingletonInstance(this);
    }
}
