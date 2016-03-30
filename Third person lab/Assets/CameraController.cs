using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    public Transform target;
    public float distanceAbove;
    public float distanceBehind;
    private float accumRotation;

    private Transform mCam;
    private Vector3 mMove;
    private Vector3 mCamForward;
    private float speed;
	// Use this for initialization
	void Start () {
        mCam = Camera.main.transform;
	}
	
	// Update is called once per frame
    void Update () {
        if(Input.GetKey(KeyCode.Q))
        {
            accumRotation++;
        } else if (Input.GetKey(KeyCode.E))
        {
            accumRotation--;
        }
        transform.position = target.position - (target.forward * distanceBehind) + (Vector3.up * distanceAbove * (Input.mousePosition.y * 0.1f));
        transform.LookAt(target);
        transform.RotateAround(target.transform.position, Vector3.up, Input.mousePosition.x * 0.5f);
	}
   

    void FixedUpdate ()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        mCamForward = Vector3.Scale(mCam.forward, new Vector3(1, 0, 1)).normalized;
        mMove = vertical * Vector3.forward + horizontal * Vector3.right;

        mCam.forward = mCamForward;
    }
}
