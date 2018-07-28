using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly_control : MonoBehaviour
{

    
    public float velocidad,velocidadImpulso,velocidadFrenado;
    public float tiempofrenado, tiempoImpulso;
    float sigTiempo;
    bool enImpulso;
    public Rigidbody rigid;
    public Animator anim;
    // Use this for initialization
	void Start ()
    {
        sigTiempo = tiempofrenado;
        //enImpulso = true;
        anim.speed = Random.Range(0.5f, 1.2f);
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
  
}
