using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalXP : MonoBehaviour
{
   public static int CurrentLevel = 1;
   public int Internallevel;

   private void Update()
   {
      Internallevel = CurrentLevel;
   }
}
