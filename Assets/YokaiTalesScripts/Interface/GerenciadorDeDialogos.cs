using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GerenciadorDeDialogos : MonoBehaviour
{
    //Este script faz o que o nome sugere! 
    //Quando o jogador aperta o botão de pular e se o objeto com este script estiver ativo, este script checa todos os objetos que têm o script "Dialogo.cs"

    public CaixaDeDialogo[] CaixasDeDialogo;
    public GameObject CaixaDialogoFox;
    public GameObject CaixaDialogoCristal;
    public bool PodeContinuar;

    public void JumpInput(InputAction.CallbackContext context)
    {
        if (CaixaDialogoFox.activeSelf || CaixaDialogoCristal.activeSelf)
        {
            if (context.performed)
            {
                PodeContinuar = true; Debug.Log("(CaixaDialogoFox.activeSelf || CaixaDialogoCristal.activeSelf)");

                foreach (CaixaDeDialogo Dialogo in CaixasDeDialogo)
                {
                    Dialogo.Proximo();
                }
            }
        }
    }
}
