using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController3D : MonoBehaviour
{
    [Header("Movement")]
    public float walkSpeed = 6f;
    public float runSpeed = 9f;
    public float jumpHeight = 1.5f;

    [Header("Look")]
    public Transform cameraPivot;     // empty child at head height
    public Camera playerCamera;       // child of cameraPivot
    public float mouseSensitivity = 120f;
    public float pitchClamp = 85f;

    [Header("Physics")]
    public float gravity = -30f;

    CharacterController controller;
    Vector3 velocity;
    float pitch;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Safety: ensure hierarchy and zeroed camera
        if (playerCamera && cameraPivot && playerCamera.transform.parent != cameraPivot)
            playerCamera.transform.SetParent(cameraPivot, worldPositionStays: false);
        if (playerCamera) playerCamera.transform.localPosition = Vector3.zero;
        if (playerCamera) playerCamera.transform.localRotation = Quaternion.identity;
    }

    void Update()
    {
        Look();
        Move();
    }

    void Look()
    {
        float mx = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float my = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Yaw on body (around world up)
        transform.rotation = Quaternion.AngleAxis(mx, Vector3.up) * transform.rotation;

        // Pitch on pivot only
        pitch = Mathf.Clamp(pitch - my, -pitchClamp, pitchClamp);
        if (cameraPivot) cameraPivot.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }

    void Move()
    {
        bool grounded = controller.isGrounded;
        if (grounded && velocity.y < 0f) velocity.y = -2f;

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 input = Vector3.ClampMagnitude(new Vector3(h, 0f, v), 1f);

        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        Vector3 worldMove = transform.TransformDirection(input) * speed;
        controller.Move(worldMove * Time.deltaTime);

        if (grounded && Input.GetButtonDown("Jump"))
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
