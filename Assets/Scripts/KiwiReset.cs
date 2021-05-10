using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class KiwiReset : MonoBehaviour
{
    public GameObject target;
    public List<string> objectsGrabbed;
    public bool goHome;
    public bool hasObject;
    public bool reset;
    public float timer;
    public Vector3 originalPosition;

    public CanvasManager canvas;
    public GameObject canvasManager;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        canvas = canvasManager.GetComponent<CanvasManager>();
        objectsGrabbed = new List<string>();
        objectsGrabbed.Add("Test");
        goHome = false;
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Goes to the black hole.
        if (goHome == true)
        {
            GetComponent<NavMeshAgent>().SetDestination(target.transform.position);
        }


        //Resets its position before trying to get another floor ingredient
        if(reset == true)
        {
            GetComponent<BoxCollider>().enabled = false;

            GetComponent<NavMeshAgent>().SetDestination(originalPosition);
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Ingredients"))
            {
                go.GetComponent<DragNDrop>().stole = false;
            }

            timer += Time.deltaTime;
            if (timer > 3)
            {
                reset = false;
                hasObject = false;
                GetComponent<BoxCollider>().enabled = true;
                timer = 0;
            }
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        //Target Hole Layer = 12
        if (collision.gameObject.layer == 12)
        {
            reset = true;
            goHome = false;
            GetComponent<BoxCollider>().enabled = false;
        }

    }

    //Display Hint when mouse is over
    void OnMouseEnter()
    {
        canvas.kiwiHints.enabled = true;

    }

    void OnMouseExit()
    {
        canvas.kiwiHints.enabled = false;
    }
}
