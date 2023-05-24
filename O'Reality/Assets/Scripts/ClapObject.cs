using UnityEngine;

public class ClapObject : MonoBehaviour
{
    // The object that will be clapped onto
    public GameObject clapTarget;
    public GameObject firstFather;
    public  Transform targetPosition;
 
    private void OnTriggerEnter(Collider other)
    {
        // Check if the other object is the clap target
        if (other.gameObject == clapTarget)
        
            transform.position = targetPosition.position;
            transform.rotation = targetPosition.rotation;
           
           
        }
  
}
