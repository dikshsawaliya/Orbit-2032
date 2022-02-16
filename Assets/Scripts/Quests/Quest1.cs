using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Quest1 : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject UIQuest;
    public GameObject ThePlayer;
    public GameObject NoticeCam;

    // Update is called once per frame
    void Update()
    {
        TheDistance = PlayerRayCasting.DistanceFromTarget;
    }

    private void OnMouseOver()
    {
        if (TheDistance <=3)
        {
            
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
        }

        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <=3)
            {
                Screen.lockCursor = false;
                Cursor.visible = true;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                UIQuest.SetActive(true);
                NoticeCam.SetActive(true);
                ThePlayer.SetActive(false);
                MasterQuest.mainQuestName = "Find the PowerUp";
                MasterQuest.mainQuestInfo = "What the hell happened here ? What is this place ? You need to find the answers.";
            }
        }
    }

    private void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }
}
