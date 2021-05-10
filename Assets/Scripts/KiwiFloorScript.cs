
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KiwiFloorScript : MonoBehaviour
{
    public float timer;
    public float timerDrinks;
    public List<GameObject> FloorIngredients;
    public GameObject ingredient;
    public bool beginWalk;
    public bool beginSteal;


    public float moveSpeed;

    public GameObject kiwi;
    public NavMeshAgent agent;
    public bool following;

    public GameObject eggy;
    public EggyReset eReset;
    // Start is called before the first frame update
    void Start()
    {
        eReset = eggy.GetComponent<EggyReset>();

        timer = 0;
        moveSpeed = 5f;
        FloorIngredients = new List<GameObject>();
        agent = kiwi.GetComponent<NavMeshAgent>();
        following = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        //ingredient layer = 8 for ingredients
        if (collision.gameObject.layer == 8)
        {
            FloorIngredients.Add(collision.gameObject);
            ingredient = FloorIngredients[Random.Range(0, FloorIngredients.Count)];

           
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        //Adds to a list of ingredients on the floor. Kiwi monster chooses a random one and will go to grab it. 
        if (FloorIngredients.Count > 0 && GameObject.Find("KiwiMonster").GetComponent<KiwiReset>().hasObject == false)
        {
            GameObject.Find("KiwiMonster").GetComponent<KiwiReset>().reset = false;
            GameObject.Find("KiwiMonster").GetComponent<BoxCollider>().enabled = true;
            agent.SetDestination(ingredient.transform.position);

        }

        //Throwable drinks layer
        if(collision.gameObject.layer == 13)
        {
            timerDrinks += Time.deltaTime;
            if (timerDrinks > 20)
            {
                eReset.listThrow.Add(collision.gameObject);

                collision.gameObject.transform.position = collision.gameObject.GetComponent<DragNDrop>().originalPosition;
                timer = 0;
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        FloorIngredients.Remove(collision.gameObject);
    }
}
