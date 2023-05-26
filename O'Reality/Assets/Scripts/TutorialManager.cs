using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.MixedReality.Toolkit.UI;

public class TutorialManager : MonoBehaviour
{
    //Objetos para el tutorial
    private List<TutorialStep> tutorialSteps = new List<TutorialStep>();
    private int currentStepIndex = 0;
    private bool final;

    //Botones
    public GameObject botonOn;
    public GameObject botonPuerta;

    //Pantalla
    public Camera mainCamera;
    public Text instructionText;
    public RectTransform tutorialCanvas;
    public FadeCanvas fadeCanvasScript;
    public float canvasDistance;
    public float canvasHorizontalOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        final = false;
        rellenarPasos();
    }

    // Update is called once per frame
    void Update()
    {
        // Verifica si el tutorial ha terminado
        if (currentStepIndex >= tutorialSteps.Count)
        {
            currentStepIndex = -1;
            terminarTutorial();
            return;
        }

        // Obtiene el paso actual
        TutorialStep currentStep = tutorialSteps[currentStepIndex];

        // Verifica si se ha hecho clic en el objeto objetivo del paso actual
        if (IsClicked(currentStep.target))
        {
            // Realiza acciones relacionadas con el clic en el objeto objetivo
            Debug.Log("Objeto clicado: " + currentStep.target.name);

            // Avanza al siguiente paso
            currentStepIndex++;
        }

        if (tutorialCanvas != null && mainCamera != null)
        {
            instructionText.text = currentStep.instruction;
            posicionPantalla();
        }
    }

    private void rellenarPasos()
    {
        tutorialSteps.Add(new TutorialStep(botonOn, "Haz clic en el botón de encendido"));
        tutorialSteps.Add(new TutorialStep(botonPuerta, "Cierra la puerta utilizando el botón"));
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

    private void terminarTutorial()
    {
        instructionText.text = "Tutorial completado";
        fadeCanvasScript.Fade();

        Debug.Log("Tutorial completado.");
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
        } else {
            Debug.LogError("No hay componente interactable");
        }

        return false;
    }
}
