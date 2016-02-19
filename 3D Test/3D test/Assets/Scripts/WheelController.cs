using UnityEngine;
using System.Collections;

public class WheelController : MonoBehaviour {
    private new Rigidbody rigidbody;
    public float oomph;
	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float roll = Input.GetAxis("Roll");
        rigidbody.AddForce(new Vector3(0,0,roll * oomph));
	}
}
