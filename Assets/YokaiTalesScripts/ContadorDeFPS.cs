using UnityEngine;
using TMPro;

public class ContadorDeFPS : MonoBehaviour
{
    public TMP_Text FPS_Display;

    void Update()
    {
        FPS_Display.text = Mathf.Round(1 / Time.unscaledDeltaTime) + "FPS";
    }
}