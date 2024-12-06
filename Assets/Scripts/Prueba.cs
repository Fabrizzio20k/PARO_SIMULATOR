using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prueba : MonoBehaviour
{
    void Start()
    {
        Debug.LogWarning("Hola Mundo");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoToInit()
    {
        SceneManager.LoadScene("Inicio");
    }

    public void ChangeScene(){
        SceneManager.LoadScene("PrevStart");
    }

        public void RealStart(){
        SceneManager.LoadScene("Street");
    }

    public void Salir(){
        Application.Quit();

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

}
