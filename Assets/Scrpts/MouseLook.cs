using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private Transform cameraTrasform;
    [SerializeField] private Transform chraacterTransform;
    private Vector3 cameraRotation;
    public float MouseSensitivity;
    public Vector2 MaxinAngle;

    private void Start()
    {
        cameraTrasform = transform;
    }

    private void Update()
    {
        
        var tmp_MouseX = Input.GetAxis("Mouse X");
        var tmp_MouseY = Input.GetAxis("Mouse Y");

        cameraRotation.x -= tmp_MouseY * MouseSensitivity;
        cameraRotation.y += tmp_MouseX * MouseSensitivity;  

       cameraRotation.x = Mathf.Clamp(cameraRotation.x, MaxinAngle.x, MaxinAngle.y);

        cameraTrasform.rotation = Quaternion.Euler(cameraRotation.x, cameraRotation.y, 0);
        chraacterTransform.rotation = Quaternion.Euler(0,cameraRotation.y, 0);
    }
}
