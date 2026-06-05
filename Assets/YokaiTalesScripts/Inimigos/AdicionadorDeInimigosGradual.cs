using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdicionadorDeInimigosGradual : MonoBehaviour
{
    //Este script faz o que o nome sugere!!!

    public GameObject[] Inimigos;
    int InimigoAtual;
    float Timer;

    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer > 0.3f)
        {
            if (InimigoAtual < Inimigos.Length)
            {
                Inimigos[InimigoAtual].SetActive(true);
                InimigoAtual++;

                Timer = 0;
            }
        }
    }
}
