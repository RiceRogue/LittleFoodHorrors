using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ChiliReset : MonoBehaviour
{
    public GameObject[] ingredients;
    public GameObject target;
    public GameObject ingredient;
    public GameObject kiwi;
    public float timer;
    public float moveSpeed;
    public Vector3 originalPosition;
    public Quaternion originalRotation;


    public bool reset;
    public bool stealing;
    public bool traveling;

    public CanvasManager canvas;
    public GameObject canvasManager;
    public GameObject colliding;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        ingredients = GameObject.FindGameObjectsWithTag("Ingredients");
        kiwi = GameObject.Find("KiwiMonster");
        moveSpeed = 1.2f;
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        reset = false;
        stealing = false;
        traveling = false;
        
        canvas = canvasManager.GetComponent<CanvasManager>();

    }

    // Update is called once per frame
    void Update()
    {
        target.transform.position = kiwi.transform.position + new Vector3(0,45,0);
        
        timer += Time.deltaTime;
        transform.rotation = originalRotation;

        if (timer > 30)
        {
            ingredient = ingredients[Random.Range(0, ingredients.Length)];
            //in case the chili is trying to grab the same object that the kiwi monster has in his hand. 
            if (kiwi.GetComponent<KiwiReset>().objectsGrabbed.Count > 0)
            {
                if (ingredient.name == kiwi.GetComponent<KiwiReset>().objectsGrabbed[kiwi.GetComponent<KiwiReset>().objectsGrabbed.Count - 1])
                {
                    for (int i = 0; i < 100; i++)
                    {
                        ingredient = ingredients[Random.Range(0, ingredients.Length)];
                    }
                }
            }
            reset = false;
            stealing = true;
            timer = 0;
        }

        

        //Resets its position to original
        if (reset == true)
        {
            transform.position = Vector3.Lerp(transform.position, originalPosition, Time.deltaTime * moveSpeed);

            if(Vector3.Distance(transform.position, originalPosition) < 2)
            {
                reset = false;
            }
        }

        //Player wil not be allowed to take ingredients from the Chili pepper!
        if(traveling == true)
        {
            reset = false;
            transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * moveSpeed);
            ingredient.transform.position = transform.position + new Vector3(0, -1, 0);
        }

        //Stealing the ingredients
        if (stealing == true)
        {
            transform.position = Vector3.Lerp(transform.position, ingredient.transform.position, Time.deltaTime * moveSpeed);
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == ingredient.name)
        {
            traveling = true;
            stealing = false;
            timer = 0;
            colliding = collision.gameObject;
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;

        }


        //Touches the end goal
        if (collision.gameObject.layer == 9)
        {
            timer = 0;
            reset = true;
            traveling = false;
            colliding.GetComponent<BoxCollider>().enabled = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        //If ingredient leaves the chili, chili resets to original posiiton.
        if (collision.gameObject.name == ingredient.name)
        {
            reset = true;
            stealing = false;
        }
    }

    //Display Hint when mouse is over
    void OnMouseEnter()
    {
        canvas.chiliHints.enabled = true;

    }

    void OnMouseExit()
    {
        canvas.chiliHints.enabled = false;
    }

}
