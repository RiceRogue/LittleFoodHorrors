using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDrop : MonoBehaviour
{
    // Start is called before the first frame update
    public Material mouseOverColor;
    public Material originalColor;

    private bool dragging = false;
    private float distance;

    void Start()
    {
        originalColor = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging == true)
        {
            //Creates a ray for the mouse and the screen. 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint;
        }

    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0)){
            //COMMENT GITHUB TEST

            //pulled from user Tobias J on unity forum. 
            //https://forum.unity.com/threads/implement-a-drag-and-drop-script-with-c.130515/
            //Essentially drags an object based on mouse enter and exit events, while adjusting the mouse position in relation to the screen. 
            distance = Vector3.Distance(transform.position, Camera.main.transform.position);
            dragging = true;
        } else if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }
    }

    void OnMouseEnter()
    {
        GetComponent<Renderer>().material = mouseOverColor;
    }
    void OnMouseExit()
    {
        GetComponent<Renderer>().material = originalColor;
    }
}
