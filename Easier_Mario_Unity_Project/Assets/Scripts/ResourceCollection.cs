using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCollection : MonoBehaviour
{
    private bool Interactable = false;
    private InventoryManager InvManager;
    private PlayerControls pInput;

    public string HarvestableResource;
    public int MaxResourceCount;
    public int CurrentResourceCount;

    private void Awake()
    {
        pInput = new PlayerControls();
        pInput.GameplayControls.Interact.performed += _ => Collect();
    }

    private void OnEnable()
    {
        pInput.GameplayControls.Enable();
    }

    private void OnDisable()
    {
        pInput.GameplayControls.Disable();
    }

    private void Start()
    {
        InvManager = FindObjectOfType<InventoryManager>().GetComponent<InventoryManager>();
        CurrentResourceCount = MaxResourceCount;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Interactable = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if(col.tag == "Player")
        {
            Interactable = false;
        }
    }

    private void Collect()
    {
        if(Interactable == true)
        {
            if (CurrentResourceCount != 0)
            {
                for (int i = 0; i < InvManager.Resources.Count; i++)
                {
                    if (HarvestableResource == InvManager.Resources[i].ResourceName)
                    {
                        if (InvManager.Resources[i].CurrentResourceValue + 1 != InvManager.Resources[i].MaxResourceValue)
                        {
                            InvManager.Resources[i].CurrentResourceValue++;
                            CurrentResourceCount--;
                        }
                    }
                }
            }
        }
    }
}
