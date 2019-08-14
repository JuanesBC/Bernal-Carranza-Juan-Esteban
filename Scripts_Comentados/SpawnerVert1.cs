using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerVert1 : MonoBehaviour
{
    //Es lo mismo que el Spawner vertical pero desde otra posición
    public GameObject enemy;
    float randY;
    Vector2 wheretoSpawn;
    public float Spawnrate = 2f;
    float nextSpawn = 10f;

    void Start()
    {
        
    }


    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + Spawnrate;
            randY = Random.Range(-2.5f, 2.5f);
            wheretoSpawn = new Vector2(transform.position.x, randY);
            Instantiate(enemy, wheretoSpawn,Quaternion.identity);
        }
    }
}
