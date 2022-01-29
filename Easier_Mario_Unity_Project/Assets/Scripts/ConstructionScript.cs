using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionScript : MonoBehaviour
{
    public GameObject BuiltObj;
    public string NeededResource;
    public int NeededResourceAmount;
    public int CurrentResourceAmount;

    private bool Interactable = false;
    private InventoryManager InvManager;
    private PlayerControls pInput;

    public Animator PlayerAnim;

    private void Awake()
    {
        pInput = new PlayerControls();
        pInput.GameplayControls.Interact.performed += _ => Build();
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
        CurrentResourceAmount = 0;
    }
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
        if (col.tag == "Player")
        {
            Interactable = false;
        }
        col.GetComponentInChildren<ChangeInputPrompt>().HideDisplay();
    }

    private void Build()
    {

        if (PlayerAnim.GetCurrentAnimatorStateInfo(0).IsName("CharacterArmature|Punch") != true)
        {
            if (Interactable == true)
            {
                for (int i = 0; i < InvManager.Resources.Count; i++)
                {
                    if (InvManager.Resources[i].ResourceName == NeededResource && InvManager.Resources[i].CurrentResourceValue > 0)
                    {
                        PlayerAnim.Play("CharacterArmature|Punch");
                        CurrentResourceAmount++;
                        InvManager.Resources[i].CurrentResourceValue--;
                        if (CurrentResourceAmount == NeededResourceAmount)
                        {
                            ConstructObject();
                        }
                    }
                }
            }
        }
    }

    private void ConstructObject()
    {
        GameObject NewObj = Instantiate(BuiltObj, transform.position, transform.rotation);
        NewObj.transform.localScale = gameObject.transform.localScale;
        Destroy(gameObject);
    }
}
