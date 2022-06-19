using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AttackControl : MonoBehaviour//original
{


    Animator anim;
    public static int daño = 30;
    public bool tocado = false;
    public bool activaBoom = false;
    public bool activaArc = false;
    public static bool espasaToca = false;
    public GameObject espasaModel;
    public GameObject boomerang;
    public GameObject boomerangTira;
    public GameObject ArcFletxes;
    public GameObject arcDispara;
    public GameObject FletxaTirada;
    private float segons;
    public float tiempo = 1f;
    public static bool Espasa = false;
    public static bool bmrng = false;//boomerang
    public static bool fletxes = false;
    public static bool getEspasa = false;
    public static bool getBumerang = false;
    public static bool getArc = false;
    int id;
  
    // Start is called before the first frame update

    public Collider[] attackHitboxes;

    void Start()
    {
        
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && getEspasa==true)
        {
            HUD.estatEspasa = true;
            HUD.estatArc = false;
            HUD.estatBum = false;
            Espasa = true;
            bmrng = false;
            fletxes = false;
            activaBoom = false;
            activaArc = false;
            daño = 30;
            espasaModel.SetActive(true);
            boomerang.SetActive(false);
            ArcFletxes.SetActive(false);

        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2) && getArc==true)
        {
            HUD.estatEspasa = false;
            HUD.estatArc = true;
            HUD.estatBum = false;
            Espasa = false;
            bmrng = false;
            fletxes = true;
            activaBoom = false;
            activaArc = true;
            daño = 100;
            espasaModel.SetActive(false);
            boomerang.SetActive(false);
            ArcFletxes.SetActive(true);

        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && getBumerang == true)
        {
            HUD.estatEspasa = false;
            HUD.estatArc = false;
            HUD.estatBum = true;
            Espasa = false;
            bmrng = true;
            fletxes = false;
            activaBoom = true;
            activaArc = false;
            daño = 10;
            espasaModel.SetActive(false);
            boomerang.SetActive(true);
            ArcFletxes.SetActive(false);

        }
        if (Espasa)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (deteccioEspasa.atacant == false)
                {
                    AtaqueSimple(attackHitboxes[0]);
                    segons = 0.6f;
                    StartCoroutine(animacions());
                }

            }
        }
        if (bmrng)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (deteccioEspasa.atacant == false)
                {
                    anim.SetTrigger("AtacBoom");
                    segons = 0.1f;
                    StartCoroutine(animacions());
                }
            }
        }
        if (fletxes)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (deteccioEspasa.atacant == false && HUD.numFletxes>0)
                {
                    anim.SetTrigger("AtacFletxes");
                    HUD.numFletxes--;
                    DisparaFletxes();
                    segons = 0.5f;
                    StartCoroutine(animacions());
                }
            }
        }
        
    }

    IEnumerator animacions()
    {
        deteccioEspasa.atacant = true;
        yield return new WaitForSeconds(tiempo);
        
        if (activaBoom == true)
        {
            activaBoom = true;
            boomerang.SetActive(true);
            TiraBoomerang();
            Debug.Log("Atacant: " + deteccioEspasa.atacant + " EnemyAi: "+ EnemyAI.debil);
        }
        if (activaArc == true)
        {
            Debug.Log("ArcDisparat1");
            activaArc = true;
            ArcFletxes.SetActive(true);
            DisparaFletxes();
        }
        deteccioEspasa.atacant = false;
    }

    private void AtaqueSimple(Collider col)
    {
        anim.SetTrigger("Simple_Atack_Animation");
    }

    public void TiraBoomerang()
    {
        boomerang.SetActive(true);
        GameObject clone;
        clone = Instantiate(boomerangTira, new Vector3(transform.position.x+1f, transform.position.y + 3f, transform.position.z), transform.rotation) as GameObject;
    }

    public void DisparaFletxes()
    {
        ArcFletxes.SetActive(true);
        GameObject clone;
        clone = Instantiate(FletxaTirada, new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), transform.rotation) as GameObject;
    }
}
