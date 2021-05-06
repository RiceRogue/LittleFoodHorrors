using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiwiReset : MonoBehaviour
{
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        //Target Hole Layer = 9
        if (collision.gameObject.layer == 9)
        {
            
        }
    }
}
