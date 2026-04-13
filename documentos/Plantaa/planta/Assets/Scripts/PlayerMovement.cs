using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;           // Velocidade de andar
    public float runSpeed = 8f;        // Velocidade de correr (Shift)
    public float mouseSensitivity = 2f;

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;     // Trava o mouse na tela
        Cursor.visible = false;
    }

    void Update()
    {
        // === MOVIMENTO ===
        float moveSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : speed;

        float horizontal = Input.GetAxis("Horizontal");   // A e D
        float vertical = Input.GetAxis("Vertical");     // W e S

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        if (controller.isGrounded)
        {
            moveDirection = (forward * vertical + right * horizontal) * moveSpeed;
            moveDirection.y = -1f; // mantém no chão
        }
        else
        {
            moveDirection.y -= 20f * Time.deltaTime;
        }

        controller.Move(moveDirection * Time.deltaTime);

        // === OLHAR COM O MOUSE ===
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(0, mouseX, 0);

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -80f, 80f);

        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }
}
