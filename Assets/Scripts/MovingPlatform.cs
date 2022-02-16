using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public float t;
    public float speed = 1f;
    public float speedMultiplier;


    private void Start()
    {
        speedMultiplier = speed / Vector3.Distance(start.position, end.position);
    }

    // Update is called once per frame
    void Update()
    {
        speedMultiplier = speed / Vector3.Distance(start.position, end.position);
        t = t + Time.deltaTime;

        float cosT = (Mathf.Cos(t * Mathf.PI / speedMultiplier) + 1) / 2;

        transform.position = start.position * (1 - cosT) + end.position * cosT;
    }
}
