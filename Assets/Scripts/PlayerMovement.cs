using UnityEngine;

public class PlayerMovementWithMouseLook : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;

    public Camera playerCamera;
    private float rotationX = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Assume the Camera is a child of the player GameObject
        //playerCamera = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        // Player movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 moveAmount = moveDirection * moveSpeed * Time.deltaTime;

        // Move the player
        transform.Translate(moveAmount);

        // Camera rotation with mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        rotationX -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        // Rotate the player GameObject (left and right)
        transform.Rotate(Vector3.up * mouseX);

        // Rotate the Camera (up and down)
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        // Lock y-axis rotation for the player

        transform.localRotation = Quaternion.Euler(0f, transform.localRotation.eulerAngles.y, 0f);

    }
}
