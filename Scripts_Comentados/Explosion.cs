using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    //Debido a que el objeto se al contacto y no se puede apreciar la animación de la exlosión, le meti el mismo efecto
    public GameObject EfectoExplosion;
    // Start is called before the first frame update
    void Start()
    {
        //el bool del código weapon para que no pueda activar otra bomba hasta que ésta explote
        Weapon.Bombaactiva = false;
    }
    //Al igual que la bala, todo lo que entre en contacto con el collider de la explosión hará que regrese info.
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Instancío el efecto de la explosión
        Instantiate(EfectoExplosion, transform.position, transform.rotation);
        //Si entra en contacto con los enemigos, se les causa daño
        Knight knight = hitInfo.GetComponent<Knight>();
        if (knight != null)
        {
            knight.TakeDamage(10);
        }
        //hace que se destruya el objeto

        Destroy(gameObject);
    }
}
