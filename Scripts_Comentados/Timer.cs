using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    //Para la cuenta atrás, se declara el tiempo actual
    float TiempoActual = 0f;
    //Y el tiempo inicial
    float TiempoInicial = 30f;
    //Es el texto al que será asignado este countdown
    [SerializeField] Text Countdown;
    private void Start()
    {
        //Simplemente se declara que el tiempo Actual es igual al inicial
        TiempoActual = TiempoInicial;
    }
    void Update()
    {
        //al tiempo actual se le irá restando de un segundo en un segundo
        TiempoActual -= 1 * Time.deltaTime;
        //Con esto se mostrará en el texto seleccionado el tiempo restante, el "0" es para declarar que solo quiero numeros enteros
        Countdown.text = TiempoActual.ToString ("0");
        //Este condicionante es para parar el tiempo, si llega a cero, se queda en cero
        if(TiempoActual <= 0)
        {
            TiempoActual = 0;
        }
        //Con esta condicionante mando a llamar la escena de victoria, dando a entender al jugador que lo logró
        if(TiempoActual == 0)
        {
            SceneManager.LoadScene("Victoria");
        }
    }
}
