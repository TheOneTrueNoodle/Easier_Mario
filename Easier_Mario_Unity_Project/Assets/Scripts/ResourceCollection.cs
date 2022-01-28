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

    public Animator PlayerAnim;

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

    //Detect Player Nearby
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Interactable = true;
        }
        col.GetComponentInChildren<ChangeInputPrompt>().ShowDisplay();
    }
    private void OnTriggerExit(Collider col)
    {
        if(col.tag == "Player")
        {
            Interactable = false;
        }
        col.GetComponentInChildren<ChangeInputPrompt>().HideDisplay();
    }

    //Trigger Collection
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
                            PlayerAnim.SetTrigger("Interact");
                            InvManager.Resources[i].CurrentResourceValue++;
                            CurrentResourceCount--;
                            PlayerAnim.ResetTrigger("Interact");
                        }
                    }
                }
            }
        }
    }
}
