using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public GameObject canvas;
    public GameObject arrow;
    public GameObject[] buttons;
    public Text hintText;
    public Text buttonMsg;
    public string nextLevel;

    private Stack moveList = new Stack();
    private GameObject objectToTake;
    private GameObject nearestCollectible;
    private Vector3 toCollectible;
    public int numHints;
    private float timeToNoHint;

	// Use this for initialization
	void Start () {
        int size = UnityEngine.Random.Range(4,10);
        for (int i = 0; i < size; i++)
        {
            moveList.Push(buttons[UnityEngine.Random.Range(0,20) % 4]);
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
        if(moveList.Count == 0)
        {
            buttonMsg.text = "You finished the sequence! Click the button to load the next level";
        }     
        canvas.SetActive(isEnabled);
        GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = !isEnabled;
        Cursor.lockState = isEnabled ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isEnabled;
    }

    public void OnLeave()
    {
        ShowUI(false);
        if(moveList.Count == 0)
        {
            
            SceneManager.LoadScene(SceneManager.GetSceneByName(nextLevel).name);
        }
    }

    void OnTriggerEnter(Collider collider)
    {

        objectToTake = collider.gameObject;
        if (moveList.Count != 0 && objectToTake == (moveList.Peek() as GameObject))
        {
            moveList.Pop();
            buttonMsg.text = "Congrats. Find the next " + moveList.Count + " buttons in the sequence."; 
        } else
        {
            buttonMsg.text = "Wrong button. Keep looking.";
        }
        ShowUI(true);
    }
}
