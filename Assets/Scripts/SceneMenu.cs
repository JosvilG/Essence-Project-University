using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMenu : MonoBehaviour
{

    [SerializeField] private string seguentEscena;
    private ControlEscena sceneController;
    // Start is called before the first frame update
    void Start()
    {
        sceneController = GameObject.FindGameObjectWithTag("GameController").GetComponent<ControlEscena>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Escena1()//Inici del joc
    {
        sceneController.LoadScene("PlayaBosque");
        //posicioAlMon.proximaPosicio = posEscena1.transform.position;
        posicioAlMon.entra = false;
        posicioAlMon.davant = false;
        posicioAlMon.surt = false;
        AttackControl.getEspasa = false;
        AttackControl.getBumerang = false;
        AttackControl.getArc = false;
        posicioAlMon.orbe1 = false;
        posicioAlMon.orbe2 = false;
        posicioAlMon.orbe3 = false;
        posicioAlMon.orbe4 = false;
    }

    public void Escena2()//Illa inici --> illa de gel
    {
        sceneController.LoadScene("Neu");
        //posicioAlMon.proximaPosicio = posEscena1.transform.position;
        posicioAlMon.entra = false;
        posicioAlMon.davant = false;
        posicioAlMon.surt = false;
        AttackControl.getEspasa = true;
        AttackControl.getBumerang = false;
        AttackControl.getArc = false;
        posicioAlMon.orbe1 = true;
        posicioAlMon.orbe2 = false;
        posicioAlMon.orbe3 = false;
        posicioAlMon.orbe4 = false;
    }

    public void Escena3()//Illa inici --> illa del gel --> illa del volca
    {
        sceneController.LoadScene("VOLCAN");
        //posicioAlMon.proximaPosicio = posEscena1.transform.position;
        posicioAlMon.entra = false;
        posicioAlMon.davant = false;
        posicioAlMon.surt = false;
        AttackControl.getEspasa = true;
        AttackControl.getBumerang = true;
        AttackControl.getArc = false;
        posicioAlMon.orbe1 = true;
        posicioAlMon.orbe2 = true;
        posicioAlMon.orbe3 = false;
        posicioAlMon.orbe4 = false;
    }

    public void Escena4()//Illa inici --> illa del gel --> illa del volca --> illa del bosc
    {
        sceneController.LoadScene("IllaBosc");
        //posicioAlMon.proximaPosicio = posEscena1.transform.position;
        posicioAlMon.entra = false;
        posicioAlMon.davant = false;
        posicioAlMon.surt = false;
        AttackControl.getEspasa = true;
        AttackControl.getBumerang = true;
        AttackControl.getArc = true;
        posicioAlMon.orbe1 = true;
        posicioAlMon.orbe2 = true;
        posicioAlMon.orbe3 = true;
        posicioAlMon.orbe4 = false;
    }

    public void Escena5()//Illa inici --> illa del gel --> illa del volca --> illa del bosc --> illa final
    {
        sceneController.LoadScene("MapaJuego");
        //posicioAlMon.proximaPosicio = posEscena1.transform.position;
        posicioAlMon.entra = false;
        posicioAlMon.davant = false;
        posicioAlMon.surt = false;
        AttackControl.getEspasa = true;
        AttackControl.getBumerang = true;
        AttackControl.getArc = true;
        posicioAlMon.orbe1 = true;
        posicioAlMon.orbe2 = true;
        posicioAlMon.orbe3 = true;
        posicioAlMon.orbe4 = true;
    }
}
