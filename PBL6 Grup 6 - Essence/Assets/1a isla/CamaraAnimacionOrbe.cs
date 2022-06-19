using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraAnimacionOrbe : MonoBehaviour
{
    public bool actiu = false;
    public GameObject spawn;
    public GameObject porta;
    public GameObject porta2;
    public static bool obrir = false;
    public GameObject camaraNormal;
    public GameObject camaraCombat;
    public GameObject camaraNormalEscena;
    public GameObject camaraAnimacionOrbe;
    public GameObject arc;
    public int morts;
    public static bool potArc = false;
    public bool potEscena;
    public static bool activa = false;
    public GameObject player;
    private int num = 0;

    private void Start()
    {
        escenaCamara();
    }
    
    void escenaCamara()
    {
        activa = true;
        StartCoroutine(Escena());
    }
    private IEnumerator Escena()
    {
        player.GetComponent<CharacterController>().enabled = false;
        camaraNormal.SetActive(false);
        camaraAnimacionOrbe.SetActive(true);
        camaraNormalEscena.SetActive(false);
        yield return new WaitForSeconds(3.0f);
        camaraAnimacionOrbe.SetActive(false);
        camaraNormalEscena.SetActive(true);
        player.GetComponent<CharacterController>().enabled = true;
        potEscena = false;
        activa = false;
        StopCoroutine(Escena());
    }

}
