using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaureForat : MonoBehaviour
{
    public GameObject player;
    public Transform posicioRespawn;
    public bool desAnim;
    public bool tp;
    public bool guardar;
    public bool cargar;
    public Transform posicioCargar;
    public GameObject Porta;
    public GameObject aiguaPuja;
    public GameObject aiguaBaixa;
    public GameObject aiguaPuja2;
    public GameObject aiguaBaixa2;
    public GameObject plataformaDalt;
    public GameObject plataformaBaix;
    public GameObject espasa;
    public GameObject collidersEspasa;
    public GameObject bumerang;
    public GameObject arc;
    public GameObject camaraNormal;
    public GameObject camaraFixe;
    public EnemicControler en;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && guardar == true && this.tag=="puntGuardar")
        {
            //Debug.Log("guardat");
            posicioAlMon.potGuardar = true;
            posicioAlMon.posicioCargar = posicioCargar;
            Debug.Log("Guardat en: "+Application.persistentDataPath);
        }

        if (other.tag == "Player" && cargar == true && this.tag == "puntGuardar")
        {
            Debug.Log("cargat");
            posicioAlMon.potCargar = true;
        }

        if (other.tag == "Player" && desAnim==true)
        {
           
            player.GetComponent<AttackControl>().enabled = false;
            
            //HUD.vida -= 10;
        }

        if (other.tag == "Player" && desAnim == false && guardar == false && cargar == false)
        {
            player.GetComponent<AttackControl>().enabled = true;
            if (this.name == "triggerAconseguixEspasa")
            {
                espasa.SetActive(false);
                AttackControl.getEspasa = true;
                collidersEspasa.SetActive(false);
                camaraNormal.SetActive(true);
                camaraFixe.SetActive(false);
                posicioAlMon.espasaAcons = true;
            }
            if (this.name == "triggerAconseguixFletxes")
            {
                arc.SetActive(false);
                ActivaSpawn.potArc = false;
                AttackControl.getArc = true;
            }

            if (this.name == "triggerAconseguixBoomerang")
            {
                bumerang.SetActive(false);
                AttackControl.getBumerang = true;
            }
        }
        if (other.tag == "enemic" && this.name=="enemicCau")
        {
            other.GetComponent<EnemicControler>().perdreVida(1000);
        }

        if (other.tag == "Player" && tp == true)
        {
            player.SetActive(false);
            player.transform.position = posicioRespawn.position;
            player.SetActive(true);
            HUD.vida -= 10;
        }

        if(other.tag == "Bloc" && tp==true)
        {
            Destroy(other.gameObject);
            Destroy(Porta);
        }

        if (other.name == "Esponja" && this.name== "ActivadorAigua")
        {
            other.gameObject.SetActive(false);
            aiguaPuja.SetActive(true);
            aiguaBaixa.SetActive(false);
            aiguaPuja2.SetActive(true);
            aiguaBaixa2.SetActive(false);
            plataformaBaix.SetActive(false);
            plataformaDalt.SetActive(true);
        }

        //Illa volca

        if (other.tag == "Player" && this.name == "FinalLab1" && timer.inicia == true)
        {
            timer.trigger1 = true;
        }

        if (other.tag == "Player" && this.name == "FinalLab2" && timer.inicia == true)
        {
            timer.trigger2 = true;
        }

        if (other.tag == "Player" && this.name == "FinalLab1" && timer.trigger2 == true)
        {
            timer.acaba = true;
        }

        if (other.tag == "Player" && this.name == "FinalLab2" && timer.trigger1 == true)
        {
            timer.acaba = true;
        }

    }
    
}