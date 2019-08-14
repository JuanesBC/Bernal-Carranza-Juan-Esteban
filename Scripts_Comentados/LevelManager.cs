using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //Con el levelmanager, hago que puedan cargar escenas dependiendo las acciones o texto que haya elegido para que lo hagan
    public void StartGame()
    {
        //te lleva a las instrucciones
        SceneManager.LoadScene("Instrucciones");
    }
    public void Nivel()
    {
        //te lleva al nivel
        SceneManager.LoadScene("Link");
    }
    public void QuitGame()
    {
        //Quita el juego
        Application.Quit();
    }
}
