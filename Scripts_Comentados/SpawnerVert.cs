using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerVert : MonoBehaviour
{
    //La diferencia entre éste Spawner y los otros, es que este es puesto para los enemigos que aparecen en el eje de Y
    public GameObject enemy;
    float randY;
    Vector2 wheretoSpawn;
    public float Spawnrate = 2f;
    float nextSpawn = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + Spawnrate;
            // Esta es simplemente la cuestión que cambia
            randY = Random.Range(-2.5f, 2.5f);
            wheretoSpawn = new Vector2(transform.position.x, randY);
            Instantiate(enemy, wheretoSpawn,Quaternion.identity);
        }
    }
}
