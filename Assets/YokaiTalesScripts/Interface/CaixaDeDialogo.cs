using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaDeDialogo : MonoBehaviour
{
    public CaixaDeDialogo ProximoDialogo;
    public Jogador ScriptDoJogador;
    public GerenciadorGeral ScriptGerenciadorGeral;
    GerenciadorDeDialogos GerenciadorDialogos;
    float Timer;

    [Header("Audio")]
    public AudioSource UIAudioSource;
    public AudioClip DialogoAudio;
    public AudioClip Confirmar;
    public AudioClip Selecionar;
    public float VolumeAudio = 1;

    private void OnEnable()
    {
        foreach (GameObject ElementoHUD in ScriptGerenciadorGeral.HUD) { ElementoHUD.SetActive(false); }

        ScriptDoJogador.enabled = false;
        ScriptDoJogador.AudioSourceCorridinha.volume = 0;
        Time.timeScale = 0;

        UIAudioSource.PlayOneShot(DialogoAudio, VolumeAudio);
    }

    public void Proximo()
    {
        if (!this.gameObject.activeSelf) { return; }
        if (GerenciadorDialogos == null)
        {
            GerenciadorDialogos = GameObject.Find("GerenciadorDialogos").GetComponent<GerenciadorDeDialogos>();
        }
        if (!GerenciadorDialogos.PodeContinuar) { return; }
        GerenciadorDialogos.PodeContinuar = false; 

        this.gameObject.SetActive(false);
        transform.parent.gameObject.SetActive(false);
        UIAudioSource.PlayOneShot(Selecionar);

        if (ProximoDialogo != null)
        {
            ProximoDialogo.gameObject.SetActive(true);
            ProximoDialogo.transform.parent.gameObject.SetActive(true);
        }
        else
        {
            ScriptDoJogador.enabled = true;
            ScriptDoJogador.AudioSourceCorridinha.volume = 1;
            Time.timeScale = 1;

            foreach (GameObject ElementoHUD in ScriptGerenciadorGeral.HUD) { ElementoHUD.SetActive(true); }
        }
    }
}
