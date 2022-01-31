using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindRenderCamera : MonoBehaviour
{
    public Canvas canvas;

    private void Update()
    {
        canvas.worldCamera = FindObjectOfType<Camera>();
    }
}
