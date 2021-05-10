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

    public Vector3 originalPosition;
    public Quaternion originalRotation;

    public bool stole;
    public bool respawn;

    public GameObject kiwiMonster;
    public GameObject hole;

    public float timer;
    void Start()
    {
        originalColor = GetComponent<Renderer>().material;
        stole = false;
        kiwiMonster = GameObject.Find("KiwiMonster");
        respawn = false;
        timer = 0;
    }

    private void Awake()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
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

        if (stole)
        {
            kiwiMonster.GetComponent<KiwiReset>().hasObject = true;
            transform.rotation = originalRotation;
            transform.position = kiwiMonster.transform.position + new Vector3(0, 7, 0);
        }

        if (respawn)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            timer += Time.deltaTime;
            if(timer > 5)
            {
                
                gameObject.GetComponent<MeshRenderer>().enabled = true;
                timer = 0;
                respawn = false;
            }
        }
            
        


    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //COMMENT GITHUB TEST

            //pulled from user Tobias J on unity forum. 
            //https://forum.unity.com/threads/implement-a-drag-and-drop-script-with-c.130515/
            //Essentially drags an object based on mouse enter and exit events, while adjusting the mouse position in relation to the screen. 
            distance = Vector3.Distance(transform.position, Camera.main.transform.position);
            dragging = true;
            stole = false;
            kiwiMonster.GetComponent<KiwiReset>().hasObject = false;
            kiwiMonster.GetComponent<KiwiReset>().goHome = false;
            kiwiMonster.GetComponent<KiwiReset>().reset = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
            stole = false;

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


    void OnCollisionEnter(Collision collision)
    {
        //specifically the kiwi monster layer
        if (collision.gameObject.layer == 11 && collision.gameObject.GetComponent<KiwiReset>().hasObject == false && this.gameObject.layer ==8)
        {
            stole = true;

            collision.gameObject.GetComponent<KiwiReset>().hasObject = true;
            collision.gameObject.GetComponent<KiwiReset>().goHome = true;
            collision.gameObject.GetComponent<KiwiReset>().objectsGrabbed.Add(transform.name);


        }

        //hole layer
        if(collision.gameObject.layer == 9)
        {
            transform.rotation = originalRotation;
            transform.position = originalPosition;
            respawn = true;
        }
    }
}
