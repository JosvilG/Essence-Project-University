using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    //Asignas el codigo al bloque que activara el laberinto
    public float timeLeft = 5.0f;
    public Text countdown;
    private bool win ;
    public GameObject originalPos;
    public GameObject player;
    public static bool inicia;//Comprueba que el laberinto ha iniciado
    public GameObject pared1;//Estas 2 son las paredes finales al inicio en el editor que esten activadas por defecto
    public GameObject pared2;
    public GameObject paredInicio;//Esta es la que aparece al entrar al laberinto y te cierra. Por defecto ponla desactivada
    public static bool trigger1;//Estos determinan por que lado tienes que activar la puerta final
    public static bool trigger2;
    public static bool acaba;
    public GameObject camaraNormal;
    public GameObject camaraCenital;
    public GameObject camaraFinal1;
    public GameObject camaraFinal2;
    bool acabaTot = false;

    void Start()
    {
        if(this.name== "InicioLab")
        {
            win = false;
            inicia = false;
            trigger1 = false;
            trigger2 = false;
            acaba = false;
        }
    }
    void Update()
    {
        if (!win && inicia == true && this.name== "InicioLab")//Al ser true inicia permite que empiece el contador
        {

            timeLeft -= Time.deltaTime;
            //countdown.text = "Time Left:" + Mathf.Round(timeLeft);
            Debug.Log("Time Left:" + Mathf.Round(timeLeft));
            if (timeLeft < 0)
            {
                GameOver();
            }
        }
        if (trigger1 == true || trigger2 == true)
        {
            inicia = false;
        }
        if (acaba == true)
        {
            pared1.SetActive(false);
            pared2.SetActive(false);
            paredInicio.SetActive(false);
            if (trigger1 == true && acabaTot == false)
            {
                camaraFinal1.SetActive(true);
                camaraNormal.SetActive(false);
            }else if (trigger2 == true && acabaTot == false)
            {
                camaraFinal2.SetActive(true);
                camaraNormal.SetActive(false);
            }
            StartCoroutine(MuestraFInal());
        }
    }

    void GameOver()
    {
        timeLeft = 30.0f;
        player.SetActive(false);
        player.transform.position = originalPos.transform.position;
        player.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        //
        //Este se activa al iniciar el laberinto
        //
        if (other.tag == "Player" && this.name == "InicioLab" && inicia==false && trigger1==false && trigger2==false)//Inicia el laberinto
        {
            inicia = true;
            paredInicio.SetActive(true);//Activa la pared de inicio y cierra al jugador en el laberinto
        }

        //
        //Estos 2 son al acabar el laberinto
        //

        if (other.tag == "Player" && this.name == "FinalLab1" && inicia == true)//Acaba el laberinto por la puerta 1
        {
            Debug.Log("aaaa");
            //para el contador de tiempo pero solo desactiva la puerta del inicio
            paredInicio.SetActive(false);
            trigger1 = true;
            inicia = false;
        }
        if (other.tag == "Player" && this.name == "FinalLab2" && inicia == true)//Acaba el laberinto por la puerta 2
        {
            //para el contador de tiempo pero solo desactiva la puerta del inicio
            paredInicio.SetActive(false);
            trigger2 = true;
        }

        //
        //Estos sirven para acceder al orbe
        //

        if (other.tag == "Player" && this.name == "FinalLab1" && trigger2 == true)//Accede al orbe por la puerta 1
        {
            //desactiva pared1 y pared2
        }
        if (other.tag == "Player" && this.name == "FinalLab2" && trigger1 == true)//Accede al orbe por la puerta 2
        {
            //desactiva pared1 y pared2
        }

    }

    IEnumerator MuestraFInal()
    {
        
        yield return new WaitForSeconds(4);

        camaraFinal1.SetActive(false);
        camaraFinal2.SetActive(false);
        camaraNormal.SetActive(true);
        acabaTot = true;
    }
}
