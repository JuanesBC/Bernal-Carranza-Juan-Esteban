using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eliminarbomba : MonoBehaviour
{
    //Éste código está hecho para la siguiente funcion:
    void Start()
    {
        //La primera es para eliminar después de un segundo la explosión creada a partir de la bomba
        Destroy(gameObject, 1f);
    }

    void Update()
    {
        
    }
}
