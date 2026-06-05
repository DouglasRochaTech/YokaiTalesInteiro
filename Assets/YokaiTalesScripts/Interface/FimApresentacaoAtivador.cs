using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FimApresentacaoAtivador : MonoBehaviour
{
    public GameObject ObjetoParaAtivar;

    void OnDisable()
    {
        ObjetoParaAtivar.SetActive(true);
    }
}
