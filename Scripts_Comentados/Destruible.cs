using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruible : MonoBehaviour
{
    public void Eliminar()
    {
        Destroy(gameObject);
    }
}
