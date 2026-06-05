using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedeDeTexto : MonoBehaviour
{
    //Onde infernos eu usava este script?!!?? kkkkkkk
    public Transform CameraPivot;

    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x, CameraPivot.eulerAngles.y, transform.rotation.z);
        transform.Rotate(transform.up * 90);
    }
}
