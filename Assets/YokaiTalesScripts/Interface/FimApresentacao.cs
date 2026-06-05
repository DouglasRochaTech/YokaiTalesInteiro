using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class FimApresentacao : MonoBehaviour
{
    //Este script gerencia as animações de interface do fim da apresentação!

    public GameObject[] ObjetosParaAtivar;
    public GameObject[] ObjetosParaDesativar;

    public Jogador ScriptDoJogador;
    public AudioSource AmbienteAudioSource;
    public AudioSource MusicAudioSource;

    public Image ImagemPreta;
    public Text TextoPrincipal;
    public Text TextoMenor;

    public Color Visivel;
    public Color Invisivel;
    public Color VisivelTexto;
    public Color InvisivelTexto;
    float Visibilidade;

    public void JumpInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (Visibilidade > 1)
            {
                if (!ObjetosParaAtivar[0].activeSelf)
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

    void Start()
    {/*
        foreach (GameObject ObjetoParaAtivar in ObjetosParaAtivar)
        {
            ObjetoParaAtivar.SetActive(true);
        }

        foreach (GameObject ObjetoParaDesativar in ObjetosParaDesativar)
        {
            ObjetoParaDesativar.SetActive(true);
        }*/

        ImagemPreta.color = Color.Lerp(Invisivel, Visivel, 0);
        TextoPrincipal.color = Color.Lerp(InvisivelTexto, VisivelTexto, 0);
        TextoMenor.color = Color.Lerp(InvisivelTexto, VisivelTexto, 0);

        Time.timeScale = 0;
        ScriptDoJogador.enabled = false;
    }

    void Update()
    {
        Visibilidade += Time.unscaledDeltaTime * 0.5f;

        ImagemPreta.color = Color.Lerp(Invisivel, Visivel, Visibilidade);
        TextoPrincipal.color = Color.Lerp(InvisivelTexto, VisivelTexto, Visibilidade * 1.2f);
        TextoMenor.color = Color.Lerp(InvisivelTexto, VisivelTexto, (Visibilidade - 1));

        AmbienteAudioSource.volume -= Time.unscaledDeltaTime * 2;
        MusicAudioSource.volume    -= Time.unscaledDeltaTime * 0.02f;
    }
}
