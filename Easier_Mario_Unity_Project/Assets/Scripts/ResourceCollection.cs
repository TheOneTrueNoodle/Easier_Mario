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

    private Animator PlayerAnim;
    public Animator ThisAnim;

    private bool StartGrowing;
    public float MaxGrowTime;
    public float MinGrowTime;
    private float GrowTime;

    public bool CanRegrow;

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
        PlayerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        CurrentResourceCount = MaxResourceCount;
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            col.GetComponentInChildren<InputPrompt>().ShowDisplay();
        }
    }

    private void FixedUpdate()
    {
        if(StartGrowing == true)
        {
            GrowTime--;
            if (GrowTime <= 0)
            {
                ThisAnim.Play("TreeGrowAnimation");
                StartGrowing = false;
                CurrentResourceCount = MaxResourceCount;
            }
        }
    }

    //Detect Player Nearby
    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player" && col.GetComponent<Third_Person_Movement>().isGrounded == true)
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
        col.GetComponentInChildren<InputPrompt>().HideDisplay();
    }

    //Trigger Collection
    private void Collect()
    {
        if (PlayerAnim.GetCurrentAnimatorStateInfo(0).IsName("CharacterArmature|Punch") != true)
        {
            if (Interactable == true)
            {
                if (CurrentResourceCount != 0)
                {
                    for (int i = 0; i < InvManager.Resources.Count; i++)
                    {
                        if (HarvestableResource == InvManager.Resources[i].ResourceName)
                        {
                            if (InvManager.Resources[i].CurrentResourceValue != InvManager.Resources[i].MaxResourceValue)
                            {
                                FindObjectOfType<AudioManager>().Play("HittingTree");
                                PlayerAnim.Play("CharacterArmature|Punch");
                                InvManager.Resources[i].CurrentResourceValue++;
                                CurrentResourceCount--;
                                if (CurrentResourceCount > 0)
                                {
                                    ThisAnim.Play("TreeInteractAnimation");
                                }
                                else if (CurrentResourceCount == 0 && CanRegrow == true)
                                {
                                    ThisAnim.Play("TreeUsedUpAnimation");
                                    StartGrowing = true;
                                    GrowTime = Random.Range(MinGrowTime, MaxGrowTime);
                                }
                                else if (CurrentResourceCount == 0 && CanRegrow)
                                {
                                    ThisAnim.Play("TreeUsedUpAnimation");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
