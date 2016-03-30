using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float oomph;
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float forward = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        rb.velocity = transform.forward * forward * oomph;
        rb.AddTorque(new Vector3(0, horizontal, 0));       
	}
}
