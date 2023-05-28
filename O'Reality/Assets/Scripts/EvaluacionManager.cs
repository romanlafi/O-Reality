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

    //Pantalla
    public Camera mainCamera;
    public Text notaText;
    public Text resultadoText;
    public Text fallosText;
    public Canvas canvas;
    public RectTransform tutorialCanvas;
    public FadeCanvas fadeCanvasScript;
    public AudioSource audioAcierto;
    public float canvasDistance;
    public float canvasHorizontalOffset;

    // Start is called before the first frame update
    void Start()
    {
        puntuacion = 0;
        fin = false;
        canvas.enabled = false;
        fallosText.text = string.Empty;
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

        if (IsClicked(botonPieza) && !fin)
        {
            fin = true;
            contarPuntos();
            formatoPantalla();
        }
    }

    private void contarPuntos()
    {
        int count = evaluacionSteps.Count;
        float valorPaso = 1f/count;

        Debug.Log("Valor paso " + valorPaso);

        for (int i=0 ; i<evaluacionSteps.Count ; i++)
        {
            EvaluacionStep step = evaluacionSteps[i];

            if (IsClicked(step.target))
            {
                Debug.Log(step.target.name + " sumado");

                puntuacion += valorPaso;

                Debug.Log("nota acomulada " + puntuacion);
                notaText.text = (puntuacion* 10).ToString("F2");
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
            
        } else {
            notaText.color = Color.red;

            resultadoText.text = "Suspenso";
            resultadoText.color = Color.red;
        }

        for (int i=0 ; i<evaluacionFallos.Count ; i++)
        {   
            EvaluacionStep step = evaluacionFallos[i];
            fallosText.text += step.ToString();
        }

        canvas.enabled = true;
    }

    private void rellenarPasos()
    {
        evaluacionSteps.Add(new EvaluacionStep(botonGafas, 1, "Equipar las gafas"));
        evaluacionSteps.Add(new EvaluacionStep(botonGuantes, 2, "Equipar los guantes"));
        evaluacionSteps.Add(new EvaluacionStep(botonPieza, 3, "Insertar pieza en su sitio"));
        Debug.Log("Rellenado");
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
                Debug.Log("Objeto clicado");
            } 
        }
        return false;
    }
}
