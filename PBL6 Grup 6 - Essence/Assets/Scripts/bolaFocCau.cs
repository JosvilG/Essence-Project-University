using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolaFocCau : MonoBehaviour
{
    Vector3 posicioActual;
    public GameObject parent;
    public GameObject ombra;
    int randomVel;
    int randomAlt;
    int randomPos;

    // Start is called before the first frame update
    void Start()
    {
            randomPos = Random.Range(1, 20);
            randomAlt = Random.Range(100, 200);//alçada a la que apareix
            this.transform.position = this.transform.position + new Vector3(randomPos, randomAlt, randomPos);
            ombra.transform.position = ombra.transform.position + new Vector3(randomPos, 0, randomPos);
            posicioActual = this.transform.position;
            randomVel = Random.Range(40, 70);
    }

    // Update is called once per frame
    void Update()
    {
        if (Dragon.repetirBoles == true)
        {
            parent.SetActive(true);
            Dragon.repetirBoles = false;
        }
        for (int i = 0; i < randomVel; i++)//velocitat a la que cau
        {
            this.transform.Translate(Vector3.down * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (this.name == "bolaFoc" && other.tag == "Player")
        {
            PlayerControl.hit = true;
        }
        if (other.tag == "Limit")
        {
            this.transform.position = posicioActual;
            parent.SetActive(false);
        }
        
    }
}
