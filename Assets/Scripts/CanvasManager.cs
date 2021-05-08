using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public TextMeshProUGUI recipeText;
    public TextMeshProUGUI potHints;
    public TextMeshProUGUI plateHints;


    public GameObject pot;
    public PotScript potter;

    public bool recipeShown;
    public bool recipeEnd;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        potter = pot.GetComponent<PotScript>();
        recipeShown = false;
        recipeEnd = false;
        timer = 0;
        potHints.enabled = false;
        plateHints.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(recipeShown == false)
        {
            recipeText.text = potter.chosen + "\n recipe \n";
            foreach(string ingredient in potter.copy)
            {
                recipeText.text += "\n" + ingredient;
            }
            recipeShown = true;
            
        }

        if(timer < 10)
        {
            timer += Time.deltaTime;
            recipeText.enabled = true;
            
        } else if(timer > 10 && recipeEnd == false)
        {
            recipeText.enabled = false;
            timer = 11;
            recipeEnd = true;
            
        }


        if (Input.GetKey(KeyCode.R))
        {
            recipeText.enabled = true;
        }
        else if (recipeEnd == true)
        {
            recipeText.enabled = false;
        }



    }
}
