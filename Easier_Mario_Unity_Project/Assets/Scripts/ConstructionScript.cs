using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConstructionScript : MonoBehaviour
{
    public GameObject BuiltObj;
    public string NeededResource;
    public int NeededResourceAmount;
    public int CurrentResourceAmount;

    private bool Interactable = false;
    private InventoryManager InvManager;
    private PlayerControls pInput;

    private Animator PlayerAnim;

    public TMP_Text RequiredResources;
    public GameObject Canvas;

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
        PlayerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        CurrentResourceAmount = 0;
    }

    private void Update()
    {
        RequiredResources.text = CurrentResourceAmount + "/" + NeededResourceAmount;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Interactable = true;
            Canvas.SetActive(true);
            col.GetComponentInChildren<InputPrompt>().ShowDisplay();
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            Interactable = false;
            Canvas.SetActive(false);
            col.GetComponentInChildren<InputPrompt>().HideDisplay();
        }
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
                        
                        FindObjectOfType<AudioManager>().Play("BuildingBridge");
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
        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<InputPrompt>().HideDisplay();
        Destroy(gameObject);
    }
}
