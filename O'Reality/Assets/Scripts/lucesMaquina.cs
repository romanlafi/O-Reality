using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lucesMaquina : MonoBehaviour
{
    public GameObject luzInterior;
    public GameObject luzExterior;
    
    public GameObject bombillaInterior;
    public GameObject bombillaExterior;

    public Renderer rendererInterior;
    public Renderer rendererExterior;

    public Color luzAmarilla;
    public Color luzRoja;

    void Start()
    {
        rendererInterior = bombillaInterior.GetComponent<Renderer>();
        rendererExterior = bombillaExterior.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (luzInterior.activeSelf) {
           rendererInterior.material.EnableKeyword("_EMISSION");
           rendererInterior.material.SetColor("_EmissionColor",  luzAmarilla * 8.0f);
        } else {
           rendererInterior.material.SetColor("_EmissionColor",  Color.black);
        }
        
        if (luzExterior.activeSelf) {
           rendererExterior.material.EnableKeyword("_EMISSION");
           rendererExterior.material.SetColor("_EmissionColor",  luzRoja * 3.0f);
        } else {
           rendererExterior.material.SetColor("_EmissionColor",  Color.black);
        }
    }
}
