using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly_control : MonoBehaviour
{

    public Material[] materiales;
    public float[] alphas;
    public Color[] emission;
    public float velocidad,velocidadImpulso,velocidadFrenado;
    public float tiempofrenado, tiempoImpulso;
    float sigTiempo;
    bool enImpulso;
    public Rigidbody rigid;
    // Use this for initialization
	void Start ()
    {
        sigTiempo = tiempofrenado;
        //enImpulso = true;
        for (int i = 0; i < materiales.Length; i++)
        {
            alphas[i] = materiales[i].color.a;
            emission[i] = materiales[i].GetColor("_EmissionColor");
            Color tempAlfa = materiales[i].color;
            tempAlfa.a = 0.0f;
            materiales[i].color = tempAlfa;
            materiales[i].SetColor("_EmissionColor", Color.black);
            

        }
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {  

        if(velocidad > velocidadFrenado && !enImpulso)
        {
            velocidad -= 0.02f;
            if(velocidad <= velocidadFrenado)
            {
                enImpulso = true;
            }
        }
        if(velocidad < velocidadImpulso && enImpulso)
        {
            velocidad += 0.1f;
            if(velocidad >= velocidadImpulso)
            {
                enImpulso = false;
            }
        }
        transform.Translate(Vector3.up *(Time.deltaTime * velocidad));
        
	}
    public void Aparecer()
    {

    }
}
