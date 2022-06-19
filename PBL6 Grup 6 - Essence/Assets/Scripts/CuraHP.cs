using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuraHP : MonoBehaviour
{

    public int hp;//defineix quanta hp torna el item
    public int augm;//defineix quanta vida permanent afegeix el item
    public bool perma=false;
    public bool fletxes = false;
    public bool permaFletxes = false;
    public bool orbe1=false;
    public bool orbe2 = false;
    public bool orbe3 = false;
    public bool orbe4 = false;
    public GameObject teleportArbre;
 

    void OnTriggerEnter(Collider other)//defineix si toca el jugador
    {
        if (other.tag == "Player" && this.tag!="orbe")
        {
            if (perma == true)//Tria el tipus de objecte que es
            {
                AumentaHPperm(augm);
            }
            if (perma==false && fletxes == false)
            {
                recuperaVida(hp);
            }if(fletxes == true)
            {
                recuperaFletxes(hp);
            }
            if (permaFletxes == true)
            {
                AumentaFletperm();
            }
            
        }
        if(other.tag == "Player" && this.tag == "orbe")//Controla quan el jugador agafa el orbe
        {
            if (orbe1 == true)//platja
            {
                HUD.orbe1 = 1;
                posicioAlMon.orbe1 = true;
                this.gameObject.SetActive(false);
                teleportArbre.SetActive(true);
            }
            if (orbe2 == true)//gel
            {
                HUD.orbe2 = 1;
                posicioAlMon.orbe2 = true;
                this.gameObject.SetActive(false);
            }
            if (orbe3 == true)//volca
            {
                HUD.orbe3 = 1;
                posicioAlMon.orbe3 = true;
                this.gameObject.SetActive(false);
            }
            if (orbe4 == true)//arbre
            {
                HUD.orbe4 = 1;
                posicioAlMon.orbe4 = true;
                this.gameObject.SetActive(false);
                teleportArbre.SetActive(true);
            }
        }

    }

    void recuperaVida(int hp)//comprova si el jugador te el maxim de hp i si no ho te el cura. En cas de que es curi mes del maxim de hp que te li ajusta a la maxima que pot tenir
    {
       
        if (HUD.vida < HUD.maxVida)
        {
            HUD.vida += hp;
            if (HUD.vida > HUD.maxVida)
            {
                HUD.vida = HUD.maxVida;
            }
            Destroy(this.gameObject);
            Debug.Log(HUD.vida);
        }
        else
        {
            Debug.Log("vida al max");
        }
        
        

        
    }

    void recuperaFletxes(int hp)//comprova si el jugador te el maxim de hp i si no ho te el cura. En cas de que es curi mes del maxim de hp que te li ajusta a la maxima que pot tenir
    {

        if (HUD.numFletxes < HUD.maxFletxes)
        {
            HUD.numFletxes += hp;
            if (HUD.numFletxes > HUD.maxFletxes)
            {
                HUD.numFletxes = HUD.maxFletxes;
            }
            Destroy(this.gameObject);
            Debug.Log(HUD.numFletxes);
        }
        else
        {
            Debug.Log("fletxes al max");
        }




    }

    void AumentaHPperm(int augm)//Augmenta de forma permanent la hp del jugador
    {
        HUD.maxVida += augm;
        HUD.vida = HUD.maxVida;
        Debug.Log("Ara la vida es: "+ HUD.vida);
        nomHP();
        this.gameObject.SetActive(false);
    }

    void AumentaFletperm()
    {
        HUD.maxFletxes += augm;
        HUD.numFletxes = HUD.maxFletxes;
        Debug.Log("Ara el maxim de fletxes es: " + HUD.numFletxes);
        nomHP();
        this.gameObject.SetActive(false);
    }


    void nomHP()//nom del coleccionable
    {
        
        if (this.name == "vida1Bosc")
        {
            posicioAlMon.vida1Bosc = true;
            posicioAlMon.collecionablesBosc--;
        }

        if (this.name == "fletxes1Bosc")
        {
            posicioAlMon.vida1Bosc = true;
            posicioAlMon.collecionablesBosc--;
        }

        if (this.name == "Vidaneu1")
        {
            posicioAlMon.vida1Neu = true;
            posicioAlMon.collecionablesNeu--;
        }

        if (this.name == "VidaNeu2")
        {
            posicioAlMon.vida2Neu = true;
            posicioAlMon.collecionablesNeu--;
        }
        if (this.name == "Vidavolca1")
        {
            posicioAlMon.vida1Volca = true;
            posicioAlMon.collecionablesVolca--;
        }
    }
}
