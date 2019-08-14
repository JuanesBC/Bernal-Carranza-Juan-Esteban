using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //Con este public GameObject puedo poner al enemigo que a ser instanciado
    public GameObject enemy;
    //Es el espacio random en el eje X en el que va a ser instanciado el objeto
    float randX;
    //El vector en el que spawneara el enemigo
    Vector2 wheretoSpawn;
    //Es el ratio o digamos al tiempo que demora en spawnear el enemigo, puede ser modificado también
    public float Spawnrate = 2f;
    //Es el tiempo en que spawneará el siguiente Enemigo
    float nextSpawn = 0.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Si el tiempo es menor al siguiente spawn, hará lo siguiente
        if (Time.time > nextSpawn)
        {
            //El siguiente spawn es igual al tiempo mas el tiempo del SpawnRate
            nextSpawn = Time.time + Spawnrate;
            //Se le asigna el rango de X que es un random entre las distancias que yo asigne
            randX = Random.Range(-2.5f, 2.5f);
            //En base a randx y la posición de Y spawnearán los enemigos
            wheretoSpawn = new Vector2(randX, transform.position.y);
            //Y finalmente con éste codigo se instancian los monstruos en el lugar random que le haya sido declarado
            Instantiate(enemy, wheretoSpawn,Quaternion.identity);
        }
    }
}
