using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public GameObject canvas;
    private GameObject objectToTake;
	// Use this for initialization
	void Start () {
	
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
    // Update is called once per frame
    void Update () {
	
	}
}
