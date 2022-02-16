using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    public bool invOpen = false;
    public GameObject invMenu;
    public GameObject Sound;

    public GameObject itemPanel;
    public GameObject questsPanel;
    public GameObject statsPanel;

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (invOpen == false)
            {
                Time.timeScale = 0;
                invOpen = true;
                Cursor.visible = true;
                invMenu.SetActive(true);
                Sound.SetActive(false);
            }
            else
            {
                invMenu.SetActive(false);
                Cursor.visible = false;
                invOpen = false;
                Time.timeScale = 1;
                Sound.SetActive(true);

            }
        }
    }

    public void ShowItem()
    {
        itemPanel.SetActive(true);
        statsPanel.SetActive(false);
        questsPanel.SetActive(false);
    }
    
    public void ShowQuests()
    {
        itemPanel.SetActive(false);
        statsPanel.SetActive(false);
        questsPanel.SetActive(true);
    }
    
    public void ShowStats()
    {
        itemPanel.SetActive(false);
        statsPanel.SetActive(true);
        questsPanel.SetActive(false);
    }

    public void Close()
    {
        invMenu.SetActive(false);
        Cursor.visible = false;
        invOpen = false;
        Time.timeScale = 1;
        Sound.SetActive(true);
    }
}
