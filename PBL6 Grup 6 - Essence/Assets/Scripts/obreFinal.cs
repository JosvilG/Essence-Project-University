using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obreFinal : MonoBehaviour
{
    public GameObject illaFInal;
    public GameObject jo;

    // Update is called once per frame
    void Update()
    {
        if (posicioAlMon.orbe1 == true && posicioAlMon.orbe2==true && posicioAlMon.orbe3==true && posicioAlMon.orbe4==true)
        {
            jo.SetActive(false);
            illaFInal.SetActive(true);
        }
        else
        {
            jo.SetActive(true);
            illaFInal.SetActive(false);
        }
    }
}
