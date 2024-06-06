using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class erase_respaw : MonoBehaviour
{

    public GameObject eraserespaw;
    public GameObject buttonfinish;


     private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
        eraserespaw.SetActive(false);
        buttonfinish.SetActive(true);
        }
        
    }
}
