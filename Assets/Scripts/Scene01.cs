using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene01 : MonoBehaviour
{
  public GameObject Camera1;
  public GameObject FadeOut;
  public GameObject FadeIn;
  public GameObject ThePlayer;

   void Start()
  {
    StartCoroutine(CutSceneStart());
  }

   IEnumerator CutSceneStart()
   {
       yield return new WaitForSeconds(4);
       Camera1.SetActive(true);
       FadeIn.SetActive(false);
       yield return new WaitForSeconds(10);
       Camera1.SetActive(false);
       FadeOut.SetActive(true);
       yield return new WaitForSeconds(2);
       ThePlayer.SetActive(true);
       FadeIn.SetActive(true);
       FadeOut.SetActive(false);
       FadeIn.SetActive(false);

       
   }
}
