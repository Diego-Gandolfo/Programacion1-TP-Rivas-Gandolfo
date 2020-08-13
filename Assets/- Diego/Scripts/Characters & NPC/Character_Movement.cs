using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour
{
    // Variables de Movimiento
    public float movementSpeed = 7;
    public float runMultiplier = 3;

    private void Update()
    {
        // Movimiento
        float speedMovVer = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftShift)) speedMovVer *= runMultiplier;

        float speedMovHor = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftShift)) speedMovHor *= runMultiplier;

        transform.Translate(0, speedMovVer, 0);
        transform.Translate(speedMovHor, 0, 0);
    }
}
