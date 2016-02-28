using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public GameObject canvas;
    public GameObject[] buttons;
    public Button take;

    private Stack moveList = new Stack();
    private GameObject objectToTake;
    private GameObject nearestCollectible;
    private Vector3 toCollectible;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < buttons.Length; i++)
        {
            moveList.Push(buttons[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            take.enabled = !take.enabled;
        }
    }

    private void ShowUI(bool isEnabled)
    {
        if (objectToTake == (moveList.Peek() as GameObject) && moveList.Count != 0)
        {
            take.enabled = true;
            take.transform.localScale = Vector3.one;
            moveList.Pop();
        }
        else
        {
            take.enabled = false;
            take.transform.localScale = new Vector3(0, 1, 1);

        }
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
