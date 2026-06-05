using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraPivot : MonoBehaviour
{
    //Este script serve para rotacionar a câmera de acordo com o movimento do mouse ou do joystick!!!
    //Além disso, ele serve para fazer a câmera acompanhar o jogador!!!

    //Funcionamento:
    //Em vez de rotacionar a câmera diretamente em seu centro, este script rotaciona o objeto em que a câmera está (seu "pivot")! Se você olhar como está no editor vai entender por que fiz assim.

    //O script está: em um objeto de nome "CameraPivot", que contêm a câmera principal e a câmera do minimapa.


    float VelocidadeRotacaoCamera = 80;
    public Transform JogadorT;

    [Header("Debug")]
    public Vector2 InputCamera;

    public void CameraInput(InputAction.CallbackContext context)
    {
        InputCamera = context.ReadValue<Vector2>();
    }

    void Update()
    {
        if (JogadorT)
        {
            transform.position = Vector3.Lerp(transform.position, JogadorT.position, Time.deltaTime * 3);
        }

        transform.Rotate(0, InputCamera.x * VelocidadeRotacaoCamera * Time.deltaTime, 0);
    }
}
