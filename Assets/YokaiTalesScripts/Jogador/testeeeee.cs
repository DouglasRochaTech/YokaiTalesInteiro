using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class testeeeee : MonoBehaviour
{
    public float velocidade = 1;
    public float gravidade = 9.8f;
    public float velocidadeVertical;

    public Vector2 inputMover;

    CharacterController Controlador;

    void Start()
    {
        Controlador = GetComponent<CharacterController>();
    }

    public void MoveInput(InputAction.CallbackContext context)
    {
        inputMover = context.ReadValue<Vector2>();
    }

    void Update()
    {/*
        if (inputMover.y > 0)
        {
            Controlador.Move(Vector3.forward * velocidade * Time.deltaTime);            
        }

        if (inputMover.y < 0)
        {
            Controlador.Move(-Vector3.forward * velocidade * Time.deltaTime);
        }

        if (inputMover.x < 0)
        {
            Controlador.Move(-Vector3.right * velocidade * Time.deltaTime);
        }

        if (inputMover.x > 0)
        {
            Controlador.Move(Vector3.right * velocidade * Time.deltaTime);
        }*/

        Controlador.Move(new Vector3(inputMover.x, 0, inputMover.y) * velocidade * Time.deltaTime);

        

        if (Controlador.isGrounded)
        {
            velocidadeVertical = 0;
        }
        else
        {
            velocidadeVertical += gravidade * Time.deltaTime;
        }

        Controlador.Move(-Vector3.up * velocidadeVertical * Time.deltaTime);
    }
}
