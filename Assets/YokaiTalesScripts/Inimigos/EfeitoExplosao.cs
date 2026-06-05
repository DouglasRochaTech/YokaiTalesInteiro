using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitoExplosao : MonoBehaviour
{
    //Este script ativa o efeito de partículas de "puff", quando o cadáver do inimigo some, deleta o cadáver do inimigo e depois deleta o próprio objeto

    float Timer;
    public ParticleSystem Efeito;
    public GameObject Inimigo;
    public Transform Corpo;

    public AudioSource AudioSourceExplosao;
    public AudioClip Puff;

    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer > 2)
        {
            if (Inimigo != null)
            {
                transform.position = Corpo.position;               
                transform.parent = null;
                Destroy(Inimigo.gameObject);
                
                Efeito.Play();
                AudioSourceExplosao.PlayOneShot(Puff);
            }

            if (Timer >= 3.5f)
            {
                Destroy(gameObject);
            }
        }
    }
}
