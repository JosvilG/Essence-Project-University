using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbreCoco : MonoBehaviour
{
    public Transform orbe;
    private Animator abreCoco;
    public Image blackFade;


    public bool actiu = false;
    public GameObject camaraNormal;
    public GameObject camaraCombat;
    public GameObject camaraNormalEscena;
    public GameObject camaraAnimacionOrbe;
    public static bool activa = false;
    public GameObject player;

    private void Start()
    {
        abreCoco = orbe.GetComponent<Animator>();

        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            escenaCamara();
        }
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
        abreCoco.SetTrigger("AbrirCoco");

        yield return new WaitForSeconds(2);
        camaraAnimacionOrbe.SetActive(false);
        camaraNormalEscena.SetActive(true);
        player.GetComponent<CharacterController>().enabled = true;
        StopCoroutine(Escena());
    }
}
