using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class canviaEscena : MonoBehaviour
{
    [SerializeField] private string seguentEscena;
    private ControlEscena sceneController;
    public GameObject player;
    public GameObject pos;
    public GameObject pos1;
    public GameObject pos2;
    public static bool potEntrar = false;
    public Image blackFade;

    void Start()
    {
        sceneController = GameObject.FindGameObjectWithTag("GameController").GetComponent<ControlEscena>();
    }
    private void OnTriggerEnter(Collider collision)
    {

        /********************************ILLA INICIAL******************************************************************/

        /*if (collision.CompareTag("Player") && this.name == "EntraIllaInicial" && potEntrar == true) // Entra a la illa inicial des del mapamundi - Requereix camara activa
        {
            sceneController.LoadScene(seguentEscena);
            posicioAlMon.proximaPosicio = pos.transform.position;
            posicioAlMon.entra = false;
            posicioAlMon.davant = false;
            posicioAlMon.surt = false;
        }*/

        if (collision.CompareTag("Player") && this.name == "SurtMapamundiInici") // Surt al mapamundi des de la illa inicial
        {
            sceneController.LoadScene(seguentEscena);
            posicioAlMon.proximaPosicio = pos.transform.position; /*99.1, 1.047486, -38*/
            posicioAlMon.entra = false;
            posicioAlMon.davant = false;
            posicioAlMon.surt = true;
        }

        /********************************ILLA NEU******************************************************************/

        /*if (collision.CompareTag("Player") && this.name == "EntraIllaNeu" && potEntrar == true) // Entra a la illa de neu des del mapamundi - Requereix camara activa
        {
            Debug.Log("aaaaaa");
            sceneController.LoadScene(seguentEscena);
            posicioAlMon.proximaPosicio = pos.transform.position;
            posicioAlMon.entra = false;
            posicioAlMon.davant = false;
            posicioAlMon.surt = false;
            
        }*/

        if (collision.CompareTag("Player") && this.name == "SurtMapamundiNeu") // Surt al mapamundi des de la illa de neu
        {
            sceneController.LoadScene(seguentEscena);
            posicioAlMon.proximaPosicio = pos.transform.position; /*108.333, 1.047486, 59.4*/
            posicioAlMon.entra = false;
            posicioAlMon.davant = false;
            posicioAlMon.surt = true;
        }

        if (collision.CompareTag("Player") && this.name == "EntraCavernaGel") // Entra a la caverna de gel
        {
            sceneController.LoadScene(seguentEscena);
            posicioAlMon.proximaPosicio = pos.transform.position; /*-174.97, 1.4, 147.24*/
            posicioAlMon.entra = false;
            posicioAlMon.davant = false;
            posicioAlMon.surt = true;
        }

        if (collision.CompareTag("Player") && this.name == "SurtCavernaGel") // Surt de la caverna de gel
        {
            sceneController.LoadScene(seguentEscena);
            posicioAlMon.proximaPosicio = pos.transform.position; /*149.21, 1.39, 241.23*/
            posicioAlMon.entra = false;
            posicioAlMon.davant = false;
            posicioAlMon.surt = true;
        }

        /********************************ILLA VOLCA******************************************************************/

        /*if (collision.CompareTag("Player") && this.name == "EntraIllaVolca" && potEntrar == true) // Entra a la illa del volca des del mapamundi - Requereix camara activa
        {
            sceneController.LoadScene(seguentEscena);
            posicioAlMon.proximaPosicio = pos.transform.position;
            posicioAlMon.entra = false;
            posicioAlMon.davant = false;
            posicioAlMon.surt = false;
        }*/

        if (collision.CompareTag("Player") && this.name == "SurtMapamundiVolca") // Surt al mapamundi des de la illa del volca
        {
            sceneController.LoadScene(seguentEscena);
            posicioAlMon.proximaPosicio = pos.transform.position; /*-37.7, 1.047486, -69.7*/
            posicioAlMon.entra = false;
            posicioAlMon.davant = false;
            posicioAlMon.surt = true;
        }

        if (collision.CompareTag("Player") && this.name == "EntraVolcaProfund") // Entra a la zona profunda del volca des de la illa del volca
        {
            sceneController.LoadScene(seguentEscena);
            posicioAlMon.proximaPosicio = pos.transform.position; /*1106.652, 4.99, 328.7501*/
            posicioAlMon.entra = false;
            posicioAlMon.davant = false;
            posicioAlMon.surt = false;
            Debug.Log("Player: " + player.transform.position + " Pos: " + pos.transform.position);
        }

        if (collision.CompareTag("Player") && this.name == "EntraVolcaDarrera") // Entra a la illa del volca des de la zona profunda del volca
        {
            sceneController.LoadScene(seguentEscena);
            posicioAlMon.proximaPosicio = pos.transform.position; /*205.16, 73.33, 430.56*/
            posicioAlMon.entra = false;
            posicioAlMon.davant = false;
            posicioAlMon.surt = true;
            Debug.Log("Player: " + player.transform.position + " Pos: " + pos.transform.position);
        }

        /*********************************ILLA DEL BOSC****************************************************************/

        /*if (collision.CompareTag("Player") && this.name == "EntraIllaBosc" && potEntrar == true) // Entra a la illa del bosc des del mapamundi - Requereix camara activa
        {
            sceneController.LoadScene(seguentEscena);
            posicioAlMon.proximaPosicio = pos.transform.position;
            posicioAlMon.entra = false;
            posicioAlMon.davant = false;
            posicioAlMon.surt = false;
        }*/

        if (collision.CompareTag("Player") && this.name == "SurtMapamundi") // Surt al mapamundi des de la illa del bosc
        {
            sceneController.LoadScene(seguentEscena);
            posicioAlMon.proximaPosicio = pos.transform.position; /*-89.8, 1.047486, 34.7*/
            posicioAlMon.entra = false;
            posicioAlMon.davant = false;
            posicioAlMon.surt = true;
        }

        if (collision.CompareTag("Player") && this.name == "portaEntraArbre") // Entra al arbre des de la illa del bosc
        {
            sceneController.LoadScene(seguentEscena);
            posicioAlMon.proximaPosicio = pos.transform.position;/*838.46 , 1345.453 , -437.35*/
            posicioAlMon.entra = false;
            posicioAlMon.davant = false;
            posicioAlMon.surt = false;
        }

        if (collision.CompareTag("Player") && this.name == "portaSurtArbre") // Surt del arbre i entra a la illa del bosc - Requereix activar camara
        {
            sceneController.LoadScene(seguentEscena);
            posicioAlMon.proximaPosicio = pos.transform.position; /*285.33, 349, 259.24*/
            posicioAlMon.entra = false;
            posicioAlMon.davant = false;
            posicioAlMon.surt = false;
        }

        /********************************ILLA FINAL******************************************************************/

        /*if (collision.CompareTag("Player") && this.name == "EntraIllaFinal" && potEntrar == true) // Entra a la illa final des del mapamundi - Requereix camara activa
        {
            sceneController.LoadScene(seguentEscena);
            posicioAlMon.proximaPosicio = pos.transform.position;
            posicioAlMon.entra = false;
            posicioAlMon.davant = false;
            posicioAlMon.surt = false;
        }*/

        if (collision.CompareTag("Player") && this.name == "SurtMapamundiFinal") // Surt al mapamundi des de la illa final
        {
            sceneController.LoadScene(seguentEscena);
            posicioAlMon.proximaPosicio = pos.transform.position; /*0.2, 1.047486, -66*/
            posicioAlMon.entra = false;
            posicioAlMon.davant = false;
            posicioAlMon.surt = true;
        }

        if (collision.CompareTag("Player") && this.name == "triggerCredits") // Surt al mapamundi des de la illa final
        {
            sceneController.LoadScene(seguentEscena);
            posicioAlMon.proximaPosicio = pos.transform.position; /*-3.2, 2.63, -43.3*/
            posicioAlMon.entra = false;
            posicioAlMon.davant = false;
            posicioAlMon.surt = true;
        }


        /*
            public static bool orbe1;//Determian si s'ha aconseguit el orbe de la illa inicial
            public static bool orbe2;//Determian si s'ha aconseguit el orbe de la illa de gel
            public static bool orbe3;//Determian si s'ha aconseguit el orbe de la illa volca
            public static int vidaMax;//Determina la maxima vida total del personatge
            public static int vidaActual;//Determina la vida que te el personatge a la fase
            public static int fletxesMax;//Determina el numero maxim de fletxes que pot portar el personatge
            public static int fletxesActual;//Determina la quantitat de fletxes que te el personatge a la fase
         */
    }

    void Update()
    {
        if (potEntrar == true)
        {
            EntraDesMapamundi();
        }
    }

    public void EntraDesMapamundi()
    {
        Debug.Log("Confirmacio: " + Confirmacio.illaInicial + " altre: "+ Confirmacio.illaNeu);
        if (this.name == "EntraIllaInicial" && potEntrar == true && Confirmacio.illaInicial == true) // Entra a la illa inicial des del mapamundi - Requereix camara activa
        {
            sceneController.LoadScene(seguentEscena);
            posicioAlMon.proximaPosicio = pos.transform.position; /*206.7, 1.38, 544.4*/
            posicioAlMon.entra = false;
            posicioAlMon.davant = false;
            posicioAlMon.surt = false;
        }

        if (this.name == "EntraIllaNeu" && potEntrar == true && Confirmacio.illaNeu == true) // Entra a la illa de neu des del mapamundi - Requereix camara activa
        {
            Debug.Log("aaaaaa");
            sceneController.LoadScene(seguentEscena);
            posicioAlMon.proximaPosicio = pos.transform.position; /*-114.65, 43.2, 350.12*/
            posicioAlMon.entra = false;
            posicioAlMon.davant = false;
            posicioAlMon.surt = false;

        }

        if (this.name == "EntraIllaVolca" && potEntrar == true && Confirmacio.illaVolca == true) // Entra a la illa del volca des del mapamundi - Requereix camara activa
        {
            sceneController.LoadScene(seguentEscena);
            posicioAlMon.proximaPosicio = pos.transform.position; /*833.5194, 4.72, 479.2413*/
            posicioAlMon.entra = false;
            posicioAlMon.davant = false;
            posicioAlMon.surt = false;
        }

        if (this.name == "EntraIllaBosc" && potEntrar == true && Confirmacio.illaBosc == true) // Entra a la illa del bosc des del mapamundi - Requereix camara activa
        {
            sceneController.LoadScene(seguentEscena);
            posicioAlMon.proximaPosicio = pos.transform.position; /*251.84, 333.376, -150.47*/
            posicioAlMon.entra = false;
            posicioAlMon.davant = false;
            posicioAlMon.surt = false;
        }

        if (this.name == "EntraIllaFinal" && potEntrar == true && Confirmacio.illaFinal == true) // Entra a la illa final des del mapamundi - Requereix camara activa
        {
            sceneController.LoadScene(seguentEscena);
            posicioAlMon.proximaPosicio = pos.transform.position; /*473.6419, 161.56, 746.8198*/
            posicioAlMon.entra = false;
            posicioAlMon.davant = false;
            posicioAlMon.surt = false;
        }
    }

   
}
