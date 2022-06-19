using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resFinals : MonoBehaviour
{
    Text NumEnemics;
    Text NumGel;
    Text NumVolca;
    Text NumBosc;

    // Start is called before the first frame update
    void Start()
    {
        if (this.name == "eneText")
        {
            NumEnemics = GetComponent<Text>();
        }
        if (this.name == "gelText")
        {
            NumGel = GetComponent<Text>();
        }
        if (this.name == "volcaText")
        {
            NumVolca = GetComponent<Text>();
        }
        if (this.name == "boscText")
        {
            NumBosc = GetComponent<Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.name == "eneText")
        {
            NumEnemics.text = ""+EnemicControler.MortsTotals;
        }
        if (this.name == "gelText" && posicioAlMon.collecionablesNeu==0)
        {
            NumGel.text = "0";
        }
        else if (this.name == "gelText" && posicioAlMon.collecionablesNeu != 0)
        {
            NumGel.text = ""+posicioAlMon.collecionablesNeu;
        }
        if (this.name == "volcaText" && posicioAlMon.collecionablesVolca == 0)
        {
            NumVolca.text = "0";
        }else if (this.name == "volcaText" && posicioAlMon.collecionablesVolca != 0)
        {
            NumVolca.text = ""+posicioAlMon.collecionablesVolca;
        }
        if (this.name == "boscText" && posicioAlMon.collecionablesBosc==0)
        {
            NumBosc.text = "0";
        }
        else if (this.name == "boscText" && posicioAlMon.collecionablesBosc != 0)
        {
            NumBosc.text = ""+posicioAlMon.collecionablesBosc;
        }
    }
}
