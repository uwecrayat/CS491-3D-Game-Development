using UnityEngine;
using System.Collections;

public class ArrowController : MonoBehaviour {
    public Transform target;
    private Vector3 toCollectible;
    private GameObject nearestCollectible;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float nearestSquaredDistance = Mathf.Infinity;
        foreach (GameObject collectible in GameObject.FindGameObjectsWithTag("Collectible"))
        {
            toCollectible = collectible.transform.position - transform.position;
            float squaredDistance = toCollectible.sqrMagnitude;
            if (squaredDistance < nearestSquaredDistance)
            {
                nearestCollectible = collectible;
                nearestSquaredDistance = squaredDistance;
            }
        }
        Vector3 relativePos = nearestCollectible.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        transform.rotation = rotation;
    }
}
