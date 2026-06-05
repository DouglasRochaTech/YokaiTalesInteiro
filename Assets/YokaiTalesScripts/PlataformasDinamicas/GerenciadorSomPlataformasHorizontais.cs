using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorSomPlataformasHorizontais : MonoBehaviour
{
    public AudioSource MinhaAudioSource;
    public PlataformaQueMoveHorizontalmente[] Plataformas;
    int PlataformasAtivas;

    void Update()
    {
        PlataformasAtivas = 0;

        foreach (PlataformaQueMoveHorizontalmente Plataforma in Plataformas)
        {
            if (Plataforma.Animacao <= 1) { PlataformasAtivas++; }
        }

        if (PlataformasAtivas == 0)
        {
            MinhaAudioSource.volume -= 4 * Time.deltaTime;
        }
        else
        {
            MinhaAudioSource.volume += 4 * Time.deltaTime;
        }

        MinhaAudioSource.volume = Mathf.Clamp(MinhaAudioSource.volume, 0, 0.25f);
    }
}
