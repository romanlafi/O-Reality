using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panel : MonoBehaviour
{

    public GameObject luz;
    public GameObject cameraPanel;
    // Start is called before the first frame update
    void Start()
    {
        luz.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {   
        if (cameraPanel.activeSelf)
        {
        if (Input.GetKeyDown(KeyCode.L))
        {   
            if (luz.activeSelf)
            {
                luz.SetActive(false);
            } else {
                luz.SetActive(true);
            }
            
        }
        }
    }
}
