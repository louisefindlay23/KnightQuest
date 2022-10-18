using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    private int speed;
    Animator hero_Animator;
    
     // Use this for initialization
     void Start () {
     hero_Animator = gameObject.GetComponent<Animator>();
     }
     
     // Update is called once per frame
     void Update () {
     
     if (Input.GetKey(KeyCode.L))
            Cursor.lockState = CursorLockMode.None;
            
        if (!hero_Animator.GetBool("Die")) {
            // Player movement using Keyboard - Left and Right rotate
            if (Input.GetKey (KeyCode.W)) {
                speed += 1;
                transform.Translate (Vector3.forward * speed * Time.deltaTime);
                // Debug.Log ("Speed is " + speed);

                if (speed > 10) {
                    speed = 10;
                }

             } else if (Input.GetKeyUp (KeyCode.W)) {
                speed = 0;
             }

             if (Input.GetKey (KeyCode.A)) {
                speed = 25;
                transform.Rotate (new Vector3 (0, Time.deltaTime * -5 * speed, 0));
            } else if (Input.GetKeyUp (KeyCode.A)) {
                speed = 0;
            }
            
            if (Input.GetKey (KeyCode.D)) {
                speed = 25;
                transform.Rotate (new Vector3 (0, Time.deltaTime * 5 * speed, 0));
            } else if (Input.GetKeyUp (KeyCode.D)) {
                speed = 0;
            }

            if (Input.GetKey (KeyCode.LeftShift)) {
                transform.Translate(Vector3.up * 260 * Time.deltaTime, Space.World);
            }

            GetComponent<Animator>().SetInteger ("speed", speed);

        }
        
    }

}
