//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleRotationScript : MonoBehaviour
{
    public Camera camaraPrincipal; // Arrastra la cámara principal al inspector
    public Camera camaraSecundaria; // Arrastra la cámara secundaria al inspector

    void Start()
    {
            //camaraPrincipal.enabled = true;
            //camaraSecundaria.enabled = false; 
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Plataform") {
           this.transform.parent = col.gameObject.transform;
           //print("TriggerEnter mauricito");
            //camaraPrincipal.enabled = false;
           // camaraSecundaria.enabled = true;
         
       }


}
void OnTriggerExit(Collider col)
{
        if (col.gameObject.tag == "Plataform")
        {
            this.transform.parent = null;
             //print("TriggerExit salidita");
            camaraPrincipal.enabled = true;
            camaraSecundaria.enabled = false;
            
        }

    }
}


