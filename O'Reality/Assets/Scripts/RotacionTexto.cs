using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionTexto : MonoBehaviour
{
    public Transform objetoASeguir;
    public TextMesh textoRotante;

    private void Update()
    {
        // Actualizar la posición del objeto "TextoRotante" para que coincida con el objeto a seguir
        transform.position = objetoASeguir.position;

        // Hacer que el objeto "TextoRotante" siempre se oriente hacia la cámara principal
        transform.LookAt(Camera.main.transform);

        // Rotar el texto para que siempre esté en posición horizontal
        textoRotante.transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y + 180f, 0f);
    }
}
