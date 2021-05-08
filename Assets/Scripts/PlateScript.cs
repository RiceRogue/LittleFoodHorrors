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
            //begins image timer
            canvas.maxTime = 10;
            canvas.reloading = true;
            if (timer > canvas.maxTime)
            {
                canvas.timerBar.enabled = false;
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
