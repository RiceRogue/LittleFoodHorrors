using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChiliReset : MonoBehaviour
{
    public GameObject[] ingredients;
    // Start is called before the first frame update
    void Start()
    {
        ingredients = GameObject.FindGameObjectsWithTag("Ingredients");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
