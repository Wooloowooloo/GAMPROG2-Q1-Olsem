using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private bool cursorLocked = true;
    private float xRotation = 0f;

    public Camera cam;
    [Range(1.0f, 100.0f)] public float rotationSensitivity = 69.0f;
    public float rotationLimit = 30.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ProcessLook(Vector2 input)
    {
        if (cursorLocked)
        {
            float mouseX = input.x;
            float mouseY = input.y;

            xRotation -= (mouseY * Time.deltaTime) * (rotationSensitivity / 10.0f);
            xRotation = Mathf.Clamp(xRotation, -rotationLimit, rotationLimit);

            cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * (rotationSensitivity / 10.0f));
        }
        else
        {
            return;
        }
    }

    public void ToggleCursorLock()
    {
        cursorLocked = !cursorLocked;

        if(cursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
