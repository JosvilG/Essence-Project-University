using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObrePorta : MonoBehaviour
{
    public GameObject porta;
    private bool obrir = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   /* void OnCollisionEnter(Collision other)
    {
        Debug.Log("Fa falta una clau");
        if (other.collider.tag == "Player" && HUD.numClaus >= 1)
        {
            HUD.numClaus--;
            Destroy(this.gameObject);

        }
        if (other.collider.tag == "Player" && HUD.numClaus < 1)
        {
            Debug.Log("Fa falta una clau");
        }
    }*/

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && HUD.numClaus >= 1 && obrir==true)
        {
            HUD.numClaus-=1;
            obrir = false;
            Destroy(porta.gameObject);

        }
       
        
            
    }

}
