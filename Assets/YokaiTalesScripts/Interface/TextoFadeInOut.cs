using UnityEngine;
using UnityEngine.UI;

public class TextoFadeInOut : MonoBehaviour
{
    public Text Texto;
    public Color Invisivel;
    public Color Visivel;

    public float Visibilidade;
    public float TempoVisivel = 2;
    public float Timer;

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
            Visibilidade -= Time.unscaledDeltaTime;
            Texto.color = Color.Lerp(Invisivel, Visivel, Visibilidade);

            if (Visibilidade <= 0) { this.enabled = false; }
        }
    }
}
