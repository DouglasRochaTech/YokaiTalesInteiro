using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CururuBoss : MonoBehaviour
{
    //Script do Cururu Boss!!! Por enquanto ele apenas mostra a animação dele chegando, e não tem a lógica do inimigo!!!

    public float Vida = 1000;

    [Header("Debug")]
    public int Estado = -1; // Começa em -1 para rugido inicial
        //Depois de certo tempo ele muda de estado, e para alguns estados, receber uma certa quantidade de dano faz ele mudar de estado

        //-1 = Rugindo (inicial)
        //0 = Perseguindo
        //1 = Agressivo (mais rápido)
        //2 = Movimento limitado (y=0, velocidade menor)
        //3 = GroundPound <- vai precisar de nova animação
        //4 = Mordida
        //5 = Cuspindo <- vai precisar de nova animação
    public float TimerEstado;
    public float VelocidadeMovimento = 7.5f; // 50% acima da velocidade do jogador (5 * 1.5 = 7.5)
    
    int ContadorEstado4 = 0; // Contador de vezes que Estado 4 foi acionado
    float AlturaAlvoPulo = 5f; // Altura que o boss vai pular
    float VelocidadeVerticalPulo = 0f; // Velocidade vertical do pulo
    float GravidadePulo = -40f; // Gravidade do pulo
    Vector3 PosicaoOriginalPulo; // Posição original para o pulo

    public float Distancia;
    float TimerAtaque = -1;
    float TimerDano = -1;
    bool Atacou;
    public SkinnedMeshRenderer Renderizador;
    public Material MaterialNormal;
    public Material MaterialDano;

    [Header("ItensEssenciais")]
    public GerenciadorGeral GG;
    public CharacterController Controlador;
    public Transform JogadorT;
    public Vector3 JogadorTNivelado;
    public Transform PontoDeInstanciacao;
    public GameObject ColisorDeDano;
    GameObject ColisorDeDanoInstanciado;
    public Animator Animador;
    public GameObject EfeitoExplosao;

    [Header("Audio")]
    public AudioSource AudioSourceCururu;
    public AudioClip Mordida;
    public AudioClip Rosnada;
    public AudioClip GemidoDor;
    bool Rosnou;

    void Start()
    {
        Animador.Play("CairRugir");
        Animador.SetBool("Rugindo", true);

        JogadorT = GameObject.Find("Jogador").transform;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DanoJogador")
        {
            ChecarDano(40); Debug.Log("Dano Checado");
        }
    }

    void ChecarDano(float Dano)
    {
        TimerDano = 0;
        Renderizador.material = MaterialDano;
        Controlador.Move(transform.forward * -0.3f);
        Animador.SetBool("Dano", true);
        //GG.HitStopTimer = 0;
        Vida -= Dano;
        AudioSourceCururu.PlayOneShot(GemidoDor, 0.5f);

        if (Vida <= 0)
        {
            Animador.SetBool("Morrer", true);
            Renderizador.material = MaterialNormal;
            EfeitoExplosao.SetActive(true);

            Destroy(this);
            Destroy(Controlador);
        }
    }

    void LookAtPlayerOnY()
    {
        JogadorTNivelado = new Vector3(JogadorT.position.x, transform.position.y, JogadorT.position.z);

        transform.LookAt(JogadorTNivelado);

        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }

    void Update() //Tudo aqui dentro atualiza a cada frame!!!
    {
        TimerEstado += Time.deltaTime;

        // Transições de estado
        if (Estado == -1 && TimerEstado > 5f)
        {
            Estado = 1;
            TimerEstado = 0;
            VelocidadeMovimento = 7.5f; // Reinicia velocidade
            Animador.SetBool("Rugindo", false);
        }
        else if (Estado == 0 && TimerEstado > 3f)
        {
            Estado = 1;
            TimerEstado = 0;
            VelocidadeMovimento = 7.5f; // Reinicia velocidade
        }
        else if (Estado == 1 && TimerEstado > 5f) // Estado 1 leva a Estado 3
        {
            Estado = 3;
            TimerEstado = 0;
            VelocidadeMovimento = 7.5f; // Reinicia velocidade
        }
        else if (Estado == 2 && TimerEstado > 10f) // Estado 2 leva a Estado 4
        {
            Estado = 4;
            TimerEstado = 0;
            VelocidadeMovimento = 7.5f; // Reinicia velocidade
        }


        switch (Estado)
        {
            case -1: // Estado Rugindo inicial
                // Não fazer nada, apenas esperar o timer
                Controlador.Move(-transform.up * 2f * Time.deltaTime);
                break;

            case 0:
                    
                if (JogadorT != null)
                {
                    LookAtPlayerOnY();

                    if (TimerDano != -1)
                    {
                        TimerDano += Time.unscaledDeltaTime;

                        if (TimerDano > 0.2f)
                        {
                            Renderizador.material = MaterialNormal;
                            TimerDano = -1;
                            Animador.SetBool("Dano", false);
                        }
                    }
                    else
                    {
                        if (TimerAtaque == -1)
                        {
                            if (JogadorT)
                            {
                                Distancia = Vector3.Distance(transform.position, JogadorT.position);

                                if (Distancia < 10)
                                {
                                    if (!Rosnou) { AudioSourceCururu.PlayOneShot(Rosnada, 0.2f); Rosnou = true; }

                                    if (Distancia > 1.5f)
                                    {
                                        Controlador.Move(transform.forward * 3 * Time.deltaTime);
                                        Animador.SetBool("Andar", true);
                                    }
                                    else
                                    {
                                        //INICIAR ATAQUE!!!
                                        TimerAtaque = 0;
                                        Animador.SetBool("Andar", false);
                                        Animador.SetBool("Atacar", true);
                                    }
                                }
                                else
                                {
                                    Animador.SetBool("Andar", false);
                                }
                            }
                            else
                            {
                                Animador.SetBool("Andar", false);
                            }
                        }
                        else
                        {
                            TimerAtaque += Time.deltaTime;

                            if (!Atacou)
                            {
                                if (TimerAtaque > 0.15f)
                                {
                                    ColisorDeDanoInstanciado = Instantiate(ColisorDeDano, PontoDeInstanciacao.position, transform.rotation);
                                    Destroy(ColisorDeDanoInstanciado, 0.05f);
                                    Atacou = true;
                                    AudioSourceCururu.PlayOneShot(Mordida, 0.4f);
                                }
                            }

                            if (TimerAtaque > 0.6f) //TERMINAR ATAQUE!!!
                            {
                                TimerAtaque = -1;
                                Atacou = false;
                                Animador.SetBool("Atacar", false);
                            }
                        }
                    }
                }
                else
                {
                    Animador.SetBool("Andar", false);
                    Animador.SetBool("Atacar", false);
                    Animador.SetBool("Dano", false);
                }

                Controlador.Move(-transform.up * 2f * Time.deltaTime);
                break;      

            case 1: // Estado Agressivo 
                if (JogadorT != null)
                {
                    LookAtPlayerOnY();

                    if (TimerDano != -1)
                    {
                        TimerDano += Time.unscaledDeltaTime;
                        if (TimerDano > 0.2f)
                        {
                            Renderizador.material = MaterialNormal;
                            TimerDano = -1;
                            Animador.SetBool("Dano", false);
                        }
                    }
                    else
                    {
                        Distancia = Vector3.Distance(transform.position, JogadorT.position);
                        if (Distancia < 10)
                        {
                            if (!Rosnou) { AudioSourceCururu.PlayOneShot(Rosnada, 0.2f); Rosnou = true; }
                            if (Distancia > 1.5f)
                            {
                                Controlador.Move(transform.forward * VelocidadeMovimento * Time.deltaTime); // Movimento mais rápido
                                Animador.SetBool("Andar", true);
                            }
                            else
                            {
                                TimerAtaque = 0;
                                Animador.SetBool("Andar", false);
                                Animador.SetBool("Atacar", true);
                            }
                        }
                        else
                        {
                            Animador.SetBool("Andar", false);
                        }
                    }
                }
                else
                {
                    Animador.SetBool("Andar", false);
                    Animador.SetBool("Atacar", false);
                    Animador.SetBool("Dano", false);
                }
                Controlador.Move(-transform.up * 2f * Time.deltaTime);
                break;

            case 2: // Movimento limitado: y=0, velocidade menor
                if (JogadorT != null)
                {
                    LookAtPlayerOnY();

                    if (TimerDano != -1)
                    {
                        TimerDano += Time.unscaledDeltaTime;
                        if (TimerDano > 0.2f)
                        {
                            Renderizador.material = MaterialNormal;
                            TimerDano = -1;
                            Animador.SetBool("Dano", false);
                        }
                    }
                    else
                    {
                        Distancia = Vector3.Distance(transform.position, JogadorT.position);
                        if (Distancia < 10)
                        {
                            if (!Rosnou) { AudioSourceCururu.PlayOneShot(Rosnada, 0.2f); Rosnou = true; }
                            if (Distancia > 1.5f)
                            {
                                Vector3 moveDirection = transform.forward * (VelocidadeMovimento * 0.5f) * Time.deltaTime; // Velocidade menor
                                moveDirection.y = 0; // Limitação de y a 0
                                Controlador.Move(moveDirection);
                                Animador.SetBool("Andar", true);
                            }
                            else
                            {
                                TimerAtaque = 0;
                                Animador.SetBool("Andar", false);
                                Animador.SetBool("Atacar", true);
                            }
                        }
                        else
                        {
                            Animador.SetBool("Andar", false);
                        }
                    }
                }
                else
                {
                    Animador.SetBool("Andar", false);
                    Animador.SetBool("Atacar", false);
                    Animador.SetBool("Dano", false);
                }
                Controlador.Move(-transform.up * 2f * Time.deltaTime);
                break;

            case 3: // Estado GroundPound - Pulo com mordida
                if (JogadorT != null)
                {
                    LookAtPlayerOnY();

                    if (TimerEstado == 0) // Iniciar pulo
                    {
                        PosicaoOriginalPulo = transform.position;
                        VelocidadeVerticalPulo = Mathf.Sqrt(AlturaAlvoPulo * -3f * GravidadePulo);
                        Animador.SetBool("Pulando", true);
                    }

                    // Aplicar gravidade e movimento do pulo
                    VelocidadeVerticalPulo += GravidadePulo * Time.deltaTime;
                    Vector3 movimentoPulo = transform.up * VelocidadeVerticalPulo * Time.deltaTime;
                    Controlador.Move(movimentoPulo);

                    // Verificar se voltou à posição original (abaixou para o nível do jogador)
                    if (transform.position.y <= PosicaoOriginalPulo.y && TimerEstado > 0.5f)
                    {
                        // Invocar mordida
                        ColisorDeDanoInstanciado = Instantiate(ColisorDeDano, PontoDeInstanciacao.position, transform.rotation);
                        Destroy(ColisorDeDanoInstanciado, 0.05f);
                        AudioSourceCururu.PlayOneShot(Mordida, 0.4f);

                        // Voltar para estado 2
                        Estado = 2;
                        TimerEstado = 0;
                        Animador.SetBool("Pulando", false);
                        VelocidadeVerticalPulo = 0f;
                    }
                }
                break;

            case 4: // Estado Mordida - Esperar perto do jogador
                if (JogadorT != null)
                {
                    LookAtPlayerOnY();
                    Distancia = Vector3.Distance(transform.position, JogadorT.position);

                    if (Distancia < 3f) // Jogador perto
                    {
                        if (TimerEstado > 5f) // Passou 5 segundos perto
                        {
                            // Invocar mordida
                            ColisorDeDanoInstanciado = Instantiate(ColisorDeDano, PontoDeInstanciacao.position, transform.rotation);
                            Destroy(ColisorDeDanoInstanciado, 0.05f);
                            AudioSourceCururu.PlayOneShot(Mordida, 0.4f);

                            ContadorEstado4++;

                            // Se Estado 4 aconteceu 2 vezes, ir para Estado 3
                            if (ContadorEstado4 >= 2)
                            {
                                Estado = 3;
                                ContadorEstado4 = 0;
                                TimerEstado = 0;
                            }
                            else
                            {
                                Estado = 0;
                                TimerEstado = 0;
                            }
                        }
                    }
                    else
                    {
                        // Jogador se afastou, voltar para estado 0
                        Estado = 0;
                        TimerEstado = 0;
                        ContadorEstado4 = 0;
                    }
                }
                Controlador.Move(-transform.up * 2f * Time.deltaTime);
                break;
        }
    }

}
