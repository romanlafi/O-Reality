using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pantallaActiva : MonoBehaviour
{
    public Transform cubeContainer;
    private bool funcionando;

    public void Start()
    {
        cubeContainer.gameObject.SetActive(false);
    }

    public void encender()
    {
        if (!funcionando)
        {
            funcionando = true;
        }
    }

    public void apagar()
    {
        if (funcionando)
        {
            funcionando = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (funcionando)
        {
            cubeContainer.gameObject.SetActive(true);
        } else {
            cubeContainer.gameObject.SetActive(false);
        }
    }
}
