using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.MixedReality.Toolkit.UI;

public class EvaluacionManager : MonoBehaviour
{
    //Evaluacion
    private List<EvaluacionStep> evaluacionSteps = new List<EvaluacionStep>();
    private List<EvaluacionStep> evaluacionFallos = new List<EvaluacionStep>();
    private int currentStepIndex = 0;
    private float puntuacion;
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
    public Text notaText;
    public Text resultadoText;
    public Text fallosText;
    public Canvas canvas;
    public RectTransform tutorialCanvas;
    public FadeCanvas fadeCanvasScript;
    public AudioSource audioAcierto;
    public AudioSource audioFallo;
    public float canvasDistance;
    public float canvasHorizontalOffset;

    // Start is called before the first frame update
    void Start()
    {
        botonesMenu.SetActive(false);
        puntuacion = 0;
        fallosText.text = string.Empty;
        fin = false;
        canvas.enabled = false;
        audioAcierto.Stop();
        audioFallo.Stop();
        rellenarPasos();
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorialCanvas != null && mainCamera != null)
        {
            posicionPantalla();
        }

        if (IsClicked(botonPantalla) && !fin)
        {
            fin = true;
            contarPuntos();
            formatoPantalla();
            fadeCanvasScript.encenderCanvas();
            botonesMenu.SetActive(true);
            fadeCanvasScript.Fade();
        }
    }

    private void contarPuntos()
    {
        int count = evaluacionSteps.Count;
        float valorPaso = 1f/count;

        for (int i=0 ; i<evaluacionSteps.Count ; i++)
        {
            EvaluacionStep step = evaluacionSteps[i];

            if (IsClicked(step.target))
            {
                puntuacion += valorPaso;
                notaText.text = (puntuacion * 10).ToString("#.##");
            } else {
                evaluacionFallos.Add(step);
            }
        }
    }

    private void formatoPantalla()
    {
        if (puntuacion >= 0.5)
        {
            notaText.color = Color.green;

            resultadoText.text = "Aprobado";
            resultadoText.color = Color.green;
            audioAcierto.Play();
            
        } else {
            notaText.color = Color.red;

            resultadoText.text = "Suspenso";
            resultadoText.color = Color.red;
            audioFallo.Play();
            Debug.Log("Suspendido");
        }

        for (int i=0 ; i<evaluacionFallos.Count ; i++)
        {   
            EvaluacionStep step = evaluacionFallos[i];
            fallosText.text += step.ToString() + "\n";
        }

        if (string.IsNullOrEmpty(fallosText.text))
        {
            fallosText.text = "No has tenido fallos, enhorabuena!";
        }

        canvas.enabled = true;
    }

    private void rellenarPasos()
    {
        evaluacionSteps.Add(new EvaluacionStep(botonGafas, 1, "Equipar las gafas"));
        evaluacionSteps.Add(new EvaluacionStep(botonGuantes, 2, "Equipar los guantes"));
        evaluacionSteps.Add(new EvaluacionStep(botonPieza, 3, "Insertar pieza en su sitio"));
        evaluacionSteps.Add(new EvaluacionStep(botonOn, 4, "Encender la máquina"));
        evaluacionSteps.Add(new EvaluacionStep(botonPuerta, 5, "Cerrar la puerta"));
        evaluacionSteps.Add(new EvaluacionStep(botonPantalla, 6, "Seleccionar la pieza a tallar"));
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
