using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private float mouseSensetivity = 100f;

    private float mouseX = 0.0f;
    private float mouseY = 0.0f;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        mouseX += mouseSensetivity * Input.GetAxis("Mouse X") * Time.deltaTime;
        mouseY -= mouseSensetivity * Input.GetAxis("Mouse Y") * Time.deltaTime;

        mouseX = Mathf.Clamp(mouseX, -180f, 0f);
        mouseY = Mathf.Clamp(mouseY, -30f, 60f);

        transform.eulerAngles = new Vector3(mouseY, mouseX, 0f);


    }
}
