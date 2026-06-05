using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiraPraCamera : MonoBehaviour
{
    public Transform Camera;

    void Update()
    {
        transform.LookAt(Camera);
        transform.Rotate(90, 0, 0);
    }
}
