using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
   public GameObject MenuSlider;
   public GameObject anywhereButton;
   public GameObject anywhereText;

   public void SlideMenu()
   {
      MenuSlider.GetComponent<Animation>().Play("MenuSLide");
      anywhereButton.SetActive(false);
      anywhereText.SetActive(false);
   }

   public void NewGame()
   {
      SceneManager.LoadScene(1);
   }

   public void Exit()
   {
      
   }
}
