using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardEffect : MonoBehaviour
{
    void Update()
    {
        if (Camera.main is { }) transform.LookAt(Camera.main.transform.position, Vector3.up);
    }
}
