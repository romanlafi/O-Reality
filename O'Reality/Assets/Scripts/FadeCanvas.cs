using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeCanvas : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeDuration = 5;
    public float delay;

    private bool fading = false;

    public void Fade()
    {
        StartCoroutine(FadeOut());
        Debug.Log("Fade iniciado");

        fading = true;
    }

    private void Start()
    {
        if (canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();
    }

    private System.Collections.IEnumerator FadeOut()
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
}
