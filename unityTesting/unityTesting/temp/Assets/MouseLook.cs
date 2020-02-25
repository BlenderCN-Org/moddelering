using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSens = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= mouseY;
        // Avgrenser rotasjon oppover og nedover
        xRotation = Mathf.Clamp(xRotation, -90f, 50f);

        // Roterer kamera langs x-aksen
        transform.localRotation = Quaternion.Euler(xRotation,mouseX,0f);
        // Roterer spiller langs y-aksen
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
