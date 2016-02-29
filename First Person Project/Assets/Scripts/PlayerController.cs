using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public GameObject canvas;
    public GameObject arrow;
    public GameObject[] buttons;
    public Text hintText;

    private Stack moveList = new Stack();
    private GameObject objectToTake;
    private GameObject nearestCollectible;
    private Vector3 toCollectible;
    private int numHints;
    private float timeToNoHint;

	// Use this for initialization
	void Start () {
        numHints = 3;
        for (int i = 0; i < buttons.Length; i++)
        {
            moveList.Push(buttons[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        hintText.text = "" + numHints;
        if (Time.time > timeToNoHint)
        {
            if (Input.GetKeyDown(KeyCode.H) && !canvas.activeSelf && numHints > 0)
            {
               
                StartCoroutine(showArrow());
                timeToNoHint += 4;
            }
        }
        if (moveList.Count != 0)
        {
            Vector3 relativePos = (moveList.Peek() as GameObject).transform.position - arrow.transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            arrow.transform.rotation = rotation;
        }
    }
    IEnumerator showArrow()
    {
        arrow.SetActive(true);
        numHints--;
        yield return new WaitForSeconds(4f);
        arrow.SetActive(false);
    }
    private void ShowUI(bool isEnabled)
    {
        print(moveList.Count);
        
        
        canvas.SetActive(isEnabled);
        GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = !isEnabled;
        Cursor.lockState = isEnabled ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isEnabled;
    }

    public void OnLeave()
    {
        ShowUI(false);
    }

    void OnTriggerEnter(Collider collider)
    {

        objectToTake = collider.gameObject;
        if (moveList.Count != 0 && objectToTake == (moveList.Peek() as GameObject))
        {
            moveList.Pop();
        }
        ShowUI(true);
    }
}
