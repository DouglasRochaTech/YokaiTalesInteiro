using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInNOut : MonoBehaviour
{
    //Este script faz fade in e fade out (clarear ou escurecer a imagem)

    public Image ImagemPreta;
    public Color Visivel;
    public Color Invisivel;
    float Visibilidade = 1;

    void OnEnable()
    {
        Visibilidade = 1;
    }

    void Start()
    {
        ImagemPreta.enabled = true;
    }

    void Update()
    {
        Visibilidade -= Time.deltaTime;

        ImagemPreta.color = Color.Lerp(Invisivel, Visivel, Visibilidade);

        if (Visibilidade < 0)
        {
            gameObject.SetActive(false);
        }
    }
}
