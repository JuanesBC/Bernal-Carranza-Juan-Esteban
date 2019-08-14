using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //La velocidad que tendrá la bala
    public float speed = 10f;
    //Para que funcione mando llamar el rigido de la bala
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        //Es la trayectoria que tomará la bala en base a la velocidad dada
        rb.velocity = transform.up * speed;
    }
    //Al hacer trigger en un collider2D regresa información
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Si el componente al que colisiona es "Knight" Se hará daño a la vida de éste
        Knight knight = hitInfo.GetComponent<Knight>();
        if (knight != null)
        {
            knight.TakeDamage(10);
        }
        //Con este codigo hago que no con todo lo que toque la bala se destruya, solo lo que esté con los tags que no eliga
        if (hitInfo.gameObject.tag == "ITEM")
        {
            Destroy(gameObject);
        }
        if (hitInfo.gameObject.tag =="Enemy")
        {
            Destroy(gameObject);
        }
        if (hitInfo.gameObject.tag == "Mapa")
        {
            Destroy(gameObject);
        }
    }
}
