using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaEnPantalla : MonoBehaviour
{
    //Arreglo que sirve para que vaya cambiando de animación
    public GameObject[] cambio;
    //índice
    public int index = 0;
    //Animator que mostrará el arma que usa el jugador
    public Animator anim;
    void Start()
    {
    }

    void Update()
    {
        //Cada que se aprete la tecla E, el index irá sumando el contador
        if (Input.GetKeyDown(KeyCode.E))
        {
            index++;
            //Con este If, cada que el index esté al final del largo del contador, lo regresa a 0...
            //Pero tambien le agregué la animación para cuando ocurra ésto, salga la siguiente animación al otra arma
            if (index >= cambio.Length)
            {
                anim.SetBool(name: "Cambio2", value: true);
                anim.SetBool(name: "Cambio1", value: false);
                anim.SetBool(name: "Cambio3", value: false);
                index = 0;
            }
        }
        //Si el index está en la posición indicada, hace la animación correspondiente y desactiva las demás animaciones
        if(cambio[index] == cambio[1])
        {
            anim.SetBool(name: "Cambio1", value: true);
            anim.SetBool(name: "Cambio2", value: false);
            anim.SetBool(name: "Cambio3", value: true);
        }
    }
}
