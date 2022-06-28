using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LlamaFadeOut : MonoBehaviour
{
    public Image blackFade;
    void Start()
    {
        blackFade.canvasRenderer.SetAlpha(1.0f);
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        blackFade.CrossFadeAlpha(0, 2, false);
        yield return null;
    }
}
