using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UISpriteAnimation : MonoBehaviour
{
    //Script q fiz pra animar o vídeo do menu principal de forma mais consistente, sem quebrar na hora da repetição

    public float AnimationSpeed = 0.1f;
    public Image MyImage;
    public Sprite[] AnimationSprites;
    int CurrentFrame;
    float Timer;

    void Update()
    {
        MyImage.sprite = AnimationSprites[CurrentFrame];

        Timer += Time.unscaledDeltaTime;

        if (Timer >= AnimationSpeed)
        {
            Timer = 0;

            CurrentFrame++;

            if (CurrentFrame == AnimationSprites.Length)
            {
                CurrentFrame = 0;
            }
        }
    }
}
