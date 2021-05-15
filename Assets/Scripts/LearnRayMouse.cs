using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnRayMouse : MonoBehaviour
{
    public bool zooming;
    public float zoomSpeed;
    public Camera gameCamera;

    void Update()
    {
        if (zooming)
        {
            Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
            float zoomDistance = zoomSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
            gameCamera.transform.Translate(ray.direction * zoomDistance, Space.World);
        }
    }
}
