using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObrirMapa : MonoBehaviour
{

    public GameObject minimapa;
    public GameObject mapa;
    public GameObject player;
    public GameObject camara;
    bool obre;
    // Start is called before the first frame update
    void Start()
    {
        obre = true;
        minimapa.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.V) && obre == true)
        {
            Debug.Log("a");
            player.GetComponent<CharacterController>().enabled = false;
            player.GetComponent<ControlPersonatge>().enabled = false;
            camara.SetActive(false);
            mapa.SetActive(true);
            minimapa.SetActive(false);
            obre = false;
        }
        if (Input.GetKey(KeyCode.C) && obre == false)
        {
            Debug.Log("b");
            player.GetComponent<CharacterController>().enabled = true;
            player.GetComponent<ControlPersonatge>().enabled = true;
            camara.SetActive(true);
            mapa.SetActive(false);
            minimapa.SetActive(true);
            obre = true;
        }
    }
}
