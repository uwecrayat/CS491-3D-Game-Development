using UnityEngine;
using System.Collections;

public class CollectibleController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
   public void Acquire()
    {
        Destroy(gameObject);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
