using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCartell : MonoBehaviour
{
    
    public Text tutorial;
    public GameObject panel;
 
    void OnTriggerEnter(Collider other)
    {
        if( other.tag == "Player")
        {
            tutorial.GetComponent<Text>().enabled = true;
            panel.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            tutorial.GetComponent<Text>().enabled = false;
            panel.SetActive(false);
        }
    }

    void Start()
    {
        tutorial.GetComponent<Text>().enabled = false;
        panel.SetActive(false);
    }
}
