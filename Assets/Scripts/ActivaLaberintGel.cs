using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivaLaberintGel : MonoBehaviour
{
    public GameObject OrbePortal;
    public GameObject Interruptor;
    public GameObject TriggerIglu;
    public GameObject camaraSeguiment;
    public GameObject camaraEscena;
    public GameObject iglu;
    public static bool adeuIglu = false;
    
    private bool comprovacio = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (adeuIglu == true)
        {
            iglu.gameObject.transform.position += new Vector3(0, -5, 0) * Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Arma" && comprovacio == false)
        {
            Debug.Log("tocat");
            OrbePortal.SetActive(true);
            TriggerIglu.SetActive(false);
            
            
            comprovacio = true;//perque no salti missatge d'error
            camaraSeguiment.SetActive(false);
            camaraEscena.SetActive(true);
            StartCoroutine(IgluFora());
        }


    }

    IEnumerator IgluFora()
    {
        adeuIglu = true;
        yield return new WaitForSeconds(5);
        camaraSeguiment.SetActive(true);
        camaraEscena.SetActive(false);
        adeuIglu = false;
        Interruptor.SetActive(false);
    }
}
