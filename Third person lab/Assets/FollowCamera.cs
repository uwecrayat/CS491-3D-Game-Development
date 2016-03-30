using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class FollowCamera : MonoBehaviour {
    public GameObject target;
    public List<GameObject> targets;
    public float damping = 1;
    public float distAbove;
    private Vector3 offset;
    public float distBehind;

    void Start()
    {
        offset = target.transform.position - transform.position;

        //offset = (targets[0].transform.position - targets[targets.Count-1].transform.position) - transform.position;
    }
    
    void Update()
    {
        distBehind = Vector3.Distance(targets[0].transform.position, targets[targets.Count-1].transform.position);
    }
    void LateUpdate()
    {
        float currentAngle = transform.eulerAngles.y;
        float desiredAngle = targets[0].transform.eulerAngles.y;
        float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);

        Quaternion rotation = Quaternion.Euler(0, angle, 0);
        transform.position = target.transform.position - (target.transform.forward * distBehind) + (Vector3.up * distAbove) - (rotation * offset) ;
       // transform.position = targets[0].transform.position - offset - (rotation * offset);

        transform.LookAt(targets[0].transform);
    }
}
