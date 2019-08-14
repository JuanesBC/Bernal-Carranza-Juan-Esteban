using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bida : MonoBehaviour
{
    //Esto instancia la imagen de la vida
    public Image health;
    //Con esto declaro la vida actual y máxima del jugador
    float hp;
    float maxHP = 100f;

    void Start()
    {
        //Simplemente doy a entender que la vida es igual al MaxHP
        hp = maxHP;
    }
    public void TakeDamage(float amount)
    {
        hp = Mathf.Clamp(hp - amount, 0f, maxHP);
        health.transform.localScale = new Vector2(hp / maxHP, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
