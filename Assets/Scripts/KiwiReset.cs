using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class KiwiReset : MonoBehaviour
{
    public GameObject target;
    public bool goHome;
    public bool hasObject;
    public bool reset;
    public float timer;
    public Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;

        goHome = false;
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (goHome == true)
        {
            GetComponent<NavMeshAgent>().SetDestination(target.transform.position);
        }

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
        //Target Hole Layer = 9
        if (collision.gameObject.layer == 9)
        {
            reset = true;
            goHome = false;
            
            GetComponent<BoxCollider>().enabled = false;
        }




    }
}
