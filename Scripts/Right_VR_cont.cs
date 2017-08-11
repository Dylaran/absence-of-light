using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class Right_VR_cont : MonoBehaviour
{

    public Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    public Valve.VR.EVRButtonId thumbStick = Valve.VR.EVRButtonId.k_EButton_Axis0;

    public SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    SteamVR_TrackedObject trackedObj;
    public SteamVR_Controller.Device device;

    public GameObject rotateParent;

    Input_Listeners IPL;

    private float cameraTurn;

    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        IPL = Singleton_Service.GetSingleton<Input_Listeners>();
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        device = SteamVR_Controller.Input((int)trackedObj.index);
        rb = rotateParent.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        cameraTurn = device.GetAxis(thumbStick).x;
        if (cameraTurn != 0)
        {
            rotateParent.transform.Rotate(Vector3.up, cameraTurn);
        }
        else
        {
            rb.angularVelocity = Vector3.zero;
        }

        if (controller.GetPressDown(triggerButton))
        {
            IPL.SetRightTriggerInteracting(true);
        }
        if (controller.GetPressUp(triggerButton))
        {
            IPL.SetRightTriggerInteracting(false);
        }
    }

    public IEnumerator vibrateRight(float length)
    {
        for (float i = 0; i < length; i += Time.deltaTime)
        {
            device.TriggerHapticPulse((ushort)2000f);
            yield return null;
        }
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
