using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivaInterruptor : MonoBehaviour
{
    public GameObject clauFinal;
    private bool comprovacio = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Arma" && comprovacio==false)
        {
            clauFinal.SetActive(true);
            comprovacio = true;//perque no salti missatge d'error
        }
        

    }
}
