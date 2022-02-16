using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Collect : MonoBehaviour
{
    [SerializeField] private ProjectileShooting projectileShootingScript;
    

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("dsfggs");
            projectileShootingScript.enabled =true;
            Destroy(gameObject);
        }
    }
}
