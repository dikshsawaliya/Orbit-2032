using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestInteraction : MonoBehaviour
{

    public float TheDistance;

    public GameObject TreasureChest;

    public GameObject PowerUp;

    public GameObject ActionDisplay;

    public GameObject ActionText;

    public GameObject TheObjective;

    public int CloseObjective;
    


    // Update is called once per frame
    void Update()
    {
        TheDistance = PlayerRayCasting.DistanceFromTarget;

        if (TheDistance ==3)
        {
            if (TheObjective.transform.localScale.y <= 0.0f)
            {
                CloseObjective = 0;
                TheObjective.SetActive(false);
            }
            else
            {
                TheObjective.transform.localScale = new Vector3(0.0f, 0.1f,0.0f);
            }
        }
        
    }

    private void OnMouseOver()
    {
        if (TheDistance <= 3)
        {
            ActionText.GetComponent<Text>().text = "Open Chest";
            ActionText.SetActive(true);
            ActionDisplay.SetActive(true);
        }

        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <=3)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                TreasureChest.GetComponent<Animation>().Play("ChestOpening");
                PowerUp.GetComponent<Animation>().Play("PowerUpAnimation");
                CloseObjective = 3;
                ActionText.SetActive(false);
                ActionDisplay.SetActive(false);
            }
        }
    }

    private void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }
}
