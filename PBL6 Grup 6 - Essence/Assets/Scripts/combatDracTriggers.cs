using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatDracTriggers : MonoBehaviour
{
    public GameObject pont;
    public GameObject camaraMarxaPont;
    public GameObject camaraCombat;

    void OnTriggerEnter(Collider other)
    {
        if(this.name== "triggerMou1" && other.tag=="Player" && Dragon.fase1 == true)
        {
            
            pont.SetActive(false);
            camaraMarxaPont.SetActive(true);
            StartCoroutine(MostraPont(3f));
        }

        if (this.name == "puntDebil" && other.tag == "Arma" && Dragon.dracVulnerable == true)
        {
            Dragon.hp--;
            Dragon.dracVulnerable = false;
            Dragon.acabaVulnerable = true;
            
        }
        if (this.name == "atacDrac" && other.tag == "Player")
        {
            PlayerControl.hit = true;
        }
    }


    IEnumerator MostraPont(float segons)
    {
        yield return new WaitForSeconds(segons);
        camaraCombat.SetActive(true);
        camaraMarxaPont.SetActive(false);
        StartCoroutine(IniciaCombat(3f));
    }

    IEnumerator IniciaCombat(float segons)
    {
        yield return new WaitForSeconds(segons);
        Dragon.volar = true;
    }

}
