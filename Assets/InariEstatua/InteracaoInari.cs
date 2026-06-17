using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracaoInari : MonoBehaviour
{
    public GerenciadorGeral ScriptGerenciadorGeral;
    //public GerenciadorDeDialogos ScriptGerenciadorDeDialogos;
    public MeshFilter MeshFilterInari;
    public MeshRenderer MeshRendererInari;
    public Mesh InariSuja;
    public Mesh InariLimpa;

    public string EstadoInari = "Suja";

    [Header("Dialogo")]
    public GameObject CaixaDeTexto;
    public GameObject TextoEscolhido;

    void Start()
    {
        ScriptGerenciadorGeral = GameObject.Find("Canvas").GetComponent<GerenciadorGeral>();
        //ScriptGerenciadorDeDialogos = GameObject.Find("GerenciadorDialogos").GetComponent<GerenciadorDeDialogos>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (EstadoInari == "Suja")
            {
                ScriptGerenciadorGeral.Prompt("Pressione 'ATAQUE' para interagir");
                ScriptGerenciadorGeral.InariAtiva = this;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScriptGerenciadorGeral.PromptInteracao.gameObject.SetActive(false);
            ScriptGerenciadorGeral.InariAtiva = null;
        }
    }

    public void AtivarDialogo()
    {
        CaixaDeTexto.SetActive(true);
        TextoEscolhido.SetActive(true);
        ScriptGerenciadorGeral.PromptInteracao.gameObject.SetActive(false);
    }
}
