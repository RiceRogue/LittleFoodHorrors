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
    // Start is called before the first frame update
    void Start()
    {
        ingredients = GameObject.FindGameObjectsWithTag("Ingredients");
        finalRecipe = false;
        recipes = new string[3] { "Hamburger", "Sushi", "Taco" };
        recipeIngredientNames = new List<string>();
        chosen = recipes[Random.Range(0, recipes.Length)];
        chosen = "Hamburger";
        if (chosen == "Hamburger")
        {
            recipeIngredientNames = new List<string> { "Cheese", "Tomato", "Steak", "Toast" };
        }
        copy = recipeIngredientNames;

    }

    

    // Update is called once per frame
    void Update()
    {
        
        //No gravity or rigidbody for the pot, due to erratic movement due to physics engine
        if(recipeIngredientNames.Count == 0 && finalRecipe == false)
        {
            //All Ingredients are currently colliding with the pot;
            foreach(GameObject go in originalList)
            {
                DragNDrop dropScript = go.GetComponent<DragNDrop>();
                go.transform.position = dropScript.originalPosition;
                
            }

            if (chosen == "Hamburger")
            {
                Instantiate(Hamburger, transform.position + new Vector3(0, 1.5f, 0), Hamburger.transform.rotation);
                finalRecipe = true;
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
