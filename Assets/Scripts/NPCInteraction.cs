using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPCInteraction : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ThePlayer;
    public GameObject TextBox;
    public GameObject NPCName;
    public GameObject NPCText;
    

    // Update is called once per frame
    void Update()
    {
        TheDistance = PlayerRayCasting.DistanceFromTarget;
    }

    private void OnMouseOver()
    {
        if (TheDistance <=200)
        {
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
            ActionText.GetComponent<Text>().text = "Talk";
        }

        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <=200)
            {
                Screen.lockCursor = false;
                Cursor.visible = true;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
               // ThePlayer.SetActive(false);
                StartCoroutine(NPC001Active());
            }
        }
    }

    private void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }

    IEnumerator NPC001Active()
    {
        TextBox.SetActive(true);
        NPCName.GetComponent<Text>().text = "Roach";
        NPCName.SetActive(true);
        NPCText.GetComponent<Text>().text = "In order for you to open this gate you have to collect all the three keys.";
        NPCText.SetActive(true);
        yield return new WaitForSeconds(5.5f);
        NPCName.SetActive(false);
        NPCText.SetActive(false);
        TextBox.SetActive(false);
        ActionDisplay.SetActive(true);
        ActionText.SetActive(true);
    }
}
