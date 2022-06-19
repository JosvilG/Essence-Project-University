using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamaraCutscenes : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim.SetTrigger("Simple_Atack_Animation");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (this.name == "triggerCamaraEscenaMuntanya" && other.tag == "Player")
        {

        }
    }

}
