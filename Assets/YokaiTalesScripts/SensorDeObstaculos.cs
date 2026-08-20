using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorDeObstaculos : MonoBehaviour
{
    public GameObject Camera;
    public LayerMask Mask;
    public float CameraDistancia;
    public Vector3 CameraPosicaoInicial;

    void Start()
    {
        CameraDistancia = Vector3.Distance(transform.position, Camera.transform.position);
        CameraPosicaoInicial = Camera.transform.localPosition;
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, CameraDistancia, Mask))
        { 
            Camera.transform.position = hit.point;
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow); 
            //Debug.Log("acertou"); 
        }
        else
        { 
            Camera.transform.localPosition = CameraPosicaoInicial;
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white); 
            //Debug.Log("ñ acertou"); 
        }
    }
}
