using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cristal : MonoBehaviour
{
    [Header("Desbloqueios")]
    public GameObject ObjetoParaHabilitar;
    public GameObject ObjetoParaDesabilitar;

    [Header("Dialogo")]
    public GameObject CaixaDeTexto;
    public GameObject TextoEscolhido;

    [Header("ItensEssenciais")]
    public MeshFilter MeshFilterCristal;
    public Mesh CristalRachado;
    public GameObject CristalQuebrado;
    public GameObject Dev;
    public AudioSource AudioSourceCristal;
    public AudioClip Rachando;

    [Header("Debug")]
    private Vector3 PosicaoInicial;
    private Vector3 PosicaoInicialFlutuante;
    int Vida = 100;

    void Start()
    {
        PosicaoInicial = transform.position;
    }

    void Update()
    {
        PosicaoInicialFlutuante = new Vector3(PosicaoInicial.x, PosicaoInicial.y + (Mathf.Sin(Time.time * 2) * 0.4f), PosicaoInicial.z);

        transform.position = Vector3.Lerp(transform.position, PosicaoInicialFlutuante, Time.deltaTime * 2);

        transform.Rotate(0, 100 * Time.deltaTime, 0, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DanoJogador")
        {
            MeshFilterCristal.mesh = CristalRachado;
            AudioSourceCristal.PlayOneShot(Rachando);

            transform.position = other.transform.GetChild(1).transform.position; //Gambiarra!!!!! Pegando a posicao de um objeto dentro do colisor, pq esqueci como faz um bagulho e estou com preguiça de descobrir
            //transform.position = other.transform.position;
            //transform.LookAt(other.transform.position);
            //transform.Translate(-Vector3.right * 4);
            //transform.Translate(other.transform.forward * 4, Space.Self);

            Vida -= 25;

            if (Vida <= 0)
            {
                CaixaDeTexto.SetActive(true);
                TextoEscolhido.SetActive(true);

                if (ObjetoParaHabilitar != null) { ObjetoParaHabilitar.SetActive(true); }
                if (ObjetoParaDesabilitar != null) { ObjetoParaDesabilitar.SetActive(false); }

                GameObject CristalInstanciado = Instantiate(CristalQuebrado, transform.position, transform.rotation);
                CristalInstanciado.transform.localScale = transform.localScale;
                Destroy(CristalInstanciado, 4);

                Dev.SetActive(true);
                Dev.transform.parent = null;

                Destroy(gameObject);
            }
        }
    }
}
