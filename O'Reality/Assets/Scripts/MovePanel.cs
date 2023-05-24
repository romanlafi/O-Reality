using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePanel : MonoBehaviour
{
    Animator animator;
   
    void Start()
    {
         animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {    
       
         //
         if(Input.GetKey(KeyCode.Mouse0)){
             animator.SetBool("moveRight", true);
         }
         else if (Input.GetKeyUp(KeyCode.Mouse0)){
             animator.SetBool("moveRight", false);
         }


       
        if (Input.GetKey(KeyCode.Mouse1)){
             animator.SetBool("moveLeft", true);

         }else if (Input.GetKeyUp(KeyCode.Mouse1)){
             animator.SetBool("moveLeft", false);
         }
    }

    // private void OnMouseDrag() {
    //     float YaxisRotation = Input.GetAxis("Mouse X") * speed;
    //     Debug.Log(YaxisRotation);
    // }
}
