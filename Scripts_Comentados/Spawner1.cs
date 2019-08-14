using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner1 : MonoBehaviour
{
    //Éste código es similar al código de Spawner, solo que puesto en otro lugar.
    public GameObject enemy;
    float randX;
    Vector2 wheretoSpawn;
    public float Spawnrate = 2f;
    float nextSpawn = 8f;
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
            randX = Random.Range(-2.5f, 2.5f);
            wheretoSpawn = new Vector2(randX, transform.position.y);
            Instantiate(enemy, wheretoSpawn,Quaternion.identity);
        }
    }
}
