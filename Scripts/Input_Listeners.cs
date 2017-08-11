using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Input_Listeners : MonoBehaviour {

    public bool LeftTriggerInteracting = false;
    public bool RightTriggerInteracting = false;

    public bool GetLeftTriggerInteracting()
    {
        return LeftTriggerInteracting;
    }
    public void SetLeftTriggerInteracting(bool value)
    {
        LeftTriggerInteracting = value;
    }


    public bool GetRightTriggerInteracting()
    {
        return RightTriggerInteracting;
    }
    public void SetRightTriggerInteracting(bool value)
    {
        RightTriggerInteracting = value;
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
