using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseFollow : MonoBehaviour
{
    public float turnSpeed = 4.0f;

    public GameObject target;
    private float targetDistance;

    public float minTurnAngleX;
    public float maxTurnAngleX;


    private float rotX;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {

        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        minTurnAngleX = -50.0f;
        maxTurnAngleX = 50.0f;

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 rayPoint = ray.GetPoint(distance);

        //Taken from https://gamedevacademy.org/unity-3d-first-and-third-person-view-tutorial/#Section_2_Third_Person_Perspective
        //This essentially moves the camera's rotation and position to remain around a good range for third person perspective. 
        float y = Input.GetAxis("Mouse X") * turnSpeed;
        rotX += Input.GetAxis("Mouse Y") * turnSpeed;

        //clamps the movement or angles of the camera
        //Taken from https://gamedevacademy.org/unity-3d-first-and-third-person-view-tutorial/#Section_2_Third_Person_Perspective
        //This essentially moves the camera's rotation and position to remain around a good range for third person perspective. 

        rotX = Mathf.Clamp(rotX, minTurnAngleX, maxTurnAngleX);

        transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);

        //Adjusts how close the camera is, by multiplying the distance by a constant. 
        //transform.position = rayPoint - (transform.forward * distance * 0.65f) + (transform.up * 2f);


    }
}
