using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equiparAccesorio : MonoBehaviour
{
    public GameObject objetoEquipado;

    public void Equipar()
    {
        objetoEquipado.SetActive(false);
    }
}
