using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class CanvasManager : MonoBehaviour
{
    public TextMeshProUGUI recipeText;
    public TextMeshProUGUI potHints;
    public TextMeshProUGUI plateHints;
    public TextMeshProUGUI kiwiHints;
    public TextMeshProUGUI chiliHints;
    public TextMeshProUGUI eggyHints;


    public TextMeshProUGUI omnom;

    public TextMeshProUGUI timeScore;
    public TextMeshProUGUI HighScore;
    public bool scoring;



    public GameObject pot;
    public PotScript potter;

    public bool recipeShown;
    public bool recipeEnd;
    public float timer;


    public Image timerBar;
    public float maxTime;
    public float timeLeft;
    public bool reloading;

    public float filler;

    public float timeScored;

    // Start is called before the first frame update
    void Start()
    {
        omnom.enabled = false;
        potter = pot.GetComponent<PotScript>();
        recipeShown = false;
        recipeEnd = false;
        timer = 0;
        potHints.enabled = false;
        plateHints.enabled = false;
        kiwiHints.enabled = false;
        chiliHints.enabled = false;
        eggyHints.enabled = false;


        timeLeft = 0;
        maxTime = 0;
        timerBar = timerBar.GetComponent<Image>();

        timerBar.enabled = false;
        timerBar.fillAmount = 0f;
        reloading = false;
        timeScored = 0;

        scoring = true;
        HighScore.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (scoring == true)
        {
            //timer as a form of score;
            timeScored += Time.deltaTime;
            timeScore.text = "TimeScore: " + timeScored.ToString("F2");
        }

        //Show FUnny omnom Text
        filler = timerBar.fillAmount;
        if(recipeShown == false)
        {
            recipeText.text = potter.chosen + "\n recipe \n";
            foreach(string ingredient in potter.copy)
            {
                recipeText.text += "\n" + ingredient;
            }
            recipeShown = true;
            
        }
        //Ten seconds to wait to disable the recipe shown. 
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

        //Display the recipe
        if (Input.GetKey(KeyCode.R))
        {
            recipeText.enabled = true;
        }
        else if (recipeEnd == true)
        {
            recipeText.enabled = false;
        }
        
        //Image bar display for cooking and plating the dish
        if (reloading == true)
        {
            timerBar.enabled = true;
            if (timeLeft < maxTime)
            {
                timeLeft += Time.deltaTime;
                timerBar.fillAmount = timeLeft / maxTime;
            }
            else
            {
                timeLeft = 0;
                timerBar.enabled = false;
                reloading = false;
            }
        }

    }
}
