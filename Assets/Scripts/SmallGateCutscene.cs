using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallGateCutscene : MonoBehaviour
{
   // public GameObject Player;

    public GameObject CutScene;
    public GameObject GateDestroy;

    private void OnTriggerEnter(Collider other)
    {
       this.gameObject.GetComponent<BoxCollider>().enabled = false;
        CutScene.SetActive(true);
        GateDestroy.SetActive(false);
        //Player.SetActive(false);
        StartCoroutine(FinishCut());
        
    }

    IEnumerator FinishCut()
    {
        yield return new WaitForSeconds(3);
       // Player.SetActive(true);
        CutScene.SetActive(false);
    }
}
