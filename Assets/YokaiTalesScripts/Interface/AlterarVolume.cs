using UnityEngine;
using UnityEngine.Audio;

public class AlterarVolume : MonoBehaviour
{
    public AudioMixer Mixer;
    public string MixerParaManipular;

    public void AlterarVol(float sliderValue)
    {
        // O valor deve ser convertido de linear (0 a 1) para Logarítmico (-80 a 0 dB)
        // Unity usa decibéis para o AudioMixer
        float volumeEmDB = Mathf.Log10(sliderValue) * 20;
        
        // Se o valor for 0, o Log de 0 é infinito negativo, então tratamos o silêncio:
        if (sliderValue <= 0) volumeEmDB = -80f;

        Mixer.SetFloat(MixerParaManipular, volumeEmDB);
    }
}