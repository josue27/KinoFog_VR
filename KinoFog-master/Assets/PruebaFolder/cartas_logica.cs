using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cartaControl : MonoBehaviour
{
    public bool tipo_roja, tipo_azul, tipo_verde;
    public Transform _jugadorPos, _mesaPos;
    public float velocidad;
    public BoxCollider collider;
    public estatusCarta _estatusCarta;
    // Use this for initialization
    bool aJugador, aMesa;
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
      /*  if (!estatusCarta._estatusCarta.enMovimiento)
        {


            if (Input.GetKeyDown(KeyCode.D) && tipo_roja)
            {
                print("Roja presionada");
                if (!estatusCarta._estatusCarta.enJugador)
                    CartaSeleccionada();
                else if (estatusCarta._estatusCarta.enJugador)
                    CartaRetirada();

            }
            if (Input.GetKey(KeyCode.A) && tipo_azul)
            {
                print("Azul presionada");
                CartaSeleccionada();
            }
            if (Input.GetKey(KeyCode.S) && tipo_verde)
            {
                print("Verde presionada");
                CartaSeleccionada();
            }


        }*/

        MoverCarta();
        RegresarCarta();
    }
    void OnTriggerEnter(Collider coll)
    {
        print("Ento objeto");
        if (!_estatusCarta.enJugador)
        {
            CartaSeleccionada();
        }
        else if (aJugador)
        {
            CartaRetirada();
        }
        
    }

    public void CartaSeleccionada()
    {
        _estatusCarta.enJugador = true;
        collider.enabled = false;
        aJugador = true;
    }
    public void CartaRetirada()
    {
        aJugador = false;
        collider.enabled = false;
        aMesa = true;
    }
    
    public void MoverCarta()
    {
        if (aJugador)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, _jugadorPos.transform.position, Time.deltaTime * velocidad);
            if(this.transform.position == _jugadorPos.transform.position)
            {
                _estatusCarta.enMovimiento = false;
                _estatusCarta.enJugador = true;
                collider.enabled = true;
                print(transform.name + " esta en Jugador");
            }
        }
    }
    public void RegresarCarta()
    {
        if(aMesa)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, _mesaPos.transform.position, Time.deltaTime * velocidad);
            if (this.transform.position == _mesaPos.transform.position)
            {
                _estatusCarta.enJugador = false;
                aMesa = false;
                collider.enabled = true;
                print(transform.name + " llego a mesa");
            }

        }
    }
}