using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class TransformarPieza : MonoBehaviour
{
    public GameObject antes; // Referencia al objeto Cylinder
    public GameObject despues; // Referencia al prefab .obj
    private bool tallar;

    public void TallarPieza()
    {
        if (!tallar)
        {
            tallar = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        tallar = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (tallar)
        {
            Transform();
        }
    }

    private void Transform()
    {
        MeshRenderer meshRenderer = antes.GetComponent<MeshRenderer>();
        if (meshRenderer == null)
        {
            return;
        }

        // Obtener el nuevo objeto Mesh que deseas utilizar
        Mesh nuevoMesh = despues.GetComponent<MeshFilter>().sharedMesh;
        if (nuevoMesh == null)
        {
            return;
        }

        // Asignar el nuevo objeto Mesh al componente MeshFilter del objeto 'antes'
        MeshFilter meshFilter = antes.GetComponent<MeshFilter>();
        if (meshFilter == null)
        {
            meshFilter = antes.AddComponent<MeshFilter>();
        }
        meshFilter.sharedMesh = nuevoMesh;

        Vector3 nuevoTamaño = despues.transform.localScale;
        antes.transform.localScale = nuevoTamaño;

        Vector3 newPosition = antes.transform.localPosition;
        newPosition += new Vector3(0f, -0.017f, 0f);

        antes.transform.localPosition = newPosition;

        tallar = false;
    }
}
