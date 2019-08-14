using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    //Mando llamar el cuerpo rígido de la bomba
    public Rigidbody2D rb;
    //Le doy una velocidad a la que se moverá el objeto
    public float speed = 5f;
    //El tiempo que le toma a la bomba en explotar
    public float delay = 2f;
    float countdown;
    //bool para el delay de la explosión
    bool exploto = false;
    //Le añadi un efecto de exploción que será puesto cuando el objeto se detruya
    public GameObject EfectoExplosion;
    void Start()
    {
        //Hago que el contador sea igual al delay
        countdown = delay;
        //El recorrido que hará en base a la velocidad dada
        rb.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        //Al elemento countdown se le va restando el tiempo
        countdown -= Time.deltaTime;
        //Si el countdown es menor o igual a 0 y explotó no es igual a true, entonces hace la explosión
        if (countdown <= 0f && !exploto)
        {
            Explode();
            //esto es para que no se pueda volver a explotar
            exploto = true;
        }
    }

    void Explode()
    {
        //Con esto mandamos llamar al efecto de la explosión que será otro prefab
        Instantiate(EfectoExplosion, transform.position, transform.rotation);
        //Se destruye el objeto de la bomba
        Destroy(gameObject);
    }
}
