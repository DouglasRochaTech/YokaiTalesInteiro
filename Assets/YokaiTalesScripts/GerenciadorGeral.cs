using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GerenciadorGeral : MonoBehaviour
{
    //Este script lida com a lógica dos estados do jogo! Se o jogo está pausado ou não, e se o jogador está vivo ou se deve-se exibir a tela de morte.

    //O script está: em um objeto de nome "Canvas". 


    public Jogador ScriptDoJogador;
    public Image BarraDeVida;
    public Slider SliderVida;
    public GameObject TextoFimDeJogo;

    public GameObject[] HUD;
    public Text PromptInteracao;

    [Header("Inari")]
    public InteracaoInari InariAtiva;

    [Header("Debug")]
    public bool PAUSADO;
    public int PausaSelecao;
    public float HitStopTimer = -1;
    float BarraDeVidaInterpolada;
    bool DPadCima;
    bool DPadBaixo;
    bool DPadEsquerda;
    bool DPadDireita;
    bool DPadPressionado;

    [Header("Pausa")]
    public MenuDePausa MenuDePausaScript;
    public GameObject MenuPausa;

    [Header("Audio")]
    public AudioSource UIAudioSource;
    public AudioClip Confirmar;
    public AudioClip Selecionar;

    public void StartInput(InputAction.CallbackContext context) //PAUSAR
    {
        if (context.performed)
        {
            PAUSADO = !PAUSADO;

            if (PAUSADO)
            {
                Time.timeScale = 0;
                ScriptDoJogador.enabled = false;
                MenuPausa.SetActive(true);
                foreach (GameObject ElementoHUD in HUD) { ElementoHUD.SetActive(false); }
                //SelecionarOpcaoPausa(); //Pra atualizar a posição das florezinhas
            }
            else
            {
                Time.timeScale = 1;
                ScriptDoJogador.enabled = true;
                MenuPausa.SetActive(false);
                foreach (GameObject ElementoHUD in HUD) { ElementoHUD.SetActive(true); }
            }

            UIAudioSource.PlayOneShot(Confirmar);
        }
    }

    public void dUpInput(InputAction.CallbackContext context)
    {
        /*if (context.performed)
        {
            if (PAUSADO)
            {
                PausaSelecao--;
                SelecionarOpcaoPausa();
                UIAudioSource.PlayOneShot(Selecionar);
            }
        }*/
    }

    public void dDownInput(InputAction.CallbackContext context)
    {
        /*if (context.performed)
        {
            if (PAUSADO)
            {
                PausaSelecao++;
                SelecionarOpcaoPausa();
                UIAudioSource.PlayOneShot(Selecionar);
            }
        }*/
    }

    public void JumpInput(InputAction.CallbackContext context) //SELECIONAR
    {
        /*if (context.performed)
        {
            if (PAUSADO)
            {
                ConfirmarOpcaoPausa();
            }
        }*/
    }

    public void Prompt(string texto)
    {
        PromptInteracao.text = texto;
        PromptInteracao.gameObject.SetActive(true);
    }

    void Start()
    {
        MenuDePausaScript.Start();
    }

    void Update()
    {
        if (ScriptDoJogador)
        {
            //SliderVida.value = ScriptDoJogador.Vida;

            BarraDeVidaInterpolada = Mathf.Lerp(0, 0.820f, ScriptDoJogador.Vida * 0.01f);
            BarraDeVida.fillAmount = BarraDeVidaInterpolada;
        }
        else
        {
            BarraDeVida.fillAmount = 0;

            if (!TextoFimDeJogo.activeSelf)
            {
                TextoFimDeJogo.SetActive(true);
            }

            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
