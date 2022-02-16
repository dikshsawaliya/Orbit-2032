using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartRotation : MonoBehaviour
{

    public int  RotateSpeed;
    public AudioSource CollectSound;
    public GameObject ThisHeart;
    

    // Update is called once per frame
    void Update()
    {
        RotateSpeed = 1;
        transform.Rotate(0, RotateSpeed,0 , Space.World);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        CollectSound.Play();
        HeartCollect.HealthValue += 1;
        ThisHeart.SetActive(false);
    }
}
