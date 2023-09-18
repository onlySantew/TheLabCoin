using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara : MonoBehaviour
{

    public GameObject Jugador;
    Vector3 distancia;


    void Start()
    {
        distancia = transform.position - Jugador.transform.position;
    }

 
    void Update()
    {
        transform.position = Jugador.transform.position + distancia;
    }
}
