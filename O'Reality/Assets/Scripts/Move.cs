using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Transform doorPosition;
    public Transform targetPosition;
    public Transform referencia;
    public float speed =0.5f;
    public AudioSource doorAudio;

    public GameObject luzInterior;
    public GameObject luzExterior;
    bool click = false;
  

    // bool opening;
    // bool closing;


    // Start is called before the first frame update
    void Start()
    {    
         
         luzInterior.SetActive(true);
         luzExterior.SetActive(true);
      

    }

    public void clickMe(){
        doorAudio.Play();
        if(click == false){
          
            click =true;
        }else{
           
            click = false;
        }
    }

    void Update()
    {
        if(click){

             luzInterior.SetActive(false);
             luzExterior.SetActive(false);
             move(doorPosition.position, targetPosition.position);             
        
        }
        if(!click){
           
             move(doorPosition.position, referencia.position);
             
             if (Vector3.Distance(doorPosition.position, targetPosition.position) < 0.01f){
        

                luzInterior.SetActive(true);
                luzExterior.SetActive(true);
              
                 //LeftC.transform.Rotate(0,40,0);
 
    
            
        }
        
    }
    }

    void move(Vector3 pos, Vector3 target){
        doorPosition.position = Vector3.MoveTowards(pos, target,speed * Time.deltaTime);
    }
 
}