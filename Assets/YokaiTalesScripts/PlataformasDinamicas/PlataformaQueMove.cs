using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaQueMove : MonoBehaviour
{
    Vector3 PosicaoInicial;
    Vector3 PosicaoAlvo;
    Vector3 PosicaoInicialParticulas;
    public Transform PosicaoAlvoT;
    float Animacao;
    public float VelocidadeAnimacao = 0.3f;
    public ParticleSystem SistemaDeParticulas;

    void Start()
    {
        PosicaoInicial = transform.position;
        PosicaoAlvo = PosicaoAlvoT.position;
        PosicaoInicialParticulas = SistemaDeParticulas.transform.position;
    }

    void Update()
    {
        Animacao += Time.deltaTime * VelocidadeAnimacao;

        transform.position = Vector3.Lerp(PosicaoInicial, PosicaoAlvo, Animacao);

        SistemaDeParticulas.transform.position = PosicaoInicialParticulas; //Gambiarra!!! Fiz isso pro sistema de partículas não subir junto com a plataforma, já q é child da plataforma
                                                                           //Escolhi fazer isso ao invés de remover o parentesco (SistemaDeParticulas.transform.parent = null) para não
                                                                           //Bagunçar a organização da tela de hierarquia

        if (Animacao > 1)
        {
            SistemaDeParticulas.Stop();

            this.enabled = false;
        }
    }
}
