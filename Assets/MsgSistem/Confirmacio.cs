using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confirmacio : MonoBehaviour
{
    public Transform panel;
    //public Transform objetoTrigger;

    public GameObject camaraNormal;
    public GameObject camaraNormalEscena;
    public GameObject camaraEscena;
    public GameObject player;
    public GameObject elementsMinimapa;
    public static bool illaInicial;
    public static bool illaNeu;
    public static bool illaVolca;
    public static bool illaBosc;
    public static bool illaFinal;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Acceptar");
            panel.gameObject.SetActive(false);
            
            canviaEscena.potEntrar = true;
            Debug.Log("Entrat");
            StartCoroutine(Desbloquejar());
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Cancelar");
            panel.gameObject.SetActive(false);
            StartCoroutine(Desbloquejar());
            illaBosc = false;
            illaFinal = false;
            illaInicial = false;
            illaNeu = false;
            illaVolca = false;
        }

    }

    private IEnumerator Desbloquejar()
    {
        player.GetComponent<CharacterController>().enabled = true;
        //player.GetComponent<PlayerControl>().enabled = true;

        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        elementsMinimapa.SetActive(true);
        camaraNormal.SetActive(true);
        camaraNormalEscena.SetActive(true);
        camaraEscena.SetActive(false);
        
        yield return null;
    }
}
