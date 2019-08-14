using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    //Es la velocidad que puede ser modificada en el inspector del Unity
    public float speed;
    //Es el target al que el enemigo se moverá
    private Transform target;
    //La vida del enemigo
    public int health = 10;
    //Si así quisiera, podría meterle un efecto de muerte al personaje
    //public GameObject deatheffect;
    //Mando a llamar la barra de vida a la que afectará este código
    public Healthbar Vidacofre;

    public void TakeDamage (int damage)
    {
        //si recibe daño, se le restará a éste personaje
        health -= damage;
        //si la vida es menor o igual a cero el objeto es destruido
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //Se le asigna al valor de target donde es el lugar al que se dirige
        target = GameObject.FindGameObjectWithTag("ITEM").GetComponent<Transform>();        //También se busca el objeto Healthbar al que irá afectando        Vidacofre = FindObjectOfType<Healthbar>();
    }

    void Update()
    {
        //Si el objeto al que se mueve mi enemigo, su posición es mayor a ésta, se seguirá moviendo
        if(Vector2.Distance(transform.position, target.position) > 0.5)
        {
            //es la dirección a la que se dirigirá mi enemigo
            Vector2 v2 = new Vector2(target.position.x, transform.position.y);
            Vector2 v3 = new Vector2(target.position.y, transform.position.x);
            //con este código mi enemigo se moverá hacia la ubicación especificada, que en este caso es donde está el cofre
            transform.position = Vector2.MoveTowards(transform.position, v2, speed * Time.deltaTime);
            transform.position = Vector2.MoveTowards(transform.position, v3, speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //al entrar en contacto con el objeto que tenga Tag de "Item", el cofre recibirá Daño
        if (other.gameObject.tag =="ITEM")
        {
            Vidacofre.SendMessage("TakeDamage", 10);
        }
        
    }
}
