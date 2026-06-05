using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraDeVidaInimigo : MonoBehaviour
{
    //Este script faz o que o nome sugere!

    public Inimigo ScriptInimigo;
    public Transform CameraT;
    public Transform Barra;

    void Update()
    {
        if (ScriptInimigo != null)
        {
            //transform.LookAt(CameraT.position);
            //transform.Rotate(0, 180, 0);
            transform.rotation = Quaternion.Euler(transform.rotation.x, CameraT.eulerAngles.y, transform.rotation.z);

            Barra.localScale = new Vector3(ScriptInimigo.Vida * 0.01f, 0.1f, 0.1f);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
