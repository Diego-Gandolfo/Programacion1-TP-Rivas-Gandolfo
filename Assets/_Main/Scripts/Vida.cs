using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public float vidaMaxima = 100;
    public float vidaActual;

    private void Start()
    {
        vidaActual = vidaMaxima;
    }

    private void Update()
    {
        if (vidaActual <= 0) Destroy(gameObject);
    }

    public void perderVida(float vidaPerdida)
    {
        vidaActual -= vidaPerdida;
    }
}
