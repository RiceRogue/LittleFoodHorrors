using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotScript : MonoBehaviour
{
    public List<GameObject> recipeIngredients;
    public GameObject[] ingredients;

    public string[] recipes;
    public List<string> recipeIngredientNames;
    public List<GameObject> originalList;
    public List<string> copy;
    public string chosen;

    public bool finalRecipe;
    public GameObject Hamburger;
    public float timer;

    public GameObject Flames;
    public bool flameInstantiated;

    // Start is called before the first frame update
    void Start()
    {
        ingredients = GameObject.FindGameObjectsWithTag("Ingredients");
        finalRecipe = false;
        flameInstantiated = false;
        recipes = new string[3] { "Hamburger", "Sushi", "Taco" };
        recipeIngredientNames = new List<string>();
        chosen = recipes[Random.Range(0, recipes.Length)];
        chosen = "Hamburger";
        if (chosen == "Hamburger")
        {
            recipeIngredientNames = new List<string> { "Cheese", "Tomato", "Steak", "Toast" };
            copy = new List<string> { "Cheese", "Tomato", "Steak", "Toast" };
        }
        

    }

    

    // Update is called once per frame
    void Update()
    {
        
        //No gravity or rigidbody for the pot, due to erratic movement due to physics engine
        if(recipeIngredientNames.Count == 0 && finalRecipe == false)
        {
            timer += Time.deltaTime;
            //All Ingredients are currently colliding with the pot;
            if (flameInstantiated == false)
            {
                for (int i = 0; i < 3; i++)
                {
                    Instantiate(Flames, transform.position + new Vector3(i - 1, -2, 0), transform.rotation);
                }
                flameInstantiated = true;
            }
            if (timer > 30)
            {
                foreach (GameObject go in originalList)
                {
                    DragNDrop dropScript = go.GetComponent<DragNDrop>();
                    go.transform.position = dropScript.originalPosition;

                }

                if (chosen == "Hamburger")
                {
                    foreach(string s in copy)
                    {
                        GameObject go = GameObject.Find(s);
                        Destroy(go);
                        
                    }
                    GameObject[] flames = GameObject.FindGameObjectsWithTag("Fire");
                    foreach(GameObject f in flames)
                    {
                        Destroy(f);
                    }
                    Instantiate(Hamburger, transform.position + new Vector3(0, 1.5f, 0), Hamburger.transform.rotation);
                    finalRecipe = true;
                }
            }
        } 
        
        if(recipeIngredientNames.Count > 0)
        {
            flameInstantiated = false;
            GameObject[] flames = GameObject.FindGameObjectsWithTag("Fire");
            foreach (GameObject f in flames)
            {
                Destroy(f);
            }
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        bool removing = false;
        foreach (string name in recipeIngredientNames)
        {
            if (name == collision.gameObject.name){
                removing = true;
            }

        }

        if (removing)
        {
            recipeIngredientNames.Remove(collision.gameObject.name);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        bool removing = false;
        foreach (string name in recipeIngredientNames)
        {
            if (name == collision.gameObject.name)
            {
                removing = true;
            }

        }

        if (removing)
        {
            recipeIngredientNames.Remove(collision.gameObject.name);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        bool adding = false;

        foreach (string name in copy)
        {
            if (name == collision.gameObject.name)
            {
                adding = true;
            }

        }

        if (adding)
        {
            recipeIngredientNames.Add(collision.gameObject.name);
        }

    }



}
