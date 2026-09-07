using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullingDeObjetos : MonoBehaviour
{
    public Transform Player;
    private float Distance;

    public GameObject[] Objetos;
    int Checar;
    public int DistanciaMaxima = 250;
    public int DistanciaVerticalMaxima = 50;
    float DiferencaDistancia;

    void Start()
    {
		Objetos = new GameObject[transform.childCount];

	    for (int i = 0; i < transform.childCount; i++)
        {
			Objetos[i] = transform.GetChild(i).gameObject;
		}

		//Player = GameObject.Find("Player").transform;
    }

    void FixedUpdate()
    {
		Checar++;

		if (Checar == 4)
	    {
			for (int i = 0; i < transform.childCount; i++)
            {
				if (Objetos[i] != null)
				{
					Distance = Vector3.Distance(Objetos[i].transform.position, Player.position);

					if (Distance > DistanciaMaxima)
					{
						Objetos[i].SetActive(false);
					}
					else
					{
						DiferencaDistancia = Objetos[i].transform.position.y - Player.position.y;

						if ((DiferencaDistancia < -DistanciaVerticalMaxima) | (DiferencaDistancia > DistanciaVerticalMaxima))
						{
							Objetos[i].SetActive(false);
						}
						else
						{
							Objetos[i].SetActive(true);
						}
					}
				}
			}
			Checar = 0;
	    }
    }
}
