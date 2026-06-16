using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class MenuPrincipal : MonoBehaviour
{
    //Este script faz o que o nome sugere! Ele gerencia a lógica da interface do menu principal (qual opção está ativa e quais não estão), e inicia o jogo
    //quando o jogador escolhe a opção

    //Talvez precise refatorar este código com IA depois, pq esse tanto de switch está ruim de trabalhar
    //teste teste

    [Header("Botoes Principais")]
    public GameObject BotoesPrincipais;
    public GameObject Selecao;
    public GameObject NovoJogo;
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

    [Header("Debug")]
    public string MenuAtivo = "Principal";
    public int MenuSelecaoPrincipal;
    public int MenuSelecaoOpcoes;
    public int MenuSelecaoAudio;
    bool DPadCima;
    bool DPadBaixo;
    bool DPadEsquerda;
    bool DPadDireita;
    bool DPadPressionado;
    bool CutsceneAtiva;

    [Header("Outras Coisas")]
    public PlayerInput PlayerInputMenu;
    public GameObject VideoPlayerCutsceneInicial;
    public GameObject RawImageCutsceneInicial;
    public GameObject[] ObjetosParaDesabilitarCutscene;

    [Header("Audio")]
    public AudioSource UIAudioSource;
    public AudioSource MusicAudioSource;
    public AudioClip Confirmar;
    public AudioClip Selecionar;
    public Slider EfeitosSlider;
    public Slider MusicaSlider;

    void Start()
    {
        //CARREGAR CONFIGURAÇÕES SALVAS!!!!
        EfeitosSlider.value = PlayerPrefs.GetFloat("VolumeSFX", 1.0f);
        MusicaSlider.value = PlayerPrefs.GetFloat("VolumeMusica", 1.0f);
    }

    public void dUpInput(InputAction.CallbackContext context)
    {
        if (CutsceneAtiva) return;

        if (context.performed)
        {
            switch (MenuAtivo)
            {
                case "Principal":
                    MenuSelecaoPrincipal--;
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
        if (CutsceneAtiva) return;

        if (context.performed)
        {
            switch (MenuAtivo)
            {
                case "Principal":
                    MenuSelecaoPrincipal++;
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
        if (CutsceneAtiva) return;

        if (context.performed)
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
        if (CutsceneAtiva) return;

        if (context.performed)
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
        if (!CutsceneAtiva)
        {
            if (context.performed)
            {
                ConfirmarOpcao();
            }
        }
        else
        {
            if (context.performed)
            {
                SceneManager.LoadScene(1);
            }
        }
    }

    void SelecionarOpcao()
    {
        switch (MenuAtivo)
        {
            case "Principal":
            if (MenuSelecaoPrincipal < 0) { MenuSelecaoPrincipal = 2; }
            if (MenuSelecaoPrincipal > 2) { MenuSelecaoPrincipal = 0; }

            switch (MenuSelecaoPrincipal)
            {
                case 0: //NOVO JOGO
                    Selecao.transform.position = new Vector3(Selecao.transform.position.x, NovoJogo.transform.position.y, Selecao.transform.position.z);
                    break;

                case 1: //OPÇÕES
                    Selecao.transform.position = new Vector3(Selecao.transform.position.x, Opcoes.transform.position.y, Selecao.transform.position.z);
                    break;

                case 2: //SALVAR E SAIR
                    Selecao.transform.position = new Vector3(Selecao.transform.position.x, SalvarSair.transform.position.y, Selecao.transform.position.z);
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
                switch (MenuSelecaoPrincipal)
                {
                    case 0: //NOVO JOGO
                        //SceneManager.LoadScene(1);
                        VideoPlayerCutsceneInicial.SetActive(true);
                        RawImageCutsceneInicial.SetActive(true);
                        CutsceneAtiva = true;
                        UIAudioSource.enabled = false;
                        MusicAudioSource.enabled = false;

                        foreach (GameObject Elemento in ObjetosParaDesabilitarCutscene)
                        {
                            Elemento.SetActive(false);
                        }
                        
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
