using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private float mouseSensitivity;


    private Transform parent;
   // public Keypad keypadScript;

    
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Cursor.lockState = CursorLockMode.Locked;

        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Cursor.lockState = CursorLockMode.None;

        }
        
       // if (keypadScript.MouseVisiblity == false)
     //   {
     //       Cursor.lockState = CursorLockMode.Locked;
       // }
        Rotate();
    }
    
    private void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        parent.Rotate(Vector3.up, mouseX);
        
        
        //float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
      // parent.Rotate(Vector3.right, mouseY);    
    }
}