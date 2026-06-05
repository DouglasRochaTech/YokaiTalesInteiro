using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MenuDePausa : MonoBehaviour
{
    [Header("Stuff")]
    public GerenciadorGeral GG;
    public Jogador ScriptDoJogador;
    public Image BarraDeVida;
    public Slider SliderVida;
    public GameObject TextoFimDeJogo;
    public GameObject[] HUD;

    [Header("Debug")]
    public string MenuAtivo = "Principal";
    public int MenuSelecaoPrincipal;
    public int MenuSelecaoOpcoes;
    public int MenuSelecaoAudio;
    public int PausaSelecao;
    bool DPadCima;
    bool DPadBaixo;
    bool DPadEsquerda;
    bool DPadDireita;
    bool DPadPressionado;

    [Header("BotoesPrincipais")]
    public GameObject BotoesPrincipais;
    public GameObject Selecao;
    public GameObject Retomar;
    public GameObject Opcoes;
    public GameObject SalvarSair;

    [Header("Botoes Opcoes")]
    public GameObject BotoesOpcoes;
    public GameObject BotaoAudio;
    public GameObject BotaoGraficos;
    public GameObject BotaoVoltar;   

    [Header("Botoes Audio")] 
    public GameObject BotoesAudio;
    public GameObject BotaoEfeitos;
    public GameObject BotaoMusica;
    public GameObject BotaoVoltarAudio;
    public Slider EfeitosSlider;
    public Slider MusicaSlider;

    [Header("Audio")]
    public AudioSource UIAudioSource;
    public AudioClip Confirmar;
    public AudioClip Selecionar;

    public void Start()
    {
        //CARREGAR CONFIGURAÇÕES SALVAS!!!!
        EfeitosSlider.value = PlayerPrefs.GetFloat("VolumeSFX", 1.0f);
        MusicaSlider.value = PlayerPrefs.GetFloat("VolumeMusica", 1.0f);
    }

    public void dUpInput(InputAction.CallbackContext context)
    {
        if (context.performed && GG.PAUSADO)
        {
            switch (MenuAtivo)
            {
                case "Principal":
                    PausaSelecao--;
                    break;

                case "Opcoes":
                    MenuSelecaoOpcoes--;
                    break;

                case "Audio":
                    MenuSelecaoAudio--;
                    break;
            }

            SelecionarOpcao();
            UIAudioSource.PlayOneShot(Selecionar);
        }
    }

    public void dDownInput(InputAction.CallbackContext context)
    {
        if (context.performed && GG.PAUSADO)
        {
            switch (MenuAtivo)
            {
                case "Principal":
                    PausaSelecao++;
                    break;

                case "Opcoes":
                    MenuSelecaoOpcoes++;
                    break;

                case "Audio":
                    MenuSelecaoAudio++;
                    break;
            }

            SelecionarOpcao();
            UIAudioSource.PlayOneShot(Selecionar);
        }
    }

    public void dLeftInput(InputAction.CallbackContext context)
    {
        if (context.performed && GG.PAUSADO)
        {
            if (MenuAtivo == "Audio")
            {
                switch (MenuSelecaoAudio)
                {
                    case 0: //SFX
                        EfeitosSlider.value -= 0.1f;
                        UIAudioSource.PlayOneShot(Selecionar);
                        break;

                    case 1: //MÚSICA
                        MusicaSlider.value -= 0.1f;
                        UIAudioSource.PlayOneShot(Selecionar);
                        break;
                }
            }
        }
    }

    public void dRightInput(InputAction.CallbackContext context)
    {
        if (context.performed && GG.PAUSADO)
        {
            if (MenuAtivo == "Audio")
            {
                switch (MenuSelecaoAudio)
                {
                    case 0: //SFX
                        EfeitosSlider.value += 0.1f;
                        UIAudioSource.PlayOneShot(Selecionar);
                        break;

                    case 1: //MÚSICA
                        MusicaSlider.value += 0.1f;
                        UIAudioSource.PlayOneShot(Selecionar);
                        break;
                }
            }
        }
    }

    public void JumpInput(InputAction.CallbackContext context) //SELECIONAR
    {
        if (context.performed && GG.PAUSADO)
        {
            ConfirmarOpcao();
        }
    }

    void SelecionarOpcao()
    {
        switch (MenuAtivo)
        {
            case "Principal":
                if (PausaSelecao < 0) { PausaSelecao = 2; }
                if (PausaSelecao > 2) { PausaSelecao = 0; }

                switch (PausaSelecao)
                {
                    case 0: //RETORNAR
                        Selecao.transform.position = Retomar.transform.position;
                        break;

                    case 1: //OPÇÕES
                        Selecao.transform.position = Opcoes.transform.position;
                        break;

                    case 2: //SALVAR E SAIR
                        Selecao.transform.position = SalvarSair.transform.position;
                        break;
                }
                break;

            case "Opcoes":
                if (MenuSelecaoOpcoes < 0) { MenuSelecaoOpcoes = 2; }
                if (MenuSelecaoOpcoes > 2) { MenuSelecaoOpcoes = 0; }

                switch (MenuSelecaoOpcoes)
                {
                    case 0: //ÁUDIO
                        Selecao.transform.position = new Vector3(Selecao.transform.position.x, BotaoAudio.transform.position.y, Selecao.transform.position.z);
                        break;

                    case 1: //GRÁFICOS
                        Selecao.transform.position = new Vector3(Selecao.transform.position.x, BotaoGraficos.transform.position.y, Selecao.transform.position.z);
                        break;

                    case 2: //VOLTAR
                        Selecao.transform.position = new Vector3(Selecao.transform.position.x, BotaoVoltar.transform.position.y, Selecao.transform.position.z);
                        break;
                }
                break;

            case "Audio":
                if (MenuSelecaoAudio < 0) { MenuSelecaoAudio = 2; }
                if (MenuSelecaoAudio > 2) { MenuSelecaoAudio = 0; }

                switch (MenuSelecaoAudio)
                {
                    case 0: //EFEITOS
                        Selecao.transform.position = new Vector3(Selecao.transform.position.x, BotaoEfeitos.transform.position.y, Selecao.transform.position.z);
                        break;

                    case 1: //MÚSICA
                        Selecao.transform.position = new Vector3(Selecao.transform.position.x, BotaoMusica.transform.position.y, Selecao.transform.position.z);
                        break;

                    case 2: //VOLTAR
                        Selecao.transform.position = new Vector3(Selecao.transform.position.x, BotaoVoltarAudio.transform.position.y, Selecao.transform.position.z);
                        break;
                }
                break;
        }
    }

    void ConfirmarOpcao()
    {
        switch (MenuAtivo)
        {
            case "Principal":
                switch (PausaSelecao)
                {
                    case 0: //RETORNAR
                        Time.timeScale = 1;
                        ScriptDoJogador.enabled = true;
                        this.gameObject.SetActive(false);
                        GG.PAUSADO = false;
                        break;

                    case 1: //OPÇÕES
                        MenuAtivo = "Opcoes";
                        BotoesPrincipais.SetActive(false);
                        BotoesOpcoes.SetActive(true);
                        BotoesAudio.SetActive(false);
                        SelecionarOpcao();
                        break;

                    case 2: //SALVAR E SAIR
                        Application.Quit();
                        break;
                }
                break;

            case "Opcoes":
                switch (MenuSelecaoOpcoes)
                {
                    case 0: //ÁUDIO
                        MenuAtivo = "Audio";
                        BotoesPrincipais.SetActive(false);
                        BotoesOpcoes.SetActive(false);
                        BotoesAudio.SetActive(true);
                        SelecionarOpcao();
                        break;

                    case 1: //GRÁFICOS
                        break;

                    case 2: //VOLTAR
                        MenuAtivo = "Principal";
                        BotoesPrincipais.SetActive(true);
                        BotoesOpcoes.SetActive(false);
                        BotoesAudio.SetActive(false);
                        SelecionarOpcao();
                        break;
                }
                break;

            case "Audio":
                switch (MenuSelecaoAudio)
                {
                    case 0: //EFEITOS
                        break;

                    case 1: //MÚSICA
                        break;

                    case 2: //VOLTAR
                        MenuAtivo = "Opcoes";
                        BotoesPrincipais.SetActive(false);
                        BotoesOpcoes.SetActive(true);
                        BotoesAudio.SetActive(false);
                        PlayerPrefs.SetFloat("VolumeSFX", EfeitosSlider.value);
                        PlayerPrefs.SetFloat("VolumeMusica", MusicaSlider.value);
                        SelecionarOpcao();
                        break;
                }
                break;
        }

        UIAudioSource.PlayOneShot(Confirmar);
    }
}