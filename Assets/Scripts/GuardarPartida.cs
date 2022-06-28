using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GuardarPartida//Aqui es defineix que es guarda en el arxiu de guardar partida
{
    //Quins orbes estan aconseguits

    public bool orbe1;
    public bool orbe2;
    public bool orbe3;
    public bool orbe4;

    //Maxim i actual dels seguents

    public int VidaMax;
    public int VidaActual;
    public int fletxesMax;
    public int fletxesActual;


    //Millores Hp i fletxes
    public bool vida1Bosc;
    public bool fletxes1Bosc;
    public bool espasaAcons;
    public bool vida1Neu;
    public bool vida2Neu;
    public bool vida1Volca;

    //Armes aconseguides

    public bool getEspasa;
    public bool getBumerang;
    public bool getArc;

    //Posicio i escena

    public float[] position;
    public string nomEscena;

    public GuardarPartida(posicioAlMon dades)
    {
        orbe1 = posicioAlMon.orbe1;
        orbe2 = posicioAlMon.orbe2;
        orbe3 = posicioAlMon.orbe3;
        orbe4 = posicioAlMon.orbe4;

        VidaMax = posicioAlMon.vidaMax;
        VidaActual = posicioAlMon.vidaActual;
        fletxesMax = posicioAlMon.fletxesMax;
        fletxesActual = posicioAlMon.fletxesActual;

        vida1Bosc = posicioAlMon.vida1Bosc;
        fletxes1Bosc = posicioAlMon.fletxes1Bosc;
        espasaAcons = posicioAlMon.espasaAcons;
        vida1Neu = posicioAlMon.vida1Neu;
        vida2Neu = posicioAlMon.vida2Neu;
        vida1Volca = posicioAlMon.vida1Volca;

        getEspasa = AttackControl.getEspasa;
        getBumerang = AttackControl.getBumerang;
        getArc = AttackControl.getArc;

        nomEscena = ControlEscena.currentScene;
        position = new float[3];
        position[0] = posicioAlMon.posicioCargar.transform.position.x;
        position[1] = posicioAlMon.posicioCargar.transform.position.y;
        position[2] = posicioAlMon.posicioCargar.transform.position.z;
    }

}
