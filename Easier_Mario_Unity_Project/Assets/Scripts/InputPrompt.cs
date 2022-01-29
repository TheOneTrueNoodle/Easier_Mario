using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPrompt : MonoBehaviour
{
    public Animator UIAnim;

    public void ShowDisplay()
    {
        UIAnim.Play("ButtonMadeVisibleAnimation");
    }

    public void HideDisplay()
    {
        UIAnim.Play("ButtonMadeInvisibleAnimation");
    }
}
