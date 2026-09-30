using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TelaPreta : MonoBehaviour
{
    [Header("Debug")]
    public float Timer;
    public int escolha;
    public bool CutsceneAtiva;
    public float FadeOut = -1;

    [Header("Coisas")]
    public TextoAnimado[] Textos;
    public Text EscolhaA;
    public Text EscolhaB;
    public GameObject Selecao;
    public GameObject VideoPlayerCutsceneInicial;
    public GameObject RawImageCutsceneInicial;

    [Header("Fade Out")]
    public Image ImagemPreta;
    public Color Visivel;
    public Color Invisivel;

    public void dUpInput(InputAction.CallbackContext context)
    {
        if (!this.gameObject.activeSelf || !EscolhaA.gameObject.activeSelf || CutsceneAtiva) return;

        if (context.performed)
        {
            escolha++;
            if (escolha > 1) { escolha = 0; }
            PosicionarSelecao();
        }
    }

    public void dDownInput(InputAction.CallbackContext context)
    {
        if (!this.gameObject.activeSelf || !EscolhaA.gameObject.activeSelf || CutsceneAtiva) return;

        if (context.performed)
        {
            escolha--;
            if (escolha < 0) { escolha = 1; }
            PosicionarSelecao();
        }
    }

    public void JumpInput(InputAction.CallbackContext context) //SELECIONAR
    {
        if (!this.gameObject.activeSelf || FadeOut != -1) return; 

        if (!CutsceneAtiva)
        {
            if (context.performed)
            {
                if (EscolhaA.gameObject.activeSelf)
                {
                    PlayerPrefs.SetInt("Dificuldade", escolha); //Se a escolha for 0 (escolha A), a dificuldade é 0 (difícil);
                                                                //e se a escolha for 1 (escolha B) a dificuldade é 1 (fácil)
                    FadeOut = 0;
                    ImagemPreta.gameObject.SetActive(true);
                    FadeInNOut ScriptPraDeletar = ImagemPreta.GetComponent<FadeInNOut>();
                    if (ScriptPraDeletar != null) { Destroy(ScriptPraDeletar); }
                    ImagemPreta.color = Invisivel;
                }
                else
                {
                    foreach (TextoAnimado Texto in Textos) 
                    {
                        Texto.gameObject.SetActive(true);
                        Texto.MostrarTextoLogo();
                    }

                    EscolhaA.gameObject.SetActive(true);
                    EscolhaB.gameObject.SetActive(true);
                    Selecao.SetActive(true);
                }
            }
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    void PosicionarSelecao()
    {
        if (escolha == 0)
        {
            Selecao.transform.position = EscolhaA.transform.position;
        }
        else if (escolha == 1)
        {
            Selecao.transform.position = EscolhaB.transform.position;
        }
    }

    private void OnEnable()
    {
        foreach (TextoAnimado Texto in Textos) { Texto.gameObject.SetActive(false); }
        EscolhaA.gameObject.SetActive(false);
        EscolhaB.gameObject.SetActive(false);
        Selecao.SetActive(false);
    }

    void Update()
    {
        Timer += Time.unscaledDeltaTime;

        if (Timer > 0.5f)
        {
            Textos[0].gameObject.SetActive(true);
        } 
        if (Timer > 4.5f)
        {
            Textos[1].gameObject.SetActive(true);
        }
        if (Timer > 10)
        {
            Textos[2].gameObject.SetActive(true);
        }
        if (Timer > 15)
        {
            Textos[3].gameObject.SetActive(true);
        }
        if (Timer > 17)
        {
            Textos[4].gameObject.SetActive(true);
        }
        if (Timer > 20)
        {
            Textos[5].gameObject.SetActive(true);
        }
        if (Timer > 21)
        {
            EscolhaA.gameObject.SetActive(true);
            EscolhaB.gameObject.SetActive(true);
            Selecao.SetActive(true);
        }

        if (FadeOut != -1)
        {
            FadeOut += Time.unscaledDeltaTime;
            ImagemPreta.color = Color.Lerp(Invisivel, Visivel, FadeOut);

            if (FadeOut > 1)
            {
                FadeOut = -1;
                CutsceneAtiva = true;
                VideoPlayerCutsceneInicial.SetActive(true);
                RawImageCutsceneInicial.SetActive(true);
            }
        }
    }
}
