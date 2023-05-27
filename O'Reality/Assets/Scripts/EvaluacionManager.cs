using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.MixedReality.Toolkit.UI;

public class EvaluacionManager : MonoBehaviour
{
    private List<EvaluacionStep> evaluacionSteps = new List<EvaluacionStep>();
    private int currentStepIndex = 0;

    //Botones
    public GameObject botonGuantes;
    public GameObject botonGafas;
    public GameObject botonPieza;
    public GameObject botonOn;
    public GameObject botonPuerta;
    public GameObject botonPantalla;

    //Pantalla
    public Camera mainCamera;
    public Text instructionText;
    public RectTransform tutorialCanvas;
    public FadeCanvas fadeCanvasScript;
    public AudioSource audioAcierto;
    public float canvasDistance;
    public float canvasHorizontalOffset;

    // Start is called before the first frame update
    void Start()
    {
        audioAcierto.Stop();
        rellenarPasos();
    }

    // Update is called once per frame
    void Update()
    {

        if (tutorialCanvas != null && mainCamera != null)
        {
            posicionPantalla();
        }
        if (IsClicked(botonPieza))
        {
            int count = evaluacionSteps.Count;
            float puntuacion = 0;

            foreach (EvaluacionStep evaluacionStep in evaluacionSteps)
            {
                if (IsClicked(evaluacionStep.target))
                {
                    puntuacion += 1/count;
                    instructionText.text = puntuacion;
                }
            }
        }
    }

    private void rellenarPasos()
    {
        evaluacionSteps.Add(new EvaluacionStep(botonPieza, 6, "Elige la pieza a tallar"));
    }

    private void posicionPantalla()
    {
        Vector3 desiredPosition = mainCamera.transform.position + mainCamera.transform.forward * canvasDistance;
        Vector3 cameraToCanvas = tutorialCanvas.position - mainCamera.transform.position;
        Vector3 canvasRightOffset = mainCamera.transform.right * canvasHorizontalOffset;
        Vector3 canvasOffset = Vector3.Cross(mainCamera.transform.forward, Vector3.up).normalized * canvasRightOffset.magnitude;
        desiredPosition += canvasOffset;

        tutorialCanvas.position = desiredPosition;
        tutorialCanvas.rotation = Quaternion.LookRotation(tutorialCanvas.position - mainCamera.transform.position);
    }

    private bool IsClicked(GameObject targetObject)
    {
        Interactable interactable = targetObject.GetComponent<Interactable>();

        // Verifica si el objeto tiene el componente Interactable
        if (interactable != null)
        {
            // Verifica si el objeto ha sido clicado utilizando su propiedad "IsClicked"
            if (interactable.ClickCount == 1)
            {
                return true;
            } 
        }
        return false;
    }
}
