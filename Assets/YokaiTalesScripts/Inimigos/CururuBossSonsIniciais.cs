using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CururuBossSonsIniciais : MonoBehaviour
{
    //Este script toca os sons do Cururu Boss quando ele cai nos tempos certos

    public AudioSource MinhaAudioSource;
    public AudioClip Queda;
    public AudioClip Rugido;
    public float Timer;
    int Parte;

    public ParticleSystem EfeitoDeParticulaQueda;

    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= 0.35f)
        {
            if (Parte == 0)
            {
                MinhaAudioSource.PlayOneShot(Queda);
                Parte++;
            }

            if (Timer >= 0.45)
            {
                if (Parte == 1)
                {
                    EfeitoDeParticulaQueda.Play();
                    Parte++;
                }
            }

            if (Timer >= 2)
            {
                if (Parte == 2)
                {
                    MinhaAudioSource.PlayOneShot(Rugido);
                    Parte++;
                }

                if (Timer >= 6)
                {
                    this.enabled = false;
                }
            }
        }
    }
}
