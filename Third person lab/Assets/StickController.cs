using UnityEngine;
using System.Collections;

public class StickController : MonoBehaviour {
    private Vector3 distToTarget;
    private Vector3 contactPoint;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(transform.parent != null)
        {
            transform.position = transform.parent.position + contactPoint ;
            transform.localRotation = transform.parent.rotation;
        }
	}

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            contactPoint = other.contacts[0].point;
            transform.SetParent(other.transform);
            Destroy(gameObject.GetComponent<Collider>());
            //gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            //GameObject empty = new GameObject();
            //empty.transform.SetParent(other.transform);
            //transform.SetParent(empty.transform);
        }
    }
}
