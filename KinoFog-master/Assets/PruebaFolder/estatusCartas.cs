using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class estatusCartas : MonoBehaviour
{
    public static estatusCartas _estatusCartas;
    // Use this for initialization
    public bool enJugador;
    public bool enMovimiento;
	void Start ()
    {
        _estatusCartas = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
