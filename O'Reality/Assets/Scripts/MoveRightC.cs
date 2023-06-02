using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoveRightC : MonoBehaviour
{
    public Transform needle;
    public Transform LeftC;
    public Transform target1;
    public Transform target2;
    bool movingDown;
    bool movingLeft;
    bool movingUP;
    bool movingRight;
    private Vector3 OriginalPos;
    private Animator anim, needleAnim;
    public Transform RightC;
    public ParticleSystem craftingSmoke;
    public ParticleSystem craftingSpark;
    bool call = false;
    bool callback = false;
    bool tallar = false;
    bool stopTallar = false;
    public Canvas canvas;
    public TextMeshProUGUI textMeshPro;
    public RawImage rawImage;
    public Transform cubeContainer;
    private float elapsedTime;
    public AudioSource sonidoCrafteo;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro.enabled = false;
        rawImage.enabled = false;
        needleAnim = needle.GetComponent<Animator>();
        movingDown = false;
        movingLeft = false;
        movingUP = false;
        movingRight = false;
        OriginalPos = transform.position;
        anim = LeftC.GetComponent<Animator>();
        canvas.enabled = false;
        sonidoCrafteo.Stop();
    }


    public void click()
    {
        if (!call)
        {
            call = true;
            StartCoroutine(ResetCall(10f));
        }
    }
    public void clickback()
    {
        if (!callback)
        {
            callback = true;
        }
    }

    private IEnumerator ResetCall(float delay)
    {
        yield return new WaitForSeconds(delay);
        clickback();
    }


    // Update is called once per frame
    void Update()
    {
        if (call)
        {   
            // enable the video video
            textMeshPro.enabled = true;
            rawImage.enabled = true;

            needleAnim.SetBool("turn", true);
            sonidoCrafteo.Play();
            Debug.Log("Crafteando");

            movmment();
        }

        if (callback)
        {   
            // disable the vibration video
            textMeshPro.enabled = false;
            rawImage.enabled = false;

            needleAnim.SetBool("turn", false);
            back();    
        }
    }

    private void movmment()
    {
        if (call)
        {
            movingDown = true;
        }
        
        if (movingDown)
        {

            transform.position = Vector3.MoveTowards(transform.position, target1.position, 0.3f * Time.deltaTime);
            if (transform.position == target1.position)
            {
                movingDown = false;
                movingLeft = true;
            }
        }
        if (movingLeft)
        {

            transform.position = Vector3.MoveTowards(transform.position, target2.position, 1 * Time.deltaTime);
            if (transform.position == target2.position)
            {
                movingLeft = false;
                anim.SetBool("turn", true);
                craftingSmoke.Play();
                craftingSpark.Play();
                call = false;
            }
        }
    }

    private void back()
    {
        if (callback) 
        {
            movingRight = true;
        }
        
        if (movingRight)
        {

            transform.position = Vector3.MoveTowards(transform.position, target1.position, 0.2f * Time.deltaTime);
            anim.SetBool("turn", false);
            craftingSmoke.Stop();
            craftingSpark.Stop();
            if (transform.position == target1.position)
            {
                movingRight = false;
                movingUP = true;
            }
        }
        if (movingUP)
        {
            transform.position = Vector3.MoveTowards(transform.position, OriginalPos, 1 * Time.deltaTime);
            if (transform.position == OriginalPos)
            {
                movingUP = false;
                callback = false;
            }
        }
    }
}
