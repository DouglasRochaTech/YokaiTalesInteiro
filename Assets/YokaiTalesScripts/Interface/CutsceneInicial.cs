using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CutsceneInicial : MonoBehaviour
{
    public void OnJump(InputAction.CallbackContext context)
    {
        JumpInput(context);
    }

    public void JumpInput(InputAction.CallbackContext context) //SELECIONAR
    {
        Debug.Log("Input recebido: " + context.phase);

        if (context.performed)
        {
            SceneManager.LoadScene(1);
            Debug.Log("Carregando Cena...");
        }
    }    
}
