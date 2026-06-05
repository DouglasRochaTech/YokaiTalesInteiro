using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MorteInterface : MonoBehaviour
{
    //Este script faz a animação da interface quando o fox morre! :C

    public Image ImagemPreta;
    public Text TextoPrincipal;
    public Text TextoMenor;

    public Color Visivel;
    public Color Invisivel;
    public Color VisivelTexto;
    public Color InvisivelTexto;
    float Visibilidade;

    void Start()
    {
        ImagemPreta.color = Color.Lerp(Invisivel, Visivel, 0);
        TextoPrincipal.color = Color.Lerp(InvisivelTexto, VisivelTexto, 0);
        TextoMenor.color = Color.Lerp(InvisivelTexto, VisivelTexto, 0);
    }

    void Update()
    {
        Visibilidade += Time.deltaTime * 0.5f;

        ImagemPreta.color = Color.Lerp(Invisivel, Visivel, Visibilidade);
        TextoPrincipal.color = Color.Lerp(InvisivelTexto, VisivelTexto, Visibilidade * 1.2f);
        TextoMenor.color = Color.Lerp(InvisivelTexto, VisivelTexto, (Visibilidade - 1));
    }
}
