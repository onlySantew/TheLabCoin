using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlJugador : MonoBehaviour
{

    public float velocidad = 10;
    public Text textoCoins;
    public Text textoWin;

    int monedas = 0;

    Rigidbody miRigidbody;
    Vector3 posicionInicial;
    bool hasWon;
    void Start()
    {
        miRigidbody = GetComponent<Rigidbody>();
        posicionInicial = transform.position;
        textoWin.enabled = false;
        hasWon = false;
    }


    void Update()
    {
        if (!hasWon)
        {


            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");

            miRigidbody.AddForce(new Vector3(horizontal, 0, vertical) * velocidad);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            hasWon = true;
            textoWin.enabled = true;
            miRigidbody.velocity = Vector3.zero;
            miRigidbody.angularVelocity = Vector3.zero;
        }
        else if (other.CompareTag("Enemy"))
        {
            miRigidbody.MovePosition(posicionInicial);
            miRigidbody.velocity = Vector3.zero;
            miRigidbody.angularVelocity = Vector3.zero;
            textoCoins.text = "COINS: 0";
        }
        else if (other.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            monedas++;
            textoCoins.text = "COINS:" + monedas;
        }
    }
}
