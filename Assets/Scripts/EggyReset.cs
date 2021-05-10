using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EggyReset : MonoBehaviour
{
    public GameObject[] throwings;
    public List<GameObject> listThrow;
    public GameObject target;
    public GameObject throwing;
    public Camera cam;
    public float timer;
    public float timer2;

    public bool toss;
    public bool reset;
    public bool tossit;

    public Vector3 originalPosition;
    public CanvasManager canvas;
    public GameObject canvasManager;
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        timer2 = 0;
        tossit = false;
        listThrow = new List<GameObject>();
        throwings = GameObject.FindGameObjectsWithTag("Throw");
        foreach(GameObject go in throwings)
        {
            listThrow.Add(go);
        }
        canvas = canvasManager.GetComponent<CanvasManager>();
        originalPosition = transform.position;
        agent = GetComponent<NavMeshAgent>();
        throwing = listThrow[Random.Range(0, throwings.Length-1)];


    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        

        if (timer > 45)
        {
            throwing = listThrow[Random.Range(0, throwings.Length-1)];
            reset = false;
            toss = true;
            timer = 0;
        }

        if (toss)
        {
            agent.SetDestination(throwing.transform.position);
        }

        if (tossit)
        {
            
            Vector3 direction = (cam.transform.position - throwing.transform.position).normalized;
            throwing.transform.LookAt(cam.transform.position + new Vector3(0, 1f, 0));
            //throwing.gameObject.GetComponent<Rigidbody>().MovePosition(cam.transform.position + direction * 0.01f * Time.deltaTime);
            throwing.gameObject.GetComponent<Rigidbody>().AddForce(direction* 2060f * Time.deltaTime + new Vector3(0, 2, 0));

            timer2 += Time.deltaTime;
            if (timer2 > 3)
            {
                tossit = false;
                reset = true;
            }
        }

        if (reset)
        {
            agent.SetDestination(originalPosition);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == throwing.name)
        {
            collision.gameObject.transform.rotation = collision.gameObject.GetComponent<DragNDrop>().originalRotation;
            listThrow.Remove(collision.gameObject);
            tossit = true;
            
            
            timer = 0;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == throwing.name)
        {
            reset = true;
        }

        if (collision.gameObject.layer == 11)
        {
            listThrow.Remove(collision.gameObject);
        }

     }
    //Display Hint when mouse is over
    void OnMouseEnter()
    {
        canvas.eggyHints.enabled = true;

    }

    void OnMouseExit()
    {
        canvas.eggyHints.enabled = false;
    }
}
