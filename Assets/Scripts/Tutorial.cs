using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public bool prova1;
    public bool prova2;
    public GameObject camaraNormal;
    public GameObject camaraProva1;
    public GameObject portaProva1v1;
    public GameObject portaProva1v2;
    public GameObject enemic1;
    public Transform panel;
    public GameObject player;
    bool tancarPanell=false;
    public bool control;
    public bool espasa;
    public bool bum;
    public bool hp;
    public bool guardar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemicControler.contadorMorts == 1 && this.name== "triggerProva1")
        {
            portaProva1v1.SetActive(false);
            portaProva1v2.SetActive(false);
            EnemyAI.potSeguir = false;
            camaraNormal.SetActive(true);
            camaraProva1.SetActive(false);
        }

        if (EnemicControler.contadorMorts == 2 && this.name == "triggerProva2")
        {
            portaProva1v1.SetActive(false);
            portaProva1v2.SetActive(false);
        }
        if (tancarPanell == true && Input.GetKeyDown(KeyCode.E))
        {
            player.GetComponent<CharacterController>().enabled = true;
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            panel.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag=="Player" && prova1 == true)
        {
            EnemyAI.potSeguir = true;
            AttackControl.getEspasa = true;
            AttackControl.Espasa = true;
            camaraNormal.SetActive(false);
            camaraProva1.SetActive(true);
            portaProva1v1.SetActive(true);
            portaProva1v2.SetActive(true);
            enemic1.SetActive(true);
            prova1 = false;
        }

        if (collision.tag == "Player" && prova2 == true)
        {
            
            AttackControl.getBumerang = true;
            AttackControl.getArc = true;
            portaProva1v1.SetActive(true);
            portaProva1v2.SetActive(true);
            enemic1.SetActive(true);
            prova2 = false;
        }

        if (this.name == "tutControl" && control == true)
        {
            panel.gameObject.SetActive(true);

            player.GetComponent<CharacterController>().enabled = false;

            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            tancarPanell = true;
            control = false;
        }

        if (this.name == "tutEspasa" && espasa == true)
        {
            panel.gameObject.SetActive(true);

            player.GetComponent<CharacterController>().enabled = false;

            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            tancarPanell = true;
            espasa = false;
        }

        if (this.name == "tutBum" && bum == true)
        {
            panel.gameObject.SetActive(true);

            player.GetComponent<CharacterController>().enabled = false;

            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            tancarPanell = true;
            bum = false;
        }

        if (this.name == "tutHP" && hp == true)
        {
            panel.gameObject.SetActive(true);

            player.GetComponent<CharacterController>().enabled = false;

            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            tancarPanell = true;
            hp = false;
        }

        if (this.name == "tutGuardar" && guardar == true)
        {
            panel.gameObject.SetActive(true);

            player.GetComponent<CharacterController>().enabled = false;

            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            tancarPanell = true;
            guardar = false;
        }
    }

}
