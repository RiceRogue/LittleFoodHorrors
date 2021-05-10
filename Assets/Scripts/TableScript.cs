using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableScript : MonoBehaviour
{
    public GameObject eggy;
    public EggyReset eReset;
    // Start is called before the first frame update
    void Start()
    {
        eReset = eggy.GetComponent<EggyReset>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 13)
        {
            eReset.listThrow.Remove(collision.gameObject);
        }
    }
    
}

