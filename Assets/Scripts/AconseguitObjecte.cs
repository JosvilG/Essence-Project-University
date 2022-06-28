using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AconseguitObjecte : MonoBehaviour
{
    public Transform panel;

    public GameObject camaraNormal;
    public GameObject camaraEscena;
    public GameObject player;
    public bool trigger = false;
    bool fet = false;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && fet == false)
        {
            if (!trigger)
            {
                panel.gameObject.SetActive(true);
                StartCoroutine(Bloquejar());
                trigger = true;
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
        camaraEscena.SetActive(true);
        yield return null;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Acceptar");
            panel.gameObject.SetActive(false);
            StartCoroutine(Desbloquejar());
        }

    }

    private IEnumerator Desbloquejar()
    {
        player.GetComponent<CharacterController>().enabled = true;
        //player.GetComponent<PlayerControl>().enabled = true;

        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        camaraNormal.SetActive(true);
        camaraEscena.SetActive(false);
        fet = true;
        yield return null;
    }
}
