using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
   public float  RotateSpeed;
   void Update()
   {
      RotateSpeed = 0.5f;
      transform.Rotate(0, RotateSpeed,0 , Space.World);
        
   }
   private void OnTriggerEnter(Collider collision)
   {
      if (collision.gameObject.tag == "DestroyObject")
      {
         Destroy(collision.gameObject);
      }
   }

   
}
