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
    public float timer2;

    public float timer3Final;

    public bool finished;

    public CanvasManager canvas;
    public GameObject canvasManager;
    // Start is called before the first frame update
    void Start()
    {
        recipes = new List<string>() { "Burger(Clone)", "Maki(Clone)", "Tacos(Clone)", "Tempura(Clone)", "Mochi(Clone)", "Omelette(Clone)", "Donut(Clone)" };
        finished = false;
        canvas = canvasManager.GetComponent<CanvasManager>();

    }

    // Update is called once per frame
    void Update()
    {
        //PotScript potter = pot.GetComponent<PotScript>();
        if(finished == true)
        {
            timer += Time.deltaTime;

            //funny cute eating text to show that you are eating every second the food is on the plate.
            canvas.omnom.enabled = true;
            timer2 += Time.deltaTime;
            if (timer2 > 1)
            {
                canvas.omnom.text += "\nOm Nom";
                timer2 = 0;
            }
            //begins image timer
            canvas.maxTime = 10;
            canvas.reloading = true;
            if (timer > canvas.maxTime)
            {
                //Display final score before waiting to restart level
                canvas.reloading = false;

                canvas.HighScore.enabled = true;
                canvas.omnom.enabled = false;
                
                canvas.scoring = false;
                timer3Final += Time.deltaTime;
                canvas.HighScore.text = "Congratulations, you made your meal in " + canvas.timeScored.ToString("F2") + " seconds";

                if (timer3Final > 8)
                {
                    SceneManager.LoadScene("SampleScene");
                }
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
        finished = false;

    }

    void OnMouseEnter()
    {
        canvas.plateHints.enabled = true;

    }

    void OnMouseExit()
    {
        canvas.plateHints.enabled = false;
    }
}
