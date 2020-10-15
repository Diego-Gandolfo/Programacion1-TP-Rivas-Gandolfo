using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    //Quise empezar la lógica de la puerta, por alguna razón no me reconoce el playewr cuando entra en colisión,pero lo estoy viendo estos dias


    public bool hasKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !hasKey)
            Debug.Log("you need a key");
        
        else if(other.CompareTag("Player") && hasKey)
            Debug.Log("you can pass now");
             
    }
}
