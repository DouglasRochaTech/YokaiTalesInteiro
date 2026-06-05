using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicadorDeObjetivos : MonoBehaviour
{
    [SerializeField] public List<string> ListaObjetivos = new List<string>();

    [SerializeField] private Text[] SlotsTexto = new Text[10];

    private void Start()
    {
        foreach (Text SlotTexto in SlotsTexto)
        {
            SlotTexto.text = "";
        }
    }

    public void AdicionarObjetivo(string NovoObjetivo)
    {
        if (ListaObjetivos.Count < SlotsTexto.Length)
        {
            ListaObjetivos.Insert(0, NovoObjetivo);
            AtualizarInterface();
        }
    }

    public void CompletarObjetivo()
    {
        if (ListaObjetivos.Count > 0)
        {
            ListaObjetivos.RemoveAt(0);
            AtualizarInterface();
        }
    }

    private void AtualizarInterface()
    {
        for (int i = 0; i < SlotsTexto.Length; i++)
        {
            if (i < ListaObjetivos.Count)
            {
                SlotsTexto[i].text = (i + 1) + ". " + ListaObjetivos[i];
            }
            else
            {
                SlotsTexto[i].text = "";
            }
        }
    }
}
