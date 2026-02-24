using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //References
    private PlayerInputActions inputActions;
    [SerializeField] private Transform cameraTransform;
    private Rigidbody rb;
    
    //Variables
    [SerializeField] private float pitch;
    [SerializeField] private float yaw;
    [SerializeField] private float sensitivity = 0.1f;
    [SerializeField] private float speed = 5f;
    private Vector3 newPosition;

    void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.Player.Enable();

        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        //CAMERA MOVING
        Vector2 lookInput = inputActions.Player.Look.ReadValue<Vector2>();

        //Camera we move just the camera vertically
        pitch -= lookInput.y * sensitivity;
        pitch = Mathf.Clamp(pitch, -80f, 80f);
        cameraTransform.localRotation = Quaternion.Euler(pitch, 0, 0);

        //Player we move the player horizontaly
        yaw += lookInput.x * sensitivity;
    }

    void FixedUpdate()
    {
        //CAMERA MOVING
        //we use yaw that was calculated in update
        rb.MoveRotation(Quaternion.Euler(0, yaw, 0));

        //PLAYER MOVING
        Vector2 moveInput = inputActions.Player.Move.ReadValue<Vector2>();

        //Moving player is a lot 
        Vector3 moveDirection = transform.forward * moveInput.y + transform.right * moveInput.x;
        newPosition = rb.position + moveDirection * speed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }
}
