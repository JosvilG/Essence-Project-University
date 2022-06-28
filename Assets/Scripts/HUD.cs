using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    Text VidaText;
    Text ClausText;
    Text FletxesText;
    Text orbeNum1;
    Text orbeNum2;
    Text orbeNum3;
    Text orbeNum4;

    public Image orbearbre;
    public Image orbearbredesactivat;
    public Image orbefoc;
    public Image orbefocdesactivat;
    public Image orbeplatja;
    public Image orbeplatjadesactivat;
    public Image orbegel;
    public Image orbegeldesactivat;
    public Image Espasa;
    public Image EspasaDes;
    public Image Arc;
    public Image ArcDes;
    public Image Bum;
    public Image BumDes;
    public Image fletxa;

    public static int vida=100;
    public static int maxVida = 100;
    public static int numClaus = 0;
    public static int numFletxes = 40;
    public static int maxFletxes = 40;
    public static int orbe1 = 0;
    public static int orbe2 = 0;
    public static int orbe3 = 0;
    public static int orbe4 = 0;
    public static bool estatEspasa;
    public static bool estatBum;
    public static bool estatArc;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        if(this.name== "VidaText")
        {
            VidaText = GetComponent<Text>();
            healthBar.SetMaxHealth(maxVida);
        }
        if (this.name == "ClausText")
        {
            ClausText = GetComponent<Text>();
        }
        if (this.name == "NumeroFletxes")
        {
            FletxesText = GetComponent<Text>();
        }
        if (this.name == "platjaOrbe1")
        {
            //orbeNum1 = GetComponent<Text>();
            orbeplatja.enabled = false;
            orbeplatjadesactivat.enabled = true;
        }
        if (this.name == "gelOrbe2")
        {
            //orbeNum2 = GetComponent<Text>();
            orbegel.enabled = false;
            orbegeldesactivat.enabled = true;
        }
        if (this.name == "focOrbe3")
        {
            //orbeNum3 = GetComponent<Text>();
            orbefocdesactivat.enabled = true;
            orbefoc.enabled = false;
        }
        if (this.name == "boscOrbe4")
        {
            //orbeNum4 = GetComponent<Text>();
            orbearbredesactivat.enabled = true;
            orbearbre.enabled = false;
        }
        if (this.name == "ControlEspasa")
        {
            Espasa.enabled = false;
            EspasaDes.enabled = true;
        }
        if (this.name == "ControlBum")
        {
            Bum.enabled = false;
            BumDes.enabled = true;
        }
        if (this.name == "ControlArc")
        {
            Arc.enabled = false;
            ArcDes.enabled = true;
        }
        if (this.name == "ControlFletxa")
        {
            fletxa.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (AttackControl.getEspasa == true && this.name == "ControlEspasa")
        {
            if (estatEspasa == true)
            {
                Espasa.enabled = true;
                EspasaDes.enabled = false;
            }
            else if(estatEspasa == false)
            {
                Espasa.enabled = true;
                EspasaDes.enabled = true;
            }
            
        }
        if (AttackControl.getEspasa == false && this.name == "ControlEspasa")
        {
                Espasa.enabled = false;
                EspasaDes.enabled = false;
            

        }


        if (AttackControl.getEspasa == true && this.name == "ControlEspasaInventari")
        {
                Espasa.enabled = true;
                EspasaDes.enabled = false;

        }
        if (AttackControl.getEspasa == false && this.name == "ControlEspasaInventari")
        {
            Espasa.enabled = false;
            EspasaDes.enabled = true;

        }

        if (AttackControl.getArc == true && this.name == "ControlArcInventari")
        {
            Arc.enabled = true;
            ArcDes.enabled = false;

        }
        if (AttackControl.getArc == false && this.name == "ControlArcInventari")
        {
            Arc.enabled = false;
            ArcDes.enabled = true;

        }

        if (AttackControl.getBumerang == true && this.name == "ControlBumInventari")
        {
            Bum.enabled = true;
            BumDes.enabled = false;

        }
        if (AttackControl.getBumerang == false && this.name == "ControlBumInventari")
        {
            Bum.enabled = false;
            BumDes.enabled = true;

        }

        if (AttackControl.getArc == false)
        {
            if (this.name == "NumeroFletxes")
            {
                FletxesText.GetComponent<Text>().enabled = false;
            }
            if (this.name == "ControlFetxa")
            {
                fletxa.enabled = false;
                
            }
            if (this.name == "ControlArc")
            {
                Arc.enabled = false;
                ArcDes.enabled = false;
            }
        }
        if (AttackControl.getArc == true && this.name == "ControlFletxa")
        {
            fletxa.enabled = true;
        }
            if (AttackControl.getArc == true && this.name == "ControlArc")
        {
            
            if (this.name == "NumeroFletxes")
            {
                FletxesText.GetComponent<Text>().enabled = true;
                FletxesText.text = "Fletxes: " + numFletxes;
            }

            if (estatArc == true)
            {
                Arc.enabled = true;
                ArcDes.enabled = false;
            }
            else
            {
                Arc.enabled = false;
                ArcDes.enabled = true;
            }
        }

        if (AttackControl.getArc == true && this.name == "NumeroFletxes" && estatArc == true)
        {
            FletxesText.GetComponent<Text>().enabled = true;
            FletxesText.text = "" + numFletxes;
        }

        if (this.name == "NumeroFletxes" && estatArc == false)
        {
            FletxesText.GetComponent<Text>().enabled = false;
        }
        if (AttackControl.getBumerang == true && this.name == "ControlBum")
        {
            if (estatBum == true)
            {
                Bum.enabled = true;
                BumDes.enabled = false;
            }
            else
            {
                Bum.enabled = false;
                BumDes.enabled = true;
            }
        }

        if (AttackControl.getBumerang == false && this.name == "ControlBum")
        {
            
                Bum.enabled = false;
                BumDes.enabled = false;
            
        }

        if (vida < 0)
        {
            vida = 0;
            vida = maxVida;
        }
        if (this.name == "VidaText")
        {
            VidaText.text = "Vida: " + vida;
            healthBar.SetMaxHealth(maxVida);
            healthBar.SetHealth(vida);
        }
       
        if (this.name == "ClausText")
        {
            ClausText.text = "Claus: " + numClaus;
        }
        if(this.name == "NumeroFletxes")
        {
            FletxesText.text = "" + numFletxes;
        }
        if (this.name == "platjaOrbe1")
        {
            //orbeNum1.text = "Orbe1 = " + orbe1;
            if (posicioAlMon.orbe1 == true)
            {

                orbeplatjadesactivat.enabled = false;
                orbeplatja.enabled = true;
            }
        }
        if (this.name == "gelOrbe2")
        {
            //orbeNum2.text = "Orbe2 = " + orbe2;
            if (posicioAlMon.orbe2 == true)
            {

                orbegeldesactivat.enabled = false;
                orbegel.enabled = true;
            }
        }
        if (this.name == "focOrbe3")
        {
            //orbeNum3.text = "Orbe3 = " + orbe3;
            if (posicioAlMon.orbe3 == true)
            {
                //Debug.Log("helouuuuuu");
                orbefocdesactivat.enabled = false;
                orbefoc.enabled = true;
            }
        }
        if (this.name == "boscOrbe4")
        {
            //orbeNum4.text = "Orbe4 = " + orbe4;
            if (posicioAlMon.orbe4 == true)
            {

                orbearbredesactivat.enabled = false;
                orbearbre.enabled = true;
            }
        }

        //Debug.Log("HUD vida actual: "+vida);
    }
}
