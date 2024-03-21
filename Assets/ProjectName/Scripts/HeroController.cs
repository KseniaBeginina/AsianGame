using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class HeroController : MonoBehaviour
{
    public float speed = 4f;
    public float sprint = 4f;
    public float currentSpeed;
    public float jump = 10f;
    //public float rotationSpeed = 0.5f;
    public float gravity = 30.0f;
    
    //Camera
    public Transform playerCameraParent;
    public float lookSpeed = 1f;
    public float lookXLimit = 60.0f;

    CharacterController characterController;
    private Animator animator;
    Vector3 moveDirection = Vector3.zero;
    Vector2 rotation = Vector2.zero;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        rotation.y = transform.eulerAngles.y;
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            animator.SetBool("sprint", Input.GetKey(KeyCode.LeftShift));
            if (Input.GetKey(KeyCode.LeftShift))
            {
                currentSpeed = speed + sprint;
            } else {
                currentSpeed = speed;
            }
            animator.SetBool("jump", Input.GetKey(KeyCode.Space));

            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            float curSpeedX = canMove ? currentSpeed * Input.GetAxis("Vertical") : 0;
            float curSpeedY = canMove ? currentSpeed * Input.GetAxis("Horizontal") : 0;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);
           // transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(moveDirection), rotationSpeed);

            // Установка параметра "Speed" в аниматоре
            float moveSpeed = Mathf.Clamp(moveDirection.magnitude / currentSpeed, 0f, 4f);
            animator.SetFloat("speed", moveSpeed);
            animator.SetFloat("currentSpeed", moveSpeed);

            if (Input.GetKeyDown(KeyCode.Space) && canMove)
            {
                moveDirection.y = jump;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            //вращение на мышку
            // rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
            // transform.eulerAngles = new Vector2(0, rotation.y);
            
            //вращение на q e
            if (Input.GetKey(KeyCode.Q))
            {
                rotation.y -= lookSpeed;
                transform.eulerAngles = new Vector2(0, rotation.y);
            }

            if (Input.GetKey(KeyCode.E))
            {
                rotation.y += lookSpeed;
                transform.eulerAngles = new Vector2(0, rotation.y);
            }
        }
    }
}