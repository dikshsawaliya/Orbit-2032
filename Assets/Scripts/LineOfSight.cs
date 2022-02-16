using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{

    private float speed = 2f;
    private float visDistance = 20f;
    private float  visAngle = 30f;
    private float shootDistance = 5f;

    private string state = "Idle";
    
    // Start is called before the first frame update
    void Start()
    {
        //Vector3 direction = player.position - this.transform.position;
        ///float angle = Vector3.Angle(direction, this.transform.forward);

        //if (direction < visDistance)
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
