using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limpeza : MonoBehaviour
{
    public InteracaoInari ScriptInteracaoInari;
    public Material MaterialLimpo;
    public FadeInNOut ScriptFadeInNOut;

    void Start()
    {
        ScriptInteracaoInari.MeshFilterInari.mesh = ScriptInteracaoInari.InariLimpa;

        Material[] materiais = new Material[3];
        materiais[0] = MaterialLimpo;
        materiais[1] = MaterialLimpo;
        materiais[2] = MaterialLimpo;
        ScriptInteracaoInari.MeshRendererInari.materials = materiais;

        ScriptInteracaoInari.EstadoInari = "Limpa";

        this.gameObject.SetActive(false);
    }
}
