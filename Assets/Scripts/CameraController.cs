using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 cameraView; // The direction of the camera
    public float lookSpeed; // The speed of the camera movement
    public float cameraLock; // The maximum rotation the camera can move in the up and down movement
    private float cameraPauseTimer; // The time the camera will be locked at the beginning because of the built up in camera view when starting the game
    public Transform playerTransform; // The player transform
    public Transform gunTransform; // The gun transform

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the mouse to the center of the screen
        Cursor.visible = false; // Hide the cursor
        cameraView = transform.localEulerAngles; // Make the camera point in the direction of the player
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (cameraPauseTimer < 0.5f)
        {
            cameraView = Vector3.ClampMagnitude(cameraView, cameraPauseTimer); // Reduce the change in camera view
            cameraPauseTimer += Time.deltaTime;
        }
        UpdateRotation();
    }

    // Function to get the change in mouse movement
    private Vector3 DeltaLook()
    {
        float rotationX = Input.GetAxisRaw("Mouse X");
        float rotationY = Input.GetAxisRaw("Mouse Y");
        return new Vector3(rotationX, rotationY, 0) * lookSpeed * Time.deltaTime;
    }

    // Function to update the camera and player rotation
    private void UpdateRotation()
    {
        cameraView += DeltaLook();
        cameraView.y = Mathf.Clamp(cameraView.y, -cameraLock, cameraLock); // Make the camera turn up and down without going over 90 degrees
        playerTransform.rotation = Quaternion.Euler(0f, cameraView.x, 0f); // Rotate the the player
        transform.rotation = Quaternion.Euler(-cameraView.y, cameraView.x, 0f); // Rotate the camera
        gunTransform.localRotation = Quaternion.Euler(0, 90f, 90f - cameraView.y); // Rotate the gun
    }
}
