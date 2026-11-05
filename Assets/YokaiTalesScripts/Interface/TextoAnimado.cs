using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextoAnimado : MonoBehaviour
{
    public Text texto;
    public bool Terminar;
    [SerializeField] float tempoPorCaractere = 0.05f;
    string textoInbutido;

    void Start()
    {
        textoInbutido = texto.text;
        texto.text = "";
        StartCoroutine(ExibirTexto());
    }

    IEnumerator ExibirTexto()
    {
        foreach (char caractere in textoInbutido)
        {
            texto.text += caractere;

            if (Terminar) 
            {
                texto.text = textoInbutido;
                yield break; 
            } //Encerrar o typing antes de terminar

            yield return new WaitForSeconds(tempoPorCaractere);
        }
    }

    public void MostrarTextoLogo()
    {
        Terminar = true;
    }
}
