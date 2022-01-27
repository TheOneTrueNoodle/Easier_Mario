using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Third_Person_Movement : MonoBehaviour
{
    //Variables for Controls
    private PlayerControls pInput;
    public CharacterController controller;
    public Transform cam;

    //Variables for Animations
    public Animator Anim;

    //Variables for movement values
    public float walkspeed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    //Variables for ground registration
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    //Variables for applying movement
    private Vector2 MoveInput;
    private Vector3 moveDir;
    [HideInInspector] public Vector3 velocity;
    [HideInInspector] public bool isGrounded;

    //Variables for turning character body
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    private void Awake()
    {
        pInput = new PlayerControls();
        pInput.GameplayControls.Jump.performed += _ => Jump();
    }

    private void OnEnable()
    {
        pInput.GameplayControls.Enable();
    }

    private void OnDisable()
    {
        pInput.GameplayControls.Disable();
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        MoveInput = pInput.GameplayControls.Move.ReadValue<Vector2>();
        Vector3 Direction = new Vector3(MoveInput.x, 0f, MoveInput.y).normalized;

        if (Direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * (walkspeed * Time.deltaTime));
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Jump()
    {
        if (isGrounded == true)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
