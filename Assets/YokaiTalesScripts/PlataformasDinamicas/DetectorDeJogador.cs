using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorDeJogador : MonoBehaviour
{
    public bool JogadorDetectado;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            JogadorDetectado = true;
            //other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            JogadorDetectado = false;
            //other.transform.parent = null;
        }
    }
}
