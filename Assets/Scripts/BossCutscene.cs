using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCutscene : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject cutCam;
    public GameObject cutBars;
    //public GameObject theCursor;
    public GameObject fadeIn;
    public GameObject fadeOut;
    private void OnTriggerEnter(Collider other)
    {
        this.GetComponent<BoxCollider>().enabled = false;
        fadeOut.SetActive(true);
        StartCoroutine(BossCutScene());
    }

    IEnumerator BossCutScene()
    {
        yield return new WaitForSeconds(2);
        fadeOut.SetActive(false);
        cutCam.SetActive(true);
        cutBars.SetActive(true);
        thePlayer.SetActive(false);
       // theCursor.SetActive(false);
        fadeIn.GetComponent<Animation>().Play("FadeScreenIn");
        yield return new WaitForSeconds(6);
        fadeOut.SetActive(true);
        fadeOut.GetComponent<Animation>().Play("FadeScreenOut");
        yield return new WaitForSeconds(2);
        thePlayer.SetActive(true);
        cutCam.SetActive(false);
        cutBars.SetActive(false);
        fadeOut.SetActive(false);

       // theCursor.SetActive(true);
    }
}
