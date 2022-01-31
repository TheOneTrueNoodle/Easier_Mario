using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public List<ResourceData> Resources;

    public TMP_Text Resource;

    private void Update()
    {
        Resource = GameObject.FindGameObjectWithTag("Wood").GetComponent<TMP_Text>();
        for (int i = 0; i < Resources.Count; i++)
        {
            Resource.text = Resources[i].CurrentResourceValue + "/" + Resources[i].MaxResourceValue;
        }
    }
}
