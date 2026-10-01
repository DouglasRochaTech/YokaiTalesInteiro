using UnityEngine;
using UnityEngine.UI;

public class TextoFadeInOut : MonoBehaviour
{
    [Header("Coisas")]
    public Color Invisivel;
    public Color Visivel;
    public Text Texto;

    [Header("Configurações")]
    public float Visibilidade;
    public float TempoVisivel = 2;
    public bool ComFadeOut = true;
    public float Timer;

    void OnEnable()
    {
        Texto = GetComponent<Text>();
        Texto.color = Invisivel;
    }

    void Update()
    {
        if (Timer <= TempoVisivel)
        {
            if (Visibilidade < 1)
            {
                Visibilidade += Time.unscaledDeltaTime;
                Texto.color = Color.Lerp(Invisivel, Visivel, Visibilidade);
            }
            else
            {
                Timer += Time.unscaledDeltaTime;
            }
        }
        else
        {
            if (ComFadeOut) 
            { 
                Visibilidade -= Time.unscaledDeltaTime;
                Texto.color = Color.Lerp(Invisivel, Visivel, Visibilidade);

                if (Visibilidade <= 0) { this.enabled = false; }
            }
            else
            {
                this.enabled = false;
            }
        }
    }
}
