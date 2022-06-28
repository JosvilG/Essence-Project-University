using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlesArbre : MonoBehaviour
{

    public GameObject rampa;
    public GameObject meshArbre;
    public GameObject revestimentArbre;
    public GameObject extra;


    void OnTriggerEnter(Collider other)
    {
        if (this.name == "triggerCamaraEntra" && other.tag == "Player")//camara1 = proxima camara
        {
            rampa.SetActive(true);
            meshArbre.SetActive(true);
            revestimentArbre.SetActive(true);
            extra.SetActive(false);

        }
        if (this.name == "triggerCamaraSurt" && other.tag == "Player")//camara2 = proxima camara
        {
            rampa.SetActive(false);
            meshArbre.SetActive(false);
            revestimentArbre.SetActive(false);
        }
    }
}
