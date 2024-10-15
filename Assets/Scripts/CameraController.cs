using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 myLook;
    float lookSpeed = 1000f;
    public Camera myCamera;
    public float cameraLock = 180f;
    public float startTimer;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the mouse to the center of the screen
        Cursor.visible = false;
        myLook = transform.localEulerAngles;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
        startTimer += Time.deltaTime;
        myLook += DeltaLook() * lookSpeed * Time.deltaTime;
        myLook.y = Mathf.Clamp(myLook.y, -cameraLock, cameraLock);
        transform.rotation = Quaternion.Euler(0f, myLook.x, 0f);
        myCamera.transform.rotation = Quaternion.Euler(-myLook.y, myLook.x, 0f);
        if (startTimer < 1)
        {
            myLook = Vector3.ClampMagnitude(myLook, startTimer);
        }
        Debug.DrawRay(myCamera.transform.position, myCamera.transform.forward * 10, Color.black);
    }

    public Vector3 DeltaLook()
    {
        float rotationX = Input.GetAxisRaw("Mouse X");
        float rotationY = Input.GetAxisRaw("Mouse Y");
        Vector3 delta = new Vector3 (rotationX, rotationY, 0);
        return delta;
    }
}
