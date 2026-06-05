using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaQueMoveHorizontalmente : MonoBehaviour
{
    Vector3 PosicaoInicial;
    Vector3 PosicaoAlvo;
    Vector3 PosicaoInicialParticulas;
    public Transform PosicaoAlvoT;
    public float Animacao;
    bool Inverter;
    public float VelocidadeAnimacao = 0.3f;
    public ParticleSystem SistemaDeParticulas;

    [Header("ProJogadorNãoDeslizar")]
    public float VelocidadeCorrecao = 0.3f;
    public DetectorDeJogador Detector;
    public CharacterController ControladorJogador;

    void Start()
    {
        PosicaoInicial = transform.position;
        PosicaoAlvo = PosicaoAlvoT.position;
    }

    void Update()
    {
        Animacao += Time.deltaTime * VelocidadeAnimacao;

        if (Animacao > 1)
        {
            if (SistemaDeParticulas.isPlaying)
            {
                SistemaDeParticulas.Stop();
            }

            if (Animacao > 1.5f)
            {
                SistemaDeParticulas.Play();

                Inverter = !Inverter;
                Animacao = 0;
            }
        }
        else
        {
            if (!Inverter)
            {
                transform.position = Vector3.Lerp(PosicaoInicial, PosicaoAlvo, Animacao);

                if (Detector.JogadorDetectado)
                {
                    ControladorJogador.Move(Detector.transform.forward * VelocidadeCorrecao * Time.deltaTime);
                }
            }
            else
            {
                transform.position = Vector3.Lerp(PosicaoAlvo, PosicaoInicial, Animacao);

                if (Detector.JogadorDetectado)
                {
                    ControladorJogador.Move(-Detector.transform.forward * VelocidadeCorrecao * Time.deltaTime);
                }
            }
        }
    }
}
