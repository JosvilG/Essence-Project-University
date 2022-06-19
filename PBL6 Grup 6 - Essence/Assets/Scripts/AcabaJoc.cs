using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcabaJoc : MonoBehaviour
{
    public static bool potAcabar;
    // Start is called before the first frame update
    public void ChangetoScene()
    {
        Application.LoadLevel("CreditosFinales");
    }


    // Update is called once per frame
    void Update()
    {
        if (potAcabar == true)
        {
            StartCoroutine(FiJoc());
        } 
    }

    IEnumerator FiJoc()
    {
        Debug.Log("FINAL");
        yield return new WaitForSeconds(5.0f);
        ChangetoScene();


    }
}
