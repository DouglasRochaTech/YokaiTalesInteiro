using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    //Este script serve para detectar se o fox está no chão ou não, e em que tipo de chão ele está (grama ou piso sólido)
    //para usar sons de passo em grama ou sons de passo em piso sólido dependendo de onde o jogador está andando

    //O script está: em um objeto chamado "Detector", que está como "child" do Jogador
    //O script do Jogador acessa este script que está no objeto "Detector"!

    public Jogador JogadorScript;
    public bool NoChao;
    public bool NaGrama;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Chao" || other.gameObject.tag == "Grama")
        {
            NoChao = true;
            JogadorScript.FoxAnimator.SetBool("Pulando", false);
        }

        if (other.gameObject.tag == "Grama")
        {
            NaGrama = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Chao" || other.gameObject.tag == "Grama")
        {
            NoChao = false;
            NaGrama = false;
        }
    }
}
