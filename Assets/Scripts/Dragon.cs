using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    private Animator animator_dragon;
    private Quaternion rotation;
    public static bool fase1 = true;
    public static bool fase2 = false;
    public static bool fase3 = false;
    public static bool volar = false;
    public static bool embestir = false;
    public static bool posicioInicial1=true;//Posicio pel drac a la part nord del escenari
    public static bool posicioInicial2=false;//Posicio pel drac a la part sud del escenari
    public static bool dracVulnerable = false;
    public static bool acabaVulnerable = false;

    //Comprovacions de que es pot continuar amb la seguent animacio

    public bool acabaVolar = false;
    public bool segonVolar = false;
    public bool potSeguir = false;
    public bool potRepetir = false;
    public bool bolesFoc = false;
    public bool acabaTirarBoles = false;
    public static bool repetirBoles = false;

    public int randomPos = 1;
    public int randomEmbestir = 0;
    public int vegades = 3;
    public int repetir = 0;
    
    public Transform posicio1;
    public Transform[] posicions1;
    public Transform[] posicions2;
    public Transform posicio2;
    public Transform objectiuEmbestir;

    Vector3 currentPosition;
    Quaternion startRotation;

    public GameObject drac;
    public GameObject grupBolesFoc;
    public GameObject posicioNord;
    public GameObject posicioSud;
    public GameObject camaraCombat1;//camara drac zona nord i inicial
    public GameObject camaraCombat2;//camara drac zona sud
    public GameObject camaraVolar1;//quan el drac surt volant
    public GameObject camaraEmbestir1;//mira cap a on embestira el drac
    public GameObject camaraEmbestir2;
    public GameObject camaraAeria;
    public GameObject camaraMort1;
    public GameObject camaraMort2;

    public GameObject iniciaCredits;

    public static int hp = 3;
    public int comprovaHP;

    void Start()
    {
        animator_dragon = GetComponent<Animator>();
        rotation = transform.rotation;
        comprovaHP = hp;
    }

    void Update()
    {
        if (hp <= 0)
        {
            mort();
        }
        else
        {
            if (vegades > 0 && potRepetir == true)//Aqui determina la quantitat d'atacs seguits que fara avans de quedarse vulnerable
            {
                /*if (fase2 == true)
                {
                    fase2=false;
                    fase3 = true;
                    vegades = 9;
                }else if (fase1 == true)
                {
                    fase1 = false;
                    fase2 = true;
                    vegades = 6;
                }*/
                Debug.Log("Pot fer " + vegades + " atacs restants");
                potRepetir = false;
                this.transform.rotation = rotation;
                repetir = Random.Range(1, 3);
                //repetir = 1;
                RepiteAtaque();

            }
            else
            {
                potRepetir = false;
            }
            if (vegades == 0)//Quan es queda sense oportunitats de atacar ha de baixar a un dels llocs perque el puguis atacar
            {
                aterrar();
                //this.transform.rotation = rotation;
                animator_dragon.Play("Aterrizar");
                StartCoroutine(Aterrizar(1.12f));
                vegades = 3;
                if (hp == 1)//Fase final
                {
                    vegades = 6;
                }
            }
            if (volar == true)//El drac surt volant la primera vegada
            {

                animator_dragon.Play("Salir Volando");
                fase1 = false;
                volar = false;
                camaraCombat1.SetActive(false);
                camaraVolar1.SetActive(true);
                StartCoroutine(SalirVolando(3.05f));
                acabaVolar = false;
                /*if (acabaVolar == true)
                {
                    EligeAtaque();
                    //acabaVolar = false;
                }*/

            }

            if (segonVolar == true)//El drac surt volant la segona vegada
            {
                animator_dragon.Play("Salir Volando");
                segonVolar = false;
                acabaVolar = false;
                StartCoroutine(SalirVolando(3.05f));

            }

            if (acabaVulnerable == true)
            {
                noVulnerable();
            }
            if (embestir == true)//El drac aterra en un dels 2 llocs i embesteix
            {
                if (randomPos == 1)
                {
                    objectiuEmbestir = posicio2;
                    animator_dragon.Play("Aterrizar");
                    embestir = false;
                    StartCoroutine(BajarYEmbestir(1.12f));
                }
                else if (randomPos == 2)
                {
                    animator_dragon.Play("Aterrizar");
                    objectiuEmbestir = posicio1;
                    embestir = false;
                    StartCoroutine(BajarYEmbestir(1.12f));
                }

            }

            if (potSeguir == true && randomPos == 1)//Velocitat de moviment al embestir
            {
                this.gameObject.transform.position += new Vector3(-150 * vegades, 0, 0) * Time.deltaTime;
            }
            else if (potSeguir == true && randomPos == 2)
            {
                this.gameObject.transform.position += new Vector3(150 * vegades, 0, 0) * Time.deltaTime;
            }

            if (bolesFoc == true)
            {
                bolesFoc = false;
                grupBolesFoc.SetActive(true);
                for (int a = 0; a < grupBolesFoc.transform.childCount; a++)
                {
                    grupBolesFoc.transform.GetChild(a).gameObject.SetActive(true);
                }

                StartCoroutine(TirarBolesCel(6.0f));

            }
        }
    }

    /******************************METODES DELS ATACS**************************/

    void EligeAtaque()//Tria el primer atac de una rotacio
    {
        int randomTria = Random.Range(1, 3);
        Debug.Log("Numero triat: " + randomTria);
        if (randomTria == 1)//Boles de foc del cel
        {
            desactivaCamares(camaraAeria);
            posicio1 = posicions1[randomEmbestir];
            this.gameObject.transform.position = posicio1.position + new Vector3(0,50,0);
            bolesFoc = true;
            //Debug.Log("numero 1");
        }
        else if (randomTria == 2)//Embestir volant
        {
            
            embestir = true;
            randomPos = Random.Range(1, 3);
            randomEmbestir = Random.Range(0, 3);
            
            if (randomPos == 1)
            {
                posicio1 = posicions1[randomEmbestir];
                this.gameObject.transform.position = posicio1.position;
                if (posicioInicial2 == false)
                {
                    this.transform.Rotate(0, -90, 0);
                }
                else if (posicioInicial2 == true)
                {
                    this.transform.Rotate(0, 90, 0);

                }
                //this.transform.Rotate(0, -90, 0);
                //camaraVolar1.SetActive(false);
                desactivaCamares(camaraEmbestir1);
                //camaraEmbestir1.SetActive(true);
            }
            else if (randomPos == 2)
            {
                posicio1 = posicions2[randomEmbestir];
                this.gameObject.transform.position = posicio2.position;
                if (posicioInicial2 == false)
                {
                    this.transform.Rotate(0, 90, 0);
                }
                else if (posicioInicial2 == true)
                {
                    this.transform.Rotate(0, -90, 0);

                }
                //this.transform.Rotate(0, 90, 0);
                //camaraVolar1.SetActive(false);
                //camaraEmbestir2.SetActive(true);
                desactivaCamares(camaraEmbestir2);
            }
            //Debug.Log("numero 2");
        }
        else if (randomTria == 3)//Baixar al altre costat per tirar foc
        {
            //Debug.Log("numero 3");
        }
    }

    void RepiteAtaque()//Tria el atac seguent dintre una rotació
    {
        Debug.Log("Numero triat repe: " + repetir);
        this.gameObject.transform.position += new Vector3(0, 0, 0) * Time.deltaTime;
        this.transform.rotation = rotation;
        if (repetir == 1)//Boles de foc del cel
        {
            repetirBoles = true;
            camaraAeria.SetActive(true);
            posicio1 = posicions1[randomEmbestir];
            this.gameObject.transform.position = posicio1.position + new Vector3(0, 50, 0);
            bolesFoc = true;
        }
        else if (repetir == 2)//Embestir volant
        {
            embestir = true;
           
            randomPos = Random.Range(1, 3);
            randomEmbestir = Random.Range(0, 3);
            if (randomPos == 1)
            {
                posicio1 = posicions1[randomEmbestir];
                this.gameObject.transform.position = posicio1.position;
                if (posicioInicial2 == false)
                {
                    this.transform.Rotate(0, -90, 0);
                }
                else if (posicioInicial2 == true)
                {
                    this.transform.Rotate(0, -90, 0);

                }
                //this.transform.Rotate(0, -90, 0);
                //camaraVolar1.SetActive(false);
                desactivaCamares(camaraEmbestir1);
                //camaraEmbestir1.SetActive(true);
            }
            else if (randomPos == 2)
            {
                posicio1 = posicions2[randomEmbestir];
                this.gameObject.transform.position = posicio2.position;
                if (posicioInicial2 == false)
                {
                    this.transform.Rotate(0, 90, 0);
                }
                else if (posicioInicial2 == true)
                {
                    this.transform.Rotate(0, 90, 0);

                }
                //this.transform.Rotate(0, 90, 0);
                //camaraVolar1.SetActive(false);
                //camaraEmbestir2.SetActive(true);
                desactivaCamares(camaraEmbestir2);
            }
            /* if (randomPos == 1)
             {
                 posicio1 = posicions1[randomEmbestir];
                 this.gameObject.transform.position = posicio1.position;
                 if (posicioInicial1 == true)
                 {
                     this.transform.Rotate(0, -90, 0);
                 }
                 else if (posicioInicial1 == false)
                 {
                     this.transform.Rotate(0, 90, 0);

                 }
                 camaraVolar1.SetActive(false);
                 camaraEmbestir1.SetActive(true);
                 camaraEmbestir2.SetActive(false);
             }
             else if (randomPos == 2)
             {
                 posicio1 = posicions1[randomEmbestir];
                 this.gameObject.transform.position = posicio2.position;
                 this.transform.Rotate(0, 90, 0);
                 camaraVolar1.SetActive(false);
                 camaraEmbestir2.SetActive(true);
                 camaraEmbestir1.SetActive(false);
             }*/
        }
        else if (repetir == 3)//Baixar al altre costat per tirar foc
        {
            //Debug.Log("numero 3 repe");
        }
        
    }

    void mort()
    {
        StopAllCoroutines();
        animator_dragon.Play("Muerte");
        if (posicioInicial1 == true)
        {
            desactivaCamares(camaraMort1);
        }
        if (posicioInicial2 == true)
        {
            desactivaCamares(camaraMort2);
        }

        AcabaJoc.potAcabar = true;
    }

    void desactivaCamares(GameObject camara)//avans de cada accio desactiva totes les camares per si de cas
    {
        camaraCombat1.SetActive(false);
        camaraCombat2.SetActive(false);
        camaraVolar1.SetActive(false);
        camaraEmbestir1.SetActive(false);
        camaraEmbestir2.SetActive(false);
        camaraAeria.SetActive(false);
        camara.SetActive(true);
    }

    void aterrar()//tria on aterrar en base al ultim lloc on ha estat
    {
        if (posicioInicial1 == true)
        {
            this.transform.rotation = rotation;
            posicioInicial1 = false;
            posicioInicial2 = true;
            this.gameObject.transform.Rotate(0, -180, 0);
            this.gameObject.transform.position = posicioSud.transform.position;
            camaraCombat2.SetActive(true);
            camaraEmbestir1.SetActive(false);
            camaraEmbestir2.SetActive(false);

        }
        else if (posicioInicial2 == true)
        {
            posicioInicial1 = true;
            posicioInicial2 = false;
            this.gameObject.transform.position = posicioNord.transform.position;
            this.transform.rotation = rotation;
            camaraCombat1.SetActive(true);
            camaraEmbestir1.SetActive(false);
            camaraEmbestir2.SetActive(false);
        }
    }

    void vulnerable()
    {
        Debug.Log("VULNERABLE vida: "+hp);
        acabaVulnerable = false;
        animator_dragon.Play("Bajar Cabeza");
        dracVulnerable = true;
        StartCoroutine(BajaCabeza(2.05f));
        
    }

    void noVulnerable()
    {
        Debug.Log("INVULNERABLE vida: " + hp);
        animator_dragon.Play("Subir Cabeza");
        StartCoroutine(SubeCabeza(1.07f));
    }
    
    void ScaleModelTo(Vector3 scale)
    {
        this.transform.localScale = scale;
    }



    /*********************************CORUTINES*************************/
    
    IEnumerator BajarYEmbestir(float segons)
    {
            yield return new WaitForSeconds(segons);
            StartCoroutine(Embestir(5.20f));
        //potSeguir = true;
        
        
    }

    IEnumerator Embestir(float segons)
    {
        StartCoroutine(EsperaEmbestir(2.0f));
        animator_dragon.Play("Embestir");
        yield return new WaitForSeconds(segons);
        potSeguir = false;
        potRepetir = true;
        vegades--;
    }

    IEnumerator EsperaEmbestir(float segons)
    {
        yield return new WaitForSeconds(segons);
        potSeguir = true;
    }

    IEnumerator SalirVolando(float segons)
    {
        if (acabaVolar == false)
        {
            yield return new WaitForSeconds(segons);
            EligeAtaque();
            acabaVolar = true;
            StopAllCoroutines();
        }
    }

    IEnumerator Aterrizar(float segons)
    {
            yield return new WaitForSeconds(segons);
            vulnerable();
    }

    IEnumerator BajaCabeza(float segons)
    {
        yield return new WaitForSeconds(segons);
    }

    IEnumerator SubeCabeza(float segons)
    {
        yield return new WaitForSeconds(segons);
        segonVolar = true;
        dracVulnerable = false;
        acabaVulnerable = false;
    }

    IEnumerator TirarBolesCel(float segons)
    {
        yield return new WaitForSeconds(segons);
        potRepetir = true;
        grupBolesFoc.SetActive(false);
        vegades--;
    }

    IEnumerator PerderHP()
    {

        for (float i = 0; i <= 1; i += 0.15f)
        {
            if (this.transform.localScale == new Vector3(2.264011f, 2.264011f, 2.264011f))
            {
                ScaleModelTo(Vector3.zero);
            }
            else
            {
                ScaleModelTo(new Vector3(2.264011f, 2.264011f, 2.264011f));
            }
            yield return new WaitForSeconds(0.15f);
        }
        
        ScaleModelTo(new Vector3(2.264011f, 2.264011f, 2.264011f));
        StopCoroutine(PerderHP());
    }
}


/*
 
Idle 00:00:06:19

Salir Volando 00:00:02:05

Aterrizar 00:00:01:12

Zarpazo 00:00:01:02

Embestir 00:00:05:20

Disparar Fuego 00:00:01:10

Subir Cabeza 00:00:01:07

Bajar Cabeza 00:00:02:05

Muerte 00:00:02:25
     
     
*/

/*if (Input.GetKeyDown(KeyCode.Z)){
        animator_dragon.Play("Idle");
    }

    if (Input.GetKeyDown(KeyCode.X)){
        animator_dragon.Play("Salir Volando");
    }

    if (Input.GetKeyDown(KeyCode.C)){
        animator_dragon.Play("Aterrizar");
    }

    if (Input.GetKeyDown(KeyCode.A))
    {
        animator_dragon.Play("Zarpazo");
    }

    if (Input.GetKeyDown(KeyCode.V))
    {
        animator_dragon.Play("Disparar Fuego");
    }

    if (Input.GetKeyDown(KeyCode.B))
    {
        animator_dragon.Play("Bajar Cabeza");
    }

    if (Input.GetKeyDown(KeyCode.N))
    {
        animator_dragon.Play("Subir Cabeza");
    }

    if (Input.GetKeyDown(KeyCode.M))
    {
        animator_dragon.Play("Muerte");
    }

    if (Input.GetKeyDown(KeyCode.E))
    {
        animator_dragon.Play("Embestir");
    }*/
