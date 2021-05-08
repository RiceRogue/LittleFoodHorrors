using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlateScript : MonoBehaviour
{
    public GameObject pot;
    public List<string> recipes;

    public List<string> recipeIngredientNames;
    public float timer;

    public bool finished;
    // Start is called before the first frame update
    void Start()
    {
        recipes = new List<string>() { "Burger(Clone)", "Maki(Clone)", "Tacos(Clone)" };
        finished = false;
    }

    // Update is called once per frame
    void Update()
    {
        //PotScript potter = pot.GetComponent<PotScript>();
        if(finished == true)
        {
            timer += Time.deltaTime;
            if(timer > 10)
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (string name in recipes)
        {
            if (name == collision.gameObject.name)
            {
                finished = true;
            }

        }

    }

    private void OnCollisionExit(Collision collision)
    {
        timer = 0;

    }
}
