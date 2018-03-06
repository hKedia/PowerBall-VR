using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGrabObject : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;
    // 1
    private GameObject collidingObject;
    // 2
    private GameObject objectInHand;

    // Balls
    public GameObject basketBall;
    public GameObject footBall;
    public GameObject wooodenBall;

    //Tansform
    Vector3 basketBallPostion;
    Vector3 footBallPosition;
    Vector3 wooodenBallPosition;

    private void Start()
    {
        basketBallPostion = basketBall.GetComponent<Transform>().transform.position;
        footBallPosition = footBall.GetComponent<Transform>().transform.position;
        wooodenBallPosition = wooodenBall.GetComponent<Transform>().transform.position;
    }
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    private void SetCollidingObject(Collider col)
    {
        // 1
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        // 2
        collidingObject = col.gameObject;
    }

    // Update is called once per frame
    void Update () {

        // 1
        if (Controller.GetHairTriggerDown())
        {
            if (collidingObject)
            {
                GrabObject();
            }
        }

        // 2
        if (Controller.GetHairTriggerUp())
        {
            if (objectInHand)
            {
                ReleaseObject();
            }
        }
        if(Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            basketBall.GetComponent<Transform>().transform.position = basketBallPostion;
            basketBall.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            footBall.GetComponent<Transform>().transform.position = footBallPosition;
            footBall.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            wooodenBall.GetComponent<Transform>().transform.position = wooodenBallPosition;
            wooodenBall.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }

    }

    // 1
    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }

    // 2
    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    // 3
    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
    }

    private void GrabObject()
    {
        // 1
        objectInHand = collidingObject;
        collidingObject = null;
        // 2
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }

    // 3
    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ReleaseObject()
    {
        // 1
        if (GetComponent<FixedJoint>())
        {
            // 2
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            // 3
            objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
            objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
        }
        // 4
        objectInHand = null;
    }
}
