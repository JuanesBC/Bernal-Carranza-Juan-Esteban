using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{
    //El arreglo que puede ser modificado en el inspector y se le asignará de los objetos que yo destine
    public GameObject[] waypoints;
    //el Indice
    public int current = 0;
    //la velocidad a la que el personaje se mueve
    public float speed;
    //Mando a llamar el rigido del personaje
    private Rigidbody2D rigid;
    //Mando llamar el animator para poder modificarlo
    private Animator Anim;
    //con esto "paro" la animación del personaje
    public bool StopAnimation;
    //un bool para cuando deje de correr el personaje
    public bool StopRun;
    //un bool para cuando use ya sea el botón derecho o izquierdo
    public bool Derecha = false;
    public bool Izquierda = false;
    //para poder transformar el punto de fuego
    public Transform FirePoint;
    //estos vectores es donde puede disparar nuestro personaje
    Vector2 v1 = new Vector2(-2, 2.5f);
    Vector2 v2 = new Vector2(3.2f, 1.4f);
    Vector2 v3 = new Vector2(2f, -2.5f);
    Vector2 v4 = new Vector2(-3f, -1.4f);
    Vector2 v5 = new Vector2(2f, 2.5f);
    Vector2 v6 = new Vector2(1f, -3.3f);
    Vector2 v7 = new Vector2(-4f, -0.3f);
    Vector2 v8 = new Vector2(-2f, 2.5f);
    Vector2 v9 = new Vector2(-4f, 0.2f);
    Vector2 v10 = new Vector2(-3f, 1.3f);
    //y por último un bool para que el punto de fuego cambie o no
    public bool Firepointch = true;

    void Start()
    {
        //Obtengo el componente del RigidBody2D
        rigid = GetComponent<Rigidbody2D>();
        //Obtengo el componente del Animator
        Anim = GetComponent<Animator>();
        //Declaro desde el inicio que el bool "StopRun" es true;
        StopRun = true;
    }
    void Update()
    {
        //son los puntos por los cuales mi personaje pasará automaticamente hacia los siguientes puntos
        float dist = Vector3.Distance(waypoints[4].transform.position, transform.position);
        float dist2 = Vector3.Distance(waypoints[7].transform.position, transform.position);
        float dist3 = Vector3.Distance(waypoints[11].transform.position, transform.position);
        float dist4 = Vector3.Distance(waypoints[0].transform.position, transform.position);
        //Son los puntos donde se activará la booleana de Derecha
        if (waypoints[current] == waypoints[3] || waypoints[current] == waypoints[6] || waypoints[current] == waypoints[10] || waypoints[current] == waypoints[13])
        {
            Derecha = true;
        }
        //Los puntos donde se desactiva
        if (waypoints[current] == waypoints[1] || waypoints[current] == waypoints[2] || waypoints[current] == waypoints[5] || waypoints[current] == waypoints[8] || waypoints[current] == waypoints[9] || waypoints[current] == waypoints[12])
        {
            Derecha = false;
        }
        //Los puntos donde la booleana Izquierda se activa
        if (waypoints[current] == waypoints[1] || waypoints[current] == waypoints[12] || waypoints[current] == waypoints[8] || waypoints[current] == waypoints[5])
        {
            Izquierda = true;
        }
        //Donde se desactiva
        if (waypoints[current] == waypoints[13] || waypoints[current] == waypoints[10] || waypoints[current] == waypoints[9] || waypoints[current] == waypoints[6] || waypoints[current] == waypoints[3] || waypoints[current] == waypoints[2])
        {
            Izquierda = false;
        }
        //1.- Si el personjae se encuentra en la posición 1 su punto de disparo cambia
        if (waypoints[current] == waypoints[1])
        {
            Firepointch = true;
            if (waypoints[current] == waypoints[1] && Firepointch == true)
            {
                //es hacia donde rota
                FirePoint.rotation = Quaternion.Euler(0, 0, 180);
                //la posición nueva del FirePoint
                FirePoint.position = v1;
                Firepointch = false;
                StopAnimation = true;
            }
        }
        //Lo mismo que explico en el punto 1.- pero en otro lugar 
        if (waypoints[current] == waypoints[3])
        {
            Firepointch = true;
            if (waypoints[current] == waypoints[3] && Firepointch == true)
            {
                FirePoint.rotation = Quaternion.Euler(0, 0, 180);
                FirePoint.position = v5;
                Firepointch = false;
            }
        }
        //2.- Si se movio a la derecha y se encuentra en el punto que marco sucederá lo siguiente:
        if (waypoints[current] == waypoints[4] && Derecha == true)
        {
            //Cuando la distancia se iguale a 0 en el punto indicado, se moverá uno más y hará las animaciones correspondientes
            if (dist == 0)
            {
                Anim.SetBool(name: "Derecha", value: false);
                Anim.SetBool(name: "Abajo", value: true);
                current++;
            }
        }
        //Lo mismo que sucede en el punto 2.- pero si se mueve a la izquierda
        if (waypoints[current] == waypoints[4] && Izquierda == true)
        {
            if (dist == 0)
            {
                Anim.SetBool(name: "Arriba", value: false);
                Anim.SetBool(name: "Izquierda", value: true);
                current--;
            }
        }
        //Lo mismo que explico en el punto 1.- pero en otro lugar 
        if (waypoints[current] == waypoints[5])
        {
            Firepointch = true;
            if (waypoints[current] == waypoints[5] && Firepointch == true)
            {
                FirePoint.rotation = Quaternion.Euler(0, 0, 90);
                FirePoint.position = v2;
                Firepointch = false;
                StopAnimation = true;
            }
        }
        //Lo mismo que explico en el punto 2.- pero en otro lugar 
        if (waypoints[current] == waypoints[7] && Derecha == true)
        {
            if (dist2 == 0)
            {
                current++;
                Anim.SetBool(name: "Abajo", value: false);
                Anim.SetBool(name: "Izquierda", value: true);
            }
        }
        //Lo mismo que explico en el punto 2.- pero en otro lugar y desde la izq
        if (waypoints[current] == waypoints[7] && Izquierda == true)
        {
            if (dist2 == 0)
            {
                current--;
                Anim.SetBool(name: "Derecha", value: false);
                Anim.SetBool(name: "Arriba", value: true);
            }
        }
        //Lo mismo que explico en el punto 1.- pero en otro lugar 
        if (waypoints[current] == waypoints[8])
        {
            Firepointch = true;
            if (waypoints[current] == waypoints[8] && Firepointch == true)
            {
                FirePoint.rotation = Quaternion.Euler(0, 0, 0);
                FirePoint.position = v3;
                Firepointch = false;
            }
        }
        //Lo mismo que explico en el punto 2.- pero en otro lugar 
        if (waypoints[current] == waypoints[11] && Derecha == true)
        {
            if (dist3 == 0)
            {
                current++;
                Anim.SetBool(name: "Izquierda", value: false);
                Anim.SetBool(name: "Arriba", value: true);
            }
        }
        //Lo mismo que explico en el punto 2.- pero en otro lugar y desde la izq
        if (waypoints[current] == waypoints[11] && Izquierda == true)
        {
            if (dist3 == 0)
            {
                current--;
                Anim.SetBool(name: "Abajo", value: false);
                Anim.SetBool(name: "Derecha", value: true);
            }
        }
        //Lo mismo que explico en el punto 1.- pero en otro lugar 
        if (waypoints[current] == waypoints[12])
        {
            Firepointch = true;
            if (waypoints[current] == waypoints[12] && Firepointch == true)
            {
                FirePoint.rotation = Quaternion.Euler(0, 0, -90);
                FirePoint.position = v4;
                Firepointch = false;
            }
        }
        //Lo mismo que explico en el punto 2.- pero en otro lugar 
        if (waypoints[current] == waypoints[13])
        {
            Firepointch = true;
            if (waypoints[current] == waypoints[13] && Firepointch == true)
            {
                FirePoint.rotation = Quaternion.Euler(0, 0, -90);
                FirePoint.position = v10;
                Firepointch = false;
            }
        }
        //Lo mismo que explico en el punto 2.- pero en otro lugar y desde la izq
        if (waypoints[current] == waypoints[0] && Derecha == true)
        {
            if (dist4 == 0)
            {
                current++;
                Anim.SetBool(name: "Arriba", value: false);
                Anim.SetBool(name: "Derecha", value: true);
            }
        }
        //Lo mismo que explico en el punto 2.- pero en otro lugar 
        if (waypoints[current] == waypoints[0] && Izquierda == true)
        {
            if (dist4 == 0)
            {
                //Aquí hay una pequeña variable, y si sobrepasa de la longitud de el objeto al que se dirije, se mueve simplemente al siguiente
                current = waypoints.Length - 1;
                Anim.SetBool(name: "Izquierda", value: false);
                Anim.SetBool(name: "Abajo", value: true);
            }
        }
        //Si el punto en el que se encuentra respecto a la posición es diferente a la posición (osea si se mueve) StopRun es false
        if (waypoints[current].transform.position != transform.position)
        {
            StopRun = false;
            
        }
        //Si se deja de mover y está en la misma posición, StopRun es true y StopAnimation es false
        if(waypoints[current].transform.position == transform.position)
        {
            StopRun = true;
            StopAnimation = false;
        }
        //3.- Si apreta la tecla D hará lo establecido
        if (Input.GetKeyDown(KeyCode.D) && StopRun == true)
        {
            //StopAnim es true ya que se está moviendo
            StopAnimation = true;
            //En estos puntos la animación de derecha se activa y el Idle de derecha se desactiva
            if(waypoints[current] == waypoints[0] || waypoints[current] == waypoints[1] || waypoints[current] == waypoints[2] || waypoints[current] == waypoints[3])
            {

                Anim.SetBool(name: "Derecha", value: true);
                Anim.SetBool(name: "IdDer", value: false);

                
            }
            //En estos puntos la animación de abajo se activa y el Idle de Izquierda se desactiva
            if (waypoints[current] == waypoints[5] || waypoints[current] == waypoints[6])
            {

                Anim.SetBool(name: "Abajo", value: true);
                Anim.SetBool(name: "IdIzq", value: false);
            }
            //En estos puntos la animación de izquierda se activa y el Idle de arriba e izquierda se desactiva
            if (waypoints[current] == waypoints[8] || waypoints[current] == waypoints[9] || waypoints[current] == waypoints[10])
            {
                
                
                Anim.SetBool(name: "Izquierda", value: true);
                Anim.SetBool(name: "IdUp", value: false);
                Anim.SetBool(name: "IdIzq", value: false);
            }
            //Si esta en éstos puntos, sucederá lo siguiente
            if (waypoints[current] == waypoints[12] || waypoints[current] == waypoints[13])
            {
                
                //Si esta en el punto 13 cambia la posición del FirePoint, lo que sucede en el punto 1
                if (waypoints[current] == waypoints[13] && Firepointch == true)
                {
                    FirePoint.rotation = Quaternion.Euler(0, 0, 180);
                    FirePoint.position = v9;
                    Firepointch = false;
                }
                //las siguientes animaciones se activan y desactivan
                Anim.SetBool(name: "Arriba", value: true);
                Anim.SetBool(name: "IdDer", value: false);
                Anim.SetBool(name: "IdUp", value: false);
            }
            //Cuando se aprete D, el contador irá sumando para ir a los puntos elegidos
            current++;
            //Si el contador, se pasa, se vuelve cero y por lo tanto se dirige al punto 0
            if (current >= waypoints.Length)
            {
                current = 0;
            }

            
                
        }
        //Si StopAnimation es false, hace que los movimientos se detengan y de paso a los Idles
        if (StopAnimation == false)
        {
            Anim.SetBool(name: "Derecha", value: false);
            Anim.SetBool(name: "Abajo", value: false);
            Anim.SetBool(name: "Izquierda", value: false);
            Anim.SetBool(name: "Arriba", value: false);
            //Dependiendo en que punto esté, es el Idle que realiza
            if(waypoints[current] == waypoints[5] || waypoints[current] == waypoints[6])
            {
                Anim.SetBool(name: "IdIzq", value: true);
            }
            if (waypoints[current] == waypoints[8] || waypoints[current] == waypoints[9] || waypoints[current] == waypoints[10])
            {
                Anim.SetBool(name: "IdUp", value: true);
            }
            if (waypoints[current] == waypoints[12] || waypoints[current] == waypoints[13])
            {
                Anim.SetBool(name: "IdDer", value: true);
            }
        }
        //Lo mismo que pasa en el punto 3.- pero cuando apreta A
        if (Input.GetKeyDown(KeyCode.A) && StopRun == true)
        {
            StopAnimation = true;
            
            

            if (waypoints[current] == waypoints[1] || waypoints[current] == waypoints[2] || waypoints[current] == waypoints[3])
            {
                
                Anim.SetBool(name: "Izquierda", value: true);
            }
            if (waypoints[current] == waypoints[6] || waypoints[current] == waypoints[5])
            {
                
                Firepointch = true;
                if (waypoints[current] == waypoints[6] && Firepointch == true)
                {
                    FirePoint.rotation = Quaternion.Euler(0, 0, 90);
                    FirePoint.position = v5;
                    Firepointch = false;
                }
                Anim.SetBool(name: "Arriba", value: true);
                Anim.SetBool(name: "IdIzq", value: false);
            }
            if (waypoints[current] == waypoints[8] || waypoints[current] == waypoints[9] || waypoints[current] == waypoints[10])
            {
                Firepointch = true;
                if (waypoints[current] == waypoints[8] && Firepointch == true)
                {
                    FirePoint.rotation = Quaternion.Euler(0, 0, 90);
                    FirePoint.position = v6;
                    Firepointch = false;
                }
                Anim.SetBool(name: "Derecha", value: true);
                Anim.SetBool(name: "IdUp", value: false);
                Anim.SetBool(name: "IdIzq", value: false);
            }
            if (waypoints[current] == waypoints[12] || waypoints[current] == waypoints[13])
            {
                Firepointch = true;
                if (waypoints[current] == waypoints[12] && Firepointch == true)
                {
                    FirePoint.rotation = Quaternion.Euler(0, 0, 0);
                    FirePoint.position = v7;
                    Firepointch = false;
                }
                if (waypoints[current] == waypoints[13] && Firepointch == true)
                {
                    FirePoint.rotation = Quaternion.Euler(0, 0, -90);
                    FirePoint.position = v10;
                    Firepointch = false;
                }
                Anim.SetBool(name: "Abajo", value: true);
                Anim.SetBool(name: "IdDer", value: false);
                Anim.SetBool(name: "IdUp", value: false);

            }
            //en éste caso el contador está restando para que vaya de regreso a los puntos que ya ha cruzado
            current--;
            //Aquí si el contador es menor a cero, se dirigirá al punto del largo del arreglo menos 1
            if (current < 0)
            {
                current = waypoints.Length - 1;
            }
        }
        //Esto es para que el personaje se diriga a los puntos del arreglo
        transform.position = Vector2.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
    }
}
