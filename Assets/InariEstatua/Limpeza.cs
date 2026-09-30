using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limpeza : MonoBehaviour
{
    public InteracaoInari ScriptInteracaoInari;
    public Material MaterialLimpo;
    public Material MaterialLimpo2;
    public FadeInNOut ScriptFadeInNOut;

    void Start()
    {
        ScriptInteracaoInari.MeshFilterInari.mesh = ScriptInteracaoInari.InariLimpa;

        Material[] materiais = new Material[3];
        materiais[0] = MaterialLimpo;
        materiais[1] = MaterialLimpo2;
        materiais[2] = MaterialLimpo2;
        ScriptInteracaoInari.MeshRendererInari.materials = materiais;

        ScriptInteracaoInari.EstadoInari = "Limpa";

        this.gameObject.SetActive(false);
    }
}
