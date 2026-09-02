using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ModoTrailer : MonoBehaviour
{
    public GerenciadorGeral GG;
    public Camera[] Cameras;
    public int CameraSelecionada;
    public bool HUDToggle;

    public void ToggleCamera(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            CameraSelecionada++;
            if (CameraSelecionada == Cameras.Length) { CameraSelecionada = 0; }

            foreach (Camera cam in Cameras)
            {
                cam.enabled = false;
            }

            Cameras[CameraSelecionada].enabled = true;
        }
    }

    public void ToggleHUD(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            HUDToggle = !HUDToggle;

            if (HUDToggle)
            {
                foreach (GameObject ElementoHUD in GG.HUD) { ElementoHUD.SetActive(false); }
            }
            else
            {
                foreach (GameObject ElementoHUD in GG.HUD) { ElementoHUD.SetActive(true); }
            }
        }
    }
}
