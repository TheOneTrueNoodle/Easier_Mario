using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GlobalAudio : MonoBehaviour
{
    public Slider slider;

    // Update is called once per frame
    void FixedUpdate()
    {
        AudioListener.volume = slider.value;
    }
}
