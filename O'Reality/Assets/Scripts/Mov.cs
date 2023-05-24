using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov : MonoBehaviour
{
    public Transform doorPosition;
    public Transform targetPosition;
    private Vector3 referencia;
    public float speed = 2.2f;
    public AudioSource doorAudio;

    // Start is called before the first frame update
    void Start()
    {
        referencia = doorPosition.position;

    }



    void Update()
    {
        // Moves the object forward at two units per second.
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            doorPosition.position = Vector3.MoveTowards(doorPosition.position, targetPosition.position, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            doorPosition.position = Vector3.MoveTowards(doorPosition.position, referencia, speed* Time.deltaTime);

        }

        // el sonido sólo se activa cuando se pulsan los botones izquierdo/derecho
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            doorAudio.Play();
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            doorAudio.Stop();

        }
        if (doorPosition.position == targetPosition.position || doorPosition.position == referencia)
        {
            doorAudio.Stop();
        }

    }


}
