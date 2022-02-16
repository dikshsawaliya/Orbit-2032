using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Box : MonoBehaviour
{
    public GameObject waterfall;
    public ParticleSystem[] waterfall1;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            for (int i = 0; i < 5; i++)
            {
                waterfall1[i].loop = false;
            }
            waterfall.SetActive(false);
            
        }
    }
}
