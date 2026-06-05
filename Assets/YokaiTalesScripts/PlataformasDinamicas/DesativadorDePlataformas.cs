using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesativadorDePlataformas : MonoBehaviour
{
    public PlataformaQueMoveHorizontalmente[] Plataformas;
    public GerenciadorSomPlataformasHorizontais GerenciadorDeSom;

    private void OnTriggerEnter(Collider other)
    {
        if (GerenciadorDeSom.enabled)
        {
            if (other.gameObject.tag == "Player")
            {
                foreach (PlataformaQueMoveHorizontalmente Plataforma in Plataformas)
                {
                    Plataforma.enabled = false;
                    Plataforma.SistemaDeParticulas.Stop();
                }

                GerenciadorDeSom.enabled = false;
                GerenciadorDeSom.MinhaAudioSource.enabled = false;
            }
        }
    }
}
