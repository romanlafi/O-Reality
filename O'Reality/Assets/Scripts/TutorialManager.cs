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
    private bool fin; 

    //Botones
    public GameObject botonGuantes;
    public GameObject botonGafas;
    public GameObject botonPieza;
    public GameObject botonOn;
    public GameObject botonPuerta;
    public GameObject botonPantalla;
    public GameObject botonesMenu;

    //Pantalla
    public Camera mainCamera;
    public Text instructionText;
    public RectTransform tutorialCanvas;
    public Canvas canvas;
    public FadeCanvas fadeCanvasScript;
    public AudioSource audioAcierto;
    public float canvasDistance;
    public float canvasHorizontalOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        fin = false;
        botonesMenu.SetActive(false);
        audioAcierto.Stop();
        rellenarPasos();
    }

    // Update is called once per frame
    void Update()
    {
        // Verifica si el tutorial ha terminado
        if (currentStepIndex >= tutorialSteps.Count && !fin)
        {
            fin = true;
            terminarTutorial();
            return;
        }

        // Obtiene el paso actual
        TutorialStep currentStep = tutorialSteps[currentStepIndex];

        if (IsClicked(currentStep.target))
        {
            currentStepIndex++;
            audioAcierto.Play();
        }

        if (tutorialCanvas != null && mainCamera != null)
        {
            instructionText.text = currentStep.instruction;
            posicionPantalla();
        }
    }

    private void rellenarPasos()
    {
        tutorialSteps.Add(new TutorialStep(botonGafas, "Coge las gafas de seguridad"));
        tutorialSteps.Add(new TutorialStep(botonGuantes, "Coge los guantes de seguridad"));
        tutorialSteps.Add(new TutorialStep(botonPieza, "Coge la pieza a tallar y depsítala en la zona de corte"));
        tutorialSteps.Add(new TutorialStep(botonOn, "Haz clic en el botón de encendido de la máquina"));
        tutorialSteps.Add(new TutorialStep(botonPuerta, "Cierra la puerta utilizando el botón"));
        tutorialSteps.Add(new TutorialStep(botonPantalla, "Selecciona la primera pieza para tallarla"));
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
        instructionText.text = "Tutorial completado!\nAhora puedes abrir la puerta y coger la pieza tallada";
        fadeCanvasScript.Fade();
        botonesMenu.SetActive(true);
    }

    private bool IsClicked(GameObject targetObject)
    {
        Interactable interactable = targetObject.GetComponent<Interactable>();

        // Verifica si el objeto tiene el componente Interactable
        if (interactable != null)
        {
            // Verifica si el objeto ha sido clicado utilizando su propiedad "IsClicked"
            if (interactable.ClickCount >= 1)
            {
                interactable.enabled = false;
                interactable.enabled = true;

                Debug.Log(targetObject.name + "Clicado y reiniciado");
                return true;
            } 
        }
        return false;
    }
}
