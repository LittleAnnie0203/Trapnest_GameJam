using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejemplo1 : MonoBehaviour
{
    // Start is called before the first frame update

    //[SerializeField] GameObject obj; 
    MeshRenderer mesh;
    void Start()
    {
        //obj = GameObject.Find("Cube");
        mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown("q"))
            {  
                //obj.GetComponent<MeshRenderer>().enabled = false;
                //mesh.enabled=false;
                gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
 
            if (Input.GetKeyDown("e")) {
            {
                //obj.GetComponent<MeshRenderer>().enabled = true;
                //mesh.enabled = false;
                gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
}


