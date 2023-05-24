using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLauncher : MonoBehaviour
{
    public string sceneName; // Nombre de la escena a cargar

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName); // Carga la escena con el nombre especificado
    }
}
