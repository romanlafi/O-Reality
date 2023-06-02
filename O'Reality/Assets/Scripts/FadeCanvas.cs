using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeCanvas : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeDuration;
    public float delay;

    public void Fade()
    {
        StartCoroutine(FadeOut());
    }

    public void encenderCanvas()
    {
        StartCoroutine(FadeIn());
    }

    private void Start()
    {
        if (canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(delay);

        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            // Calcular el valor de opacidad intermedio
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);

            // Establecer la opacidad del CanvasGroup
            canvasGroup.alpha = alpha;
            Debug.Log("Transformando alpha");

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Desactivar el objeto Canvas
        canvasGroup.gameObject.SetActive(false);
        Debug.Log("Canvas desactivado");
    }

    IEnumerator FadeIn()
    {
        canvasGroup.gameObject.SetActive(true); // Activar el objeto Canvas

        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            // Calcular el valor de opacidad intermedio
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);

            // Establecer la opacidad del CanvasGroup
            canvasGroup.alpha = alpha;

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Debug.Log("Fade In completado");
    }
}
