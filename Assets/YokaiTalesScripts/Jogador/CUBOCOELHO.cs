using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CUBOCOELHO : MonoBehaviour
{
    public float velocidade = 5;
    public CharacterController ControladorCoelho;
    public Vector2 InputMover;
    
    public void Mover(InputAction.CallbackContext context)
    {
        InputMover = context.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        ControladorCoelho.Move(new Vector3(InputMover.x, 0, InputMover.y) * velocidade * Time.deltaTime);
    }
}
