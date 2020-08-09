using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoContinuo : MonoBehaviour
{
    public Vector3 velocidadMovimiento;

    void Update()
    {
        Vector3 velMov = velocidadMovimiento * Time.deltaTime;

        transform.Translate(velMov);
    }
}
