
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KiwiScript : MonoBehaviour
{
    public float timer;
    public List<GameObject> FloorIngredients;
    public GameObject ingredient;
    public bool beginWalk;
    public bool beginSteal;

    public GameObject target;

    public float moveSpeed;

    public GameObject kiwi;
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        moveSpeed = 3f;
        target = GameObject.Find("KiwiHole");
        FloorIngredients = new List<GameObject>();
        agent = kiwi.GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        //ingredient layer = 8
        if (collision.gameObject.layer == 8)
        {
            FloorIngredients.Add(collision.gameObject);
            ingredient = FloorIngredients[Random.Range(0, FloorIngredients.Count)];
            agent.SetDestination(ingredient.transform.position);

            if (Vector3.Distance(kiwi.transform.position, ingredient.transform.position) < 2)
            {
                ingredient.transform.position = Vector3.Lerp(ingredient.transform.position, kiwi.transform.position, Time.deltaTime * moveSpeed);
                agent.SetDestination(target.transform.position);

            }
        }
    }
}
