using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class posicioAlMon : ControlEscena // depen del script controlEscena
{
    public GameObject player;
    public static bool entra = false;
    public static bool surt = true;
    public static bool davant = true;
    public static bool potGuardar = false;
    public static bool potCargar = false;
    public static bool escenaCargada = false;
    public Transform onCargar;
    public GameObject camara1;
    public GameObject camara11;
    public static Vector3 proximaPosicio;
    public static bool orbe1;//Determian si s'ha aconseguit el orbe de la illa inicial
    public static bool orbe2;//Determian si s'ha aconseguit el orbe de la illa de gel
    public static bool orbe3;//Determian si s'ha aconseguit el orbe de la illa volca
    public static bool orbe4;//Determian si s'ha aconseguit el orbe de la illa bosc
    public GameObject esfera1;
    public GameObject esfera2;
    public GameObject esfera3;
    public GameObject esfera4;
    public GameObject tpEsfera1;
    public GameObject tpEsfera4;
    public static int vidaMax;//Determina la maxima vida total del personatge
    public static int vidaActual;//Determina la vida que te el personatge a la fase
    public static int fletxesMax;//Determina el numero maxim de fletxes que pot portar el personatge
    public static int fletxesActual;//Determina la quantitat de fletxes que te el personatge a la fase
    public static int collecionablesBosc = 2;//Posar el numero de coleccionables del nivell
    public static int collecionablesNeu = 2;//Posar el numero de coleccionables del nivell
    public static int collecionablesVolca = 1;//Posar el numero de coleccionables del nivell
 
    public static Transform posicioCargar;

    public static bool vida1Bosc = false;
    public GameObject vidaBosc1;
    public static bool fletxes1Bosc = false;
    public GameObject fletxesBosc1;
    public static bool espasaAcons = false;
    public GameObject espasa;
    public static bool vida1Neu = false;
    public GameObject vidaNeu1;
    public static bool vida2Neu = false;
    public GameObject vidaNeu2;
    public static bool vida1Volca = false;
    public GameObject vidaVolca1;
    public GameObject combatVolca;

    private ControlEscena sceneController;
    [SerializeField] private string seguentEscena;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        if (prevScene == "Exterior" && entra==true)
        {
            player.SetActive(false);
            player.transform.position = proximaPosicio;
            player.SetActive(true);
            if (davant == true)
            {
                camara1.SetActive(true);
                camara11.SetActive(false);
            }
            if (davant == false)
            {
                camara1.SetActive(false);
                camara11.SetActive(true);
            }


            entra = false;
        }
        sceneController = GameObject.FindGameObjectWithTag("GameController").GetComponent<ControlEscena>();

        if (prevScene == "interior" && surt == true)
        {
            player.SetActive(false);
            player.transform.position = proximaPosicio;
            player.SetActive(true);
            surt = false;
        }
        /************************************ENTRAR AL MAPAMUNDI*************************************/

        if (prevScene == "PlayaBosque" && surt == true)//Entra al mapamundi des de la illa inicial
        {
            player.SetActive(false);
            player.transform.position = proximaPosicio;
            player.SetActive(true);
        }
        
        if (prevScene == "Neu" && surt == true)//Entra al mapamundi des de la illa nevada
        {
            player.SetActive(false);
            player.transform.position = proximaPosicio;
            player.SetActive(true);
        }

        if (prevScene == "VOLCAN" && surt == true)//Entra al mapamundi des de la illa del volca
        {
            player.SetActive(false);
            player.transform.position = proximaPosicio;
            player.SetActive(true);
        }

        if (prevScene == "IllaBosc" && surt == true)//Entra al mapamundi des de la illa del bosc
        {
            player.SetActive(false);
            player.transform.position = proximaPosicio;
            player.SetActive(true);
        }

        if (prevScene == "MapaJuego" && surt == true)//Entra al mapamundi des de la illa final
        {
            player.SetActive(false);
            player.transform.position = proximaPosicio;
            player.SetActive(true);
        }

        /************************************ENTRAR ILLES*******************************************/

        if (prevScene == "Mapamundi" && surt == false)//Entra a la illa des del mapamundi
        {
            player.SetActive(false);
            player.transform.position = proximaPosicio;
            camara1.SetActive(true);
            camara11.SetActive(false);
            HUD.vida = vidaActual;
            HUD.maxVida = vidaMax;
            HUD.numFletxes = fletxesActual;
            HUD.maxFletxes = fletxesMax;
            player.SetActive(true);
            canviaEscena.potEntrar = false;
        }

        /************************************ENTRAR ZONES ILLA BOSC***********************************/

        if (prevScene == "IllaBosc" && surt == false)//Entra al arbre des de la illa del bosc
        {
            player.SetActive(false);
            player.transform.position = proximaPosicio;
            HUD.vida = vidaActual;
            HUD.maxVida = vidaMax;
            HUD.numFletxes = fletxesActual;
            HUD.maxFletxes = fletxesMax;
            player.SetActive(true);
        }

        if (prevScene == "IllaBosc_InteriorArbre") //Surt del arbre i arriba a la illa del bosc
        {
            player.SetActive(false);
            camara1.SetActive(false);
            camara11.SetActive(true);
            player.transform.position = proximaPosicio;
            HUD.vida = vidaActual;
            HUD.maxVida = vidaMax;
            HUD.numFletxes = fletxesActual;
            HUD.maxFletxes = fletxesMax;
            player.SetActive(true);
        }

        /************************************ENTRAR ZONES ILLA VOLCA***********************************/

        if (prevScene == "VOLCAN" && surt == false)//Entra al volca profund des de la illa del volca
        {
            player.SetActive(false);
            player.transform.position = proximaPosicio;
            HUD.vida = vidaActual;
            HUD.maxVida = vidaMax;
            HUD.numFletxes = fletxesActual;
            HUD.maxFletxes = fletxesMax;
            player.SetActive(true);
        }

        if (prevScene == "IslaVolcan") //Surt del volca profund i entra a la illa del volca
        {
            player.SetActive(false);
            player.transform.position = proximaPosicio;
            HUD.vida = vidaActual;
            HUD.maxVida = vidaMax;
            HUD.numFletxes = fletxesActual;
            HUD.maxFletxes = fletxesMax;
            player.SetActive(true);
        }

        CargaItemsBosc();
        CargaItemsInicial();
        CargaItemsVolca();

        /************************************CARGA JOC*********************************************/
        if (escenaCargada == true)
        {
            posicionarPJ();
        }
        
    }

    public void Update()
    {
        if (potGuardar == true)
        {
            PartidaGuardada();
        }
        if (potCargar == true)
        {
            PartidaCargada();

        }
    }

    public void PartidaGuardada()
    {
        SistemaGuardat.guardarPartida(this);
        potGuardar = false;
        Debug.Log("Orbe 1: " + orbe2);
        
    }

    public void PartidaCargada()
    {
        GuardarPartida dades = SistemaGuardat.cargarPartida();
        Debug.Log("Cargat");
        ControlEscena.currentScene = dades.nomEscena;
        orbe1 = dades.orbe1;
        orbe2 = dades.orbe2;
        orbe3 = dades.orbe3;
        orbe4 = dades.orbe4;

        vidaMax = dades.VidaMax;
        vidaActual = dades.VidaActual;
        fletxesMax = dades.fletxesMax;
        fletxesActual = dades.fletxesActual;

        vida1Bosc = dades.vida1Bosc;
        fletxes1Bosc = dades.fletxes1Bosc;
        espasaAcons = dades.espasaAcons;
        vida1Neu = dades.vida1Neu;
        vida2Neu = dades.vida2Neu;
        vida1Volca = dades.vida1Volca;

        AttackControl.getEspasa = dades.getEspasa;
        AttackControl.getBumerang = dades.getBumerang;
        AttackControl.getArc = dades.getArc;
        
        Vector3 position;
        position.x = dades.position[0];
        position.y = dades.position[1];
        position.z = dades.position[2];
        
        sceneController.LoadScene(ControlEscena.currentScene);
        proximaPosicio = position;
        
        potCargar = false;
        escenaCargada = true;
    }

    public void posicionarPJ()
    {
        player.SetActive(false);
        player.transform.position = proximaPosicio;
        HUD.vida = vidaActual;
        HUD.maxVida = vidaMax;
        HUD.numFletxes = fletxesActual;
        HUD.maxFletxes = fletxesMax;
        player.SetActive(true);
        escenaCargada = false;
        Debug.Log("Espasa: " + espasaAcons + " | Escena: " + ControlEscena.currentScene);
    }

    public void CargaItemsInicial()//ILLA INICIAL
    {
        if (espasaAcons == true && ControlEscena.currentScene == "PlayaBosque")//Colleccionables illa bosc
        {
            espasa.SetActive(false);

        }
        if (orbe1 == true && ControlEscena.currentScene == "PlayaBosque")//Orbe illa inicial i activa el mapamundi
        {
            esfera1.SetActive(false);
            tpEsfera1.SetActive(true);
        }
    }

    public void CargaItemsNeu()//ILLA NEU
    {
        if (vida1Neu == true && ControlEscena.currentScene == "Neu")//Colleccionables illa bosc
        {
            vidaNeu1.SetActive(false);

        }

        if (vida2Neu == true && ControlEscena.currentScene == "Neu")//Colleccionables illa bosc
        {
            vidaNeu2.SetActive(false);

        }

        if (orbe2 == true && ControlEscena.currentScene == "Neu")//Orbe interior arbre
        {
            esfera2.SetActive(false);
        }
    }

    public void CargaItemsVolca()//ILLA VOLCA
    {
        if(ControlEscena.currentScene== "VOLCAN")
        {
            combatVolca.SetActive(true);
        }
        
        if (vida1Volca == true && ControlEscena.currentScene == "VOLCAN")//Colleccionables illa bosc
        {
            vidaVolca1.SetActive(false);

        }
        
        if (orbe3 == true && ControlEscena.currentScene == "VOLCAN")//Orbe interior arbre
        {
            esfera3.SetActive(false);
        }
    }

    public void CargaItemsBosc()//ILLA BOSC
    {
        if (vida1Bosc == true && ControlEscena.currentScene== "IllaBosc")//Colleccionables illa bosc
        {
            vidaBosc1.SetActive(false);
            
        }
        if(fletxes1Bosc == true && ControlEscena.currentScene == "IllaBosc_InteriorArbre")//Colleccionables interior arbre
        {
            fletxesBosc1.SetActive(false);
        }
        if(orbe4 == true && ControlEscena.currentScene == "IllaBosc_InteriorArbre")//Orbe interior arbre
        {
            esfera4.SetActive(false);
            tpEsfera4.SetActive(true);
        }
    }



}
