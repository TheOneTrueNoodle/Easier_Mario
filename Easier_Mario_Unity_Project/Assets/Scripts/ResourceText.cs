using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceText : MonoBehaviour
{
    public TMP_Text woodnr;
    public List<ResourceData> rsc;


    // Start is called before the first frame update
    void Start()
    {

        rsc = GameObject.Find("Inventory Manager").GetComponent<InventoryManager>().Resources;

    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log(rsc[0]);

        woodnr.text = rsc[0].ToString();
    }
}
