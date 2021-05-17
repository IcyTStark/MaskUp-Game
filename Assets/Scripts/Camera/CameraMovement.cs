using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float cameraSpeed;
    void Start()
    {
        
    }

   
    void Update()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal") * cameraSpeed * Time.deltaTime;
        var verticalInput = Input.GetAxisRaw("Vertical") * cameraSpeed *Time.deltaTime;
        transform.Translate(horizontalInput, 0f, verticalInput);
    }
}
