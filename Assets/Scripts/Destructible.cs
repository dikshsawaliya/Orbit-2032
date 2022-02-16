using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{

  public GameObject DestroyedVersion;
  public GameObject Key;
  private void OnCollisionEnter(Collision col)
  {
    if (col.gameObject.tag == "Bullet")
    {
      Instantiate(DestroyedVersion, transform.position, transform.rotation);
      Key.SetActive(true);
      Destroy(gameObject);
    }    
  }
}
