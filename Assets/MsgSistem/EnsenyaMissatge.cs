using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnsenyaMissatge : MonoBehaviour
{
    public Transform panel;

    public GameObject camaraNormal;
    public GameObject camaraNormalEscena;
    public GameObject camaraEscena;
    public GameObject player;
    public GameObject elementsMinimapa;
    public bool trigger = false;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (!trigger)
            {
                panel.gameObject.SetActive(true);
                StartCoroutine(Bloquejar());
                trigger = true;
                if (this.name == "EntraIllaBosc")
                {
                    Confirmacio.illaBosc = true;
                    Confirmacio.illaFinal = false;
                    Confirmacio.illaInicial = false;
                    Confirmacio.illaNeu = false;
                    Confirmacio.illaVolca = false;
                }
                else if (this.name == "EntraIllaNeu")
                {
                    Confirmacio.illaBosc = false;
                    Confirmacio.illaFinal = false;
                    Confirmacio.illaInicial = false;
                    Confirmacio.illaNeu = true;
                    Confirmacio.illaVolca = false;
                }
                else if (this.name == "EntraIllaInicial")
                {
                    Confirmacio.illaBosc = false;
                    Confirmacio.illaFinal = false;
                    Confirmacio.illaInicial = true;
                    Confirmacio.illaNeu = false;
                    Confirmacio.illaVolca = false;
                }
                else if (this.name == "EntraIllaVolca")
                {
                    Confirmacio.illaBosc = false;
                    Confirmacio.illaFinal = false;
                    Confirmacio.illaInicial = false;
                    Confirmacio.illaNeu = false;
                    Confirmacio.illaVolca = true;
                }
                else if (this.name == "EntraIllaFinal")
                {
                    Confirmacio.illaBosc = false;
                    Confirmacio.illaFinal = true;
                    Confirmacio.illaInicial = false;
                    Confirmacio.illaNeu = false;
                    Confirmacio.illaVolca = false;
                }
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
       trigger = false;
    }

    private IEnumerator Bloquejar()
    {
        player.GetComponent<CharacterController>().enabled = false;
        //player.GetComponent<PlayerControl>().enabled = false;

        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        camaraNormal.SetActive(false);
        camaraNormalEscena.SetActive(false);
        camaraEscena.SetActive(true);
        elementsMinimapa.SetActive(false);
        yield return null;
    }
}
