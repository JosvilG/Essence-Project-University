using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events_Illa1 : MonoBehaviour
{
    public GameObject puntEscena;
    public static bool escena;
    public float duration; //set the duration in the inspector
    float elapsedTime = Mathf.Infinity;
    public GameObject camaraPrincipal;
    public GameObject camaraEscena;
    public GameObject camaraSecret;
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
       
        //tot aixo controla la secuencia
        if (escena == true)
        {
            camaraPrincipal.SetActive(false);
            player.SetActive(false);
            camaraEscena.SetActive(true);
            if (elapsedTime < duration)
            {
                puntEscena.transform.Translate(Vector3.up * Time.deltaTime);
                elapsedTime += Time.deltaTime;
                
            }
            else
            {
                escena = false;
                camaraPrincipal.SetActive(true);
                player.SetActive(true);
                camaraEscena.SetActive(false);
            }
        }
    }
    


}
