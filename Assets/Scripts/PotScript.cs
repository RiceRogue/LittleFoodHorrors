using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    public GameObject Sushi;
    public GameObject Taco;
    public GameObject Donut;
    public GameObject Mochi;
    public GameObject Tempura;
    public GameObject Omelette;
    

    public float timer;

    public GameObject Flames;
    public bool flameInstantiated;


    public CanvasManager canvas;
    public GameObject canvasManager;

    // Start is called before the first frame update
    void Start()
    {
        ingredients = GameObject.FindGameObjectsWithTag("Ingredients");
        finalRecipe = false;
        flameInstantiated = false;
        recipes = new string[7] { "Hamburger", "Sushi", "Taco", "Donut", "Tempura", "Omelette", "Mochi" };
        recipeIngredientNames = new List<string>();
        chosen = recipes[Random.Range(0, recipes.Length)];
        

        canvas = canvasManager.GetComponent<CanvasManager>();
        if (chosen == "Hamburger")
        {
            recipeIngredientNames = new List<string> { "Cheese", "Tomato", "Steak", "Toast" };
            copy = new List<string> { "Cheese", "Tomato", "Steak", "Toast" };
        } else if (chosen == "Sushi")
        {
            recipeIngredientNames = new List<string> { "Shrimp", "Lettuce", "Rice" };
            copy = new List<string> { "Shrimp", "Lettuce", "Rice" };
        } else if (chosen == "Taco")
        {
            recipeIngredientNames = new List<string> { "Cheese", "Chicken", "Lettuce", "Toast" };
            copy = new List<string> { "Cheese", "Chicken", "Lettuce", "Toast" };
        } else if (chosen == "Donut")
        {
            recipeIngredientNames = new List<string> { "Toast", "Icecream", "Egg" };
            copy = new List<string> { "Toast", "Icecream", "Egg" };
        } else if (chosen == "Tempura")
        {
            recipeIngredientNames = new List<string> { "Egg", "Shrimp", "Toast"};
            copy = new List<string> { "Egg", "Shrimp", "Toast" };
        } else if (chosen == "Omelette")
        {
            recipeIngredientNames = new List<string> { "Egg", "Tomato", "Cheese", "Pepper" };
            copy = new List<string> { "Egg", "Tomato", "Cheese", "Pepper" };
        }
        else if (chosen == "Mochi")
        {
            recipeIngredientNames = new List<string> { "Rice", "Icecream", "Cheese", "Wine" };
            copy = new List<string> { "Rice", "Icecream", "Cheese", "Wine" };
        }


    }



    // Update is called once per frame
    void Update()
    {

        //No gravity or rigidbody for the pot, due to erratic movement due to physics engine
        if (recipeIngredientNames.Count == 0 && finalRecipe == false)
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
                foreach (string s in copy)
                {
                    GameObject go = GameObject.Find(s);
                    Destroy(go);

                }
                GameObject[] flames = GameObject.FindGameObjectsWithTag("Fire");
                foreach (GameObject f in flames)
                {
                    Destroy(f);
                }

                if (chosen == "Hamburger")
                {
                    Instantiate(Hamburger, transform.position + new Vector3(0, 1.5f, 0), Hamburger.transform.rotation);
                    finalRecipe = true;
                } else if (chosen == "Sushi")
                {
                    Instantiate(Sushi, transform.position + new Vector3(0, 1.5f, 0), Sushi.transform.rotation);
                    finalRecipe = true;
                } else if (chosen == "Taco")
                {
                    Instantiate(Taco, transform.position + new Vector3(0, 1.5f, 0), Taco.transform.rotation);
                    finalRecipe = true;
                }
                else if (chosen == "Tempura")
                {
                    Instantiate(Tempura, transform.position + new Vector3(0, 1.5f, 0), Tempura.transform.rotation);
                    finalRecipe = true;
                }
                else if (chosen == "Donut")
                {
                    Instantiate(Donut, transform.position + new Vector3(0, 1.5f, 0), Donut.transform.rotation);
                    finalRecipe = true;
                }
                else if (chosen == "Omelette")
                {
                    Instantiate(Omelette, transform.position + new Vector3(0, 1.5f, 0), Omelette.transform.rotation);
                    finalRecipe = true;
                }
                else if (chosen == "Mochi")
                {
                    Instantiate(Mochi, transform.position + new Vector3(0, 1.5f, 0), Mochi.transform.rotation);
                    finalRecipe = true;
                }
            }
        }

        if (recipeIngredientNames.Count > 0)
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


    void OnMouseEnter()
    {
        canvas.potHints.enabled = true;

    }

    void OnMouseExit()
    {
        canvas.potHints.enabled = false;
    }
}
