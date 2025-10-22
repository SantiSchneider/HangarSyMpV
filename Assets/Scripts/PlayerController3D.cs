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

    private CharacterController controller;
    private Vector3 velocity; // y component used for gravity/jump
    private float pitch;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

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

        transform.rotation = Quaternion.AngleAxis(mx, Vector3.up) * transform.rotation;

        pitch = Mathf.Clamp(pitch - my, -pitchClamp, pitchClamp);
        if (cameraPivot) cameraPivot.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }

    void Move()
    {
        bool grounded = controller.isGrounded;

        // keep grounded
        if (grounded && velocity.y < 0f)
            velocity.y = -2f;

        // input
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 input = Vector3.ClampMagnitude(new Vector3(h, 0f, v), 1f);

        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        Vector3 worldMove = transform.TransformDirection(input) * speed; // horizontal only

        // jump
        if (grounded && Input.GetButtonDown("Jump"))
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        // gravity
        velocity.y += gravity * Time.deltaTime;

        // single Move so CharacterController.velocity reflects both horizontal and vertical
        Vector3 frameMove = new Vector3(worldMove.x, velocity.y, worldMove.z) * Time.deltaTime;
        controller.Move(frameMove);
    }

    // Optional helper if you need it elsewhere
    public Vector3 HorizontalVelocity =>
        new Vector3(controller.velocity.x, 0f, controller.velocity.z);
}
