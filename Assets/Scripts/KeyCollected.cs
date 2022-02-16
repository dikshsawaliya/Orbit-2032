using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class KeyCollected : MonoBehaviour
{
   [SerializeField] private bool key1;

    [SerializeField] private bool key2;

    [SerializeField] private bool key3;
    [SerializeField] private bool magicStone;

    public Animator anim;

    public GameObject gatedestroy;
    public GameObject GateEndDestroy;
  

    private void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Key1")
        {
            key1 = true;
            Destroy(collision.gameObject);
        }
        
        if (collision.gameObject.name == "Key2")
        {
            key2 = true;
            Destroy(collision.gameObject);
        }
        
        if (collision.gameObject.name == "Key3")
        {
            key3 = true;
            Destroy(collision.gameObject);
        }
        
        if (collision.gameObject.name == "Magic Stone")
        {
            magicStone = true;
            Destroy(collision.gameObject);
        }
        
       /* if (magicStone == true)
        {
            gatedestroy.SetActive(false);
        }*/
        
        
        //if (collision.gameObject.name == "Pedestal")
      //  {
            if (key1 == true && key2 == true && key3 == true && magicStone == true)
            {
               Destroy(GateEndDestroy);
                //GateEndDestroy.SetActive(false);
                // anim.SetBool("Open", true);
             }
            
            
        //}
    }
}
