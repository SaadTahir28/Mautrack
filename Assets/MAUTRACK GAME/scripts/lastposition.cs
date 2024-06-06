using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lastposition : MonoBehaviour
{

public GameObject lastrespaw;
public GameObject newrespaw;
public GameObject first_ground_respaw;
public GameObject last_ground_respaw;
public GameObject new_ground_respaw;
public GameObject otro_necesario;
private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false; 
    }
    
    
     private void OnTriggerEnter(Collider other)
    {
    	if (other.gameObject.tag == "Player")
        {
        	// Debug.Log("lastpositionlastpositionlastposition" );
            first_ground_respaw.SetActive(false);
        	lastrespaw.SetActive(false);
        	newrespaw.SetActive(true);
			last_ground_respaw.SetActive(false);
            //Debug.Log("¡Colisión detectada!1");
        	new_ground_respaw.SetActive(true);
            //Debug.Log("¡Colisión detectada!2");

        	//otro_necesario.SetActive(false);
        }
        
    }	
}
