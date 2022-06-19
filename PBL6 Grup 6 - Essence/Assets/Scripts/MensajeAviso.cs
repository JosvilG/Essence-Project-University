using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MensajeAviso : MonoBehaviour
{
    
    public Transform mensajeControles;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           mensajeControles.gameObject.SetActive(false);
        }
    }
}
