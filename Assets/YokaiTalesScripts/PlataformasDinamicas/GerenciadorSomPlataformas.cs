using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorSomPlataformas : MonoBehaviour
{
    public AudioSource MinhaAudioSource;
    public PlataformaQueMove[] Plataformas;
    int PlataformasAtivas;

    void Update()
    {
        PlataformasAtivas = 0;

        foreach (PlataformaQueMove Plataforma in Plataformas)
        {
            if (Plataforma.enabled) { PlataformasAtivas++; }
        }

        if (PlataformasAtivas == 0)
        {
            MinhaAudioSource.volume -= 2 * Time.deltaTime;

            if (MinhaAudioSource.volume == 0)
            {
                this.enabled = false;
            }
        }
        else
        {
            MinhaAudioSource.volume += 2 * Time.deltaTime;
        }

        MinhaAudioSource.volume = Mathf.Clamp(MinhaAudioSource.volume, 0, 0.25f);
    }
}
