using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 7f;
    }

    // Update is called once per frame
    void Update()
    {
        //If camera is hit by an object
        if(GetComponent<Rigidbody>().velocity.x > 0 || GetComponent<Rigidbody>().velocity.y > 0 || GetComponent<Rigidbody>().velocity.z > 0)
        {
            //kind of like getting stunned
            timer += Time.deltaTime;
            if (timer > 3)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                timer = 0;
            }

        }
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        transform.Translate(Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical") * moveSpeed);
        
        transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal") * moveSpeed);

        //Making the camera move Up
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
        }

        //Making the camera move directly down
        if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(-Vector3.up * Time.deltaTime * moveSpeed);
        }
    }
}
