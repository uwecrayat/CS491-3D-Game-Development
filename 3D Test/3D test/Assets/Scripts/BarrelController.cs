using UnityEngine;
using System.Collections;

public class BarrelController : MonoBehaviour {
    public Transform wheels;
    public Transform firePoint;
    public GameObject cannonball;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float pressure = Input.GetAxis("Tilt");
        transform.Rotate(new Vector3(pressure, 0, 0));
        transform.position = wheels.position;

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject tmp = Instantiate(cannonball, firePoint.position, Quaternion.identity) as GameObject;
            tmp.GetComponent<Rigidbody>().AddForce(transform.up * -1000);
        }
	}
}
