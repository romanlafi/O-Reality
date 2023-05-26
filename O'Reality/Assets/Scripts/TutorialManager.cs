using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.MixedReality.Toolkit.UI;

public class TutorialManager : MonoBehaviour
{
    private List<TutorialStep> tutorialSteps = new List<TutorialStep>();
    private int currentStepIndex = 0;

    public GameObject botonOn;
    public GameObject botonPuerta;

    public Camera mainCamera;
    public Text instructionText;
    public RectTransform tutorialCanvas;
    public float canvasDistance = 0.8f;
    public float canvasHorizontalOffset = -0.2f;
    
    // Start is called before the first frame update
    void Start()
    {
        rellenarPasos();
    }

    // Update is called once per frame
    void Update()
    {
        // Verifica si el tutorial ha terminado
        if (currentStepIndex >= tutorialSteps.Count)
        {
            // Realiza acciones cuando se completa el tutorial
            instructionText.text = "Tutorial completado";

            Debug.Log("Tutorial completado.");
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

            Vector3 desiredPosition = mainCamera.transform.position + mainCamera.transform.forward * canvasDistance;
            Vector3 cameraToCanvas = tutorialCanvas.position - mainCamera.transform.position;
            Vector3 canvasRightOffset = mainCamera.transform.right * canvasHorizontalOffset;
            Vector3 canvasOffset = Vector3.Cross(mainCamera.transform.forward, Vector3.up).normalized * canvasRightOffset.magnitude;
            desiredPosition += canvasOffset;

            tutorialCanvas.position = desiredPosition;
            tutorialCanvas.rotation = Quaternion.LookRotation(tutorialCanvas.position - mainCamera.transform.position); // Asegura que el canvas siempre esté enfocado hl canvas siempre esté enfocado hacia la cámara
            
            //Vector3 desiredPosition = mainCamera.transform.position + mainCamera.transform.forward * canvasDistance;
            //desiredPosition += mainCamera.transform.right * canvasOffset; // Desplaza el canvas hacia un lado (ajusta según tus necesidades)
            //tutorialCanvas.anchoredPosition3D = desiredPosition;
            //tutorialCanvas.rotation = Quaternion.LookRotation(tutorialCanvas.position - mainCamera.transform.position);
            
            //tutorialCanvas.transform.position = mainCamera.transform.position + mainCamera.transform.forward * 1f;
            //tutorialCanvas.transform.rotation = mainCamera.transform.rotation;
        }

    }

    private void rellenarPasos()
    {
        tutorialSteps.Add(new TutorialStep(botonOn, "Haz clic en el botón de encendido"));
        tutorialSteps.Add(new TutorialStep(botonPuerta, "Cierra la puerta utilizando el botón"));
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
