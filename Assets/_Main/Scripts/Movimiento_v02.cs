using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_v02 : MonoBehaviour
{
    // Variables de Movimiento y Rotacion
    public float velocidadMovimiento = 7;
    public float velocidadRotacion = 200;
    public float modificadorCorrer = 3;

    // Variables de Salto
    private Rigidbody myRigidbody;
    public float potenciaSalto = 1;
    private bool canJump = true;

    private void Start()
    {
        myRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Movimiento
        float velMovVer = Input.GetAxis("Vertical") * velocidadMovimiento * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftShift)) velMovVer *= modificadorCorrer;

        float velMovHor = Input.GetAxis("Horizontal") * velocidadMovimiento * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftShift)) velMovHor *= modificadorCorrer;

        transform.Translate(0, 0, velMovVer);
        transform.Translate(velMovHor, 0, 0);

        // Rotacion
        float velRot = Input.GetAxis("Mouse X") * velocidadRotacion * Time.deltaTime;
        transform.Rotate(0, velRot, 0);

        // Salto
        float potSal = Input.GetAxis("Jump") * potenciaSalto;
        if (canJump) myRigidbody.AddForce(0, potSal, 0, ForceMode.Impulse);
    }

    private void OnCollisionStay(Collision objetoColisionado)
    {
        if (objetoColisionado.gameObject.tag == "Piso") canJump = true;
    }

    private void OnCollisionExit(Collision objetoColisionado)
    {
        if (objetoColisionado.gameObject.tag == "Piso") canJump = false;
    }
}
