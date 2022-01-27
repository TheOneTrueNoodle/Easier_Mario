using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeInputPrompt : MonoBehaviour
{
    public Sprite ProController_A;
    public Sprite ProController_B;
    public Sprite PS4Controller_Circle;
    public Sprite PS4Controller_Cross;
    public Sprite Keyboard_E;
    public Sprite Keyboard_Space;

    public GameObject ButtonPrompt;
    public PlayerControls pInput;

    public void ShowDisplay ()
    {
        ButtonPrompt.SetActive(true);
    }

    public void HideDisplay ()
    {
        ButtonPrompt.SetActive(false);
    }
}
