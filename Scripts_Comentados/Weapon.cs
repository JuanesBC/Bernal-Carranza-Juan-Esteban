using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //Con este arreglo haré el cambio entre armas
    public GameObject[] CambioArma;
    //El índice
    public int index = 0;
    //Es el punto de fuego instanciado
    public Transform FirePoint;
    //Con esto puedo poner el prefab de la bala
    public GameObject BulletPrefab;
    //Y con este el de la bomba
    public GameObject BombPrefab;
    //Con éste bool hago que no puedas spamear más de una bomba a la vez, pero lo mando llamar desde otro código
    public static bool Bombaactiva = false;

    void Update()
    {
        //Si apreto E, se realiza el cambio de arma
        if(Input.GetKeyDown(KeyCode.E))
        {
            //Dependiendo si el index es 0 o 1, es una arma u otra
            index++;
            //Si el index llega a más del largo del Arreglo, se regresa a cero
            if (index >= CambioArma.Length)
            {
                index = 0;
            }
        }
        //Con estas condicionantes es para que dependiendo del arreglo, haga un disparo u otro
        if (Input.GetButtonDown("Fire1") && CambioArma[index] == CambioArma[0])
        {
            Shoot();
        }
        if (Input.GetButtonDown("Fire1") && CambioArma[index] == CambioArma[1])
        {
            //Si el bool es falso, puedo disparar la bomba
            if(Bombaactiva== false)
            {
                Shoot2();
            }
        }
    }
    void Shoot()
    {
        //Con esto instancio la bala que el personaje puede disparar
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
    }
    void Shoot2()
    {
        //Y con éste la bomba
        Instantiate(BombPrefab, FirePoint.position, FirePoint.rotation);
        //pero con haciendo este true, no se puede instanciar la bomba hasta que se declare false
        Bombaactiva = true;
    }
}
