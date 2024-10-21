using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 cameraView; // The direction of the camera
    public float lookSpeed; // The speed of the camera movement
    public float cameraLock; // The maximum rotation the camera can move in the up and down movement
    private float cameraPauseTimer; // The time the camera will be locked at the beginning because of the built up in camera view when starting the game
    public float maxScroll; // The farthest the camera can be from the player in the z direction
    public Transform playerTransform; // The player transform

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the mouse to the center of the screen
        //Cursor.visible = false; // Hide the cursor
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
        UpdateCameraPosition();
        Debug.DrawRay(transform.position, transform.forward * 10, Color.black);
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
    }

    // Function to get the change camera z index position based on mouse scroll
    private Vector3 MouseScroll()
    {
        float z = Input.GetAxis("Mouse ScrollWheel"); // Get the input scroll wheel
        z *= Time.deltaTime * 500f;
        Vector3 cameraPosChange = new Vector3(0, 0, z);
        return cameraPosChange;
    }

    // Function to update the z index of the camera
    private void UpdateCameraPosition()
    {
        transform.localPosition += MouseScroll(); // Update the z position of the camera
        // Clamp to 0 if z is greater than 0
        if (transform.localPosition.z > 0)
        {
            transform.localPosition = new Vector3(0, transform.localPosition.y, 0);
        }
        // Clamp to max scroll if it reach beyond the max scroll
        else if (transform.localPosition.z < maxScroll)
        {
            transform.localPosition = new Vector3(0, transform.localPosition.y, maxScroll);
        }
    }
}
