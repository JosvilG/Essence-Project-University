using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flotacioIlles : MonoBehaviour
{
    public float velocitat;
    public float duracio;
    bool flotaAmunt = false;
    bool parat = false;

    // Update is called once per frame
    void Update()
    {
        if (flotaAmunt == false && parat==false)
        {
            this.gameObject.transform.position += new Vector3(0, -velocitat, 0) * Time.deltaTime;
            StartCoroutine(FlotaAmuntAvall(duracio));
        }else if (flotaAmunt == true && parat == false)
        {
            this.gameObject.transform.position += new Vector3(0, velocitat, 0) * Time.deltaTime;
            StartCoroutine(FlotaAmuntAvall(duracio));
        }
        Debug.Log("Flotacio: " + flotaAmunt);
    }

    IEnumerator FlotaAmuntAvall(float segons)
    {
        yield return new WaitForSeconds(segons);
        StopAllCoroutines();
        StartCoroutine(Espera());
    }

    IEnumerator Espera()
    {
        parat = true;
        this.gameObject.transform.position += new Vector3(0, 0, 0);
        yield return new WaitForSeconds(0.4f);
        parat = false;
        StopAllCoroutines();
        if (flotaAmunt == false)
        {
            flotaAmunt = true;
        }
        else if (flotaAmunt == true)
        {
            flotaAmunt = false;
        }
    }
}
