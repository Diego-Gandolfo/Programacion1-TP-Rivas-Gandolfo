using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerAutoDestruccion : MonoBehaviour
{
    public float tiempoParaAutoDestruccion = 600;

    private float contador;

    private void Start()
    {
        contador = tiempoParaAutoDestruccion;
    }

    private void Update()
    {
        if (contador > 0)
        {
            contador -= Time.deltaTime;
        }
        else if (contador <= 0)
        {
            Destroy(gameObject);
        }
    }
}
