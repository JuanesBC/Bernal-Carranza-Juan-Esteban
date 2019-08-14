using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Healthbar : MonoBehaviour
{
    //La vida inicial del cofre
    public float starthealth = 100;
    private float health;
    //Imagen de la barra de vida
    public Image HealthBar;
    void Start()
    {
        //declaro que la vida es igual a la vida inicial del cofre
        health = starthealth;
    }
    public void TakeDamage (float amount)
    {
        //a la vida se le restará la cantidad del float asignado
        health -= amount;
        //con este codigo hago que cuando se baje vida, la barra de vida que se ve en el juego también baje
        HealthBar.fillAmount = health / starthealth;
        //si la vida es menor o igual a 0, el objeto es destruido y lo manda a la siguiente escena
        if(health<=0)
        {
            Die();
            //se carga la escena de Game Over
            SceneManager.LoadScene("GameOver");
        }
    }
    void Die()
    {
        //El objeto es destruido
        Destroy(gameObject);
    }
    void Update()
    {
        
    }
}
