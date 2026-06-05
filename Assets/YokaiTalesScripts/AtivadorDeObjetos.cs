using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivadorDeObjetos : MonoBehaviour
{
    //Este script serve para ativar objetos se o fox entrar em uma zona específica (um colisor)!!!
    //Exemplo: o fox chegou em um lugar, este script detecta o fox em seu colisor, e ativa o objeto dos inimigos.
    
    //COMO USAR: 
    // 1 - bote este script em um objeto; 
    // 2 - adicione um colisor a este objeto; 
    // 3 - no editor, escolha que objeto(s) deseja ativar e que objeto(s) deseja desativar.

    public GameObject[] ObjetosParaAtivar;
    public GameObject[] ObjetosParaDesativar;

    private void OnTriggerEnter(Collider other)
    {
        if (!ObjetosParaAtivar[0].activeSelf)
        {
            if (other.gameObject.tag == "Player")
            {
                foreach (GameObject ObjetoParaAtivar in ObjetosParaAtivar)
                {
                    ObjetoParaAtivar.SetActive(true);
                }

                foreach (GameObject ObjetoParaDesativar in ObjetosParaDesativar)
                {
                    ObjetoParaDesativar.SetActive(true);
                }
            }
        }
    }
}
