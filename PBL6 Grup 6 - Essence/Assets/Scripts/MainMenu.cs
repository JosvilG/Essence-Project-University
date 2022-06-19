using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
        posicioAlMon.entra = false;
        posicioAlMon.davant = false;
        posicioAlMon.surt = false;
        AttackControl.getEspasa = false;
        AttackControl.getBumerang = false;
        AttackControl.getArc = false;
        posicioAlMon.orbe1 = false;
        posicioAlMon.orbe2 = false;
        posicioAlMon.orbe3 = false;
        posicioAlMon.orbe4 = false;
    }
    public void CarregaJoc()
    {
        posicioAlMon.potCargar = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");

        Application.Quit();
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

}
