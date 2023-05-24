using System.Collections;
using UnityEngine;

public class ToggleMeshRenderer : MonoBehaviour
{
    bool click = false;
    void Update()
    {
        if (click)
        {
            // Enable the MeshRenderer of the second child object after 10 seconds
            StartCoroutine(Delay(10.0f));
        }


    }


    public void shapeObject()
    {
        // doorAudio.Play();
        if (click == false)
        {

            click = true;
        }
    }
    IEnumerator Delay(float time)
    {
        yield return new WaitForSeconds(time);

        MeshRenderer renderer1 = transform.GetChild(0).GetComponent<MeshRenderer>();
        renderer1.enabled = false;

        MeshRenderer renderer = transform.GetChild(1).GetComponent<MeshRenderer>();
        renderer.enabled = true;
    }
}
