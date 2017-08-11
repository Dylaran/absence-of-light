using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class Left_VR_Cont : MonoBehaviour
{
    public Valve.VR.EVRButtonId thumbStick = Valve.VR.EVRButtonId.k_EButton_Axis0;
    public Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    SteamVR_Controller.Device device;
    SteamVR_TrackedObject trackedObj;

    Input_Listeners IPL;

    [SerializeField] GameObject playerMovement;

    float playerMoveX;
    float playerMoveZ;

    public float moveSpeed = 0.01f;

    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        IPL = Singleton_Service.GetSingleton<Input_Listeners>();
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        device = SteamVR_Controller.Input((int)trackedObj.index);
        rb = playerMovement.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMoveX = device.GetAxis(thumbStick).x;
        playerMoveZ = device.GetAxis(thumbStick).y;
        playerMovement.transform.Translate(new Vector3(playerMoveX * moveSpeed, 0, playerMoveZ * moveSpeed));
        if (playerMoveX == 0 && playerMoveZ == 0)
        {
            rb.velocity = Vector3.zero;
        }

        if (device.GetPressDown(triggerButton))
        { IPL.SetLeftTriggerInteracting(true); }
        if (device.GetPressUp(triggerButton))
        { IPL.SetLeftTriggerInteracting(false); }
    }

}
