using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public GameObject canvas;
    public GameObject arrow;
    private GameObject objectToTake;
    private GameObject nearestCollectible;
    private Vector3 toCollectible;
	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        float nearestSquaredDistance = Mathf.Infinity;
        foreach (GameObject collectible in GameObject.FindGameObjectsWithTag("Collectible"))
        {
            toCollectible = collectible.transform.position - transform.position;
            float squaredDistance = toCollectible.sqrMagnitude;
            if(squaredDistance < nearestSquaredDistance)
            {
                nearestCollectible = collectible;
                nearestSquaredDistance = squaredDistance;
            }
        }
        toCollectible = nearestCollectible.transform.position - transform.position;
        float angle = Vector3.Angle(toCollectible, transform.forward);
        Vector3 crossProduct = Vector3.Cross(toCollectible, transform.forward);

        if(crossProduct.y < 0)
        {
            angle = -angle;
        }
        arrow.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, angle);
    }

    private void ShowUI(bool isEnabled)
    {
        canvas.SetActive(isEnabled);
        GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = !isEnabled;
        Cursor.lockState = isEnabled ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isEnabled;
    }

    public void OnTake()
    {
        objectToTake.GetComponent<CollectibleController>().Acquire();
        ShowUI(false);
    }

    public void OnLeave()
    {
        ShowUI(false);
    }

    void OnTriggerEnter(Collider collider)
    {
        objectToTake = collider.gameObject;
        ShowUI(true);
    }
}
