using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanning : MonoBehaviour
{
    private Vector3 touchStart;
    public Camera cam;
    public float groundZ = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }
        if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += direction;
        }
    }

    private Vector3 GetWorldPosition(float z)
    {
        Ray mousePos = cam.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        ground.Raycast(mousePos, out distance);
        return mousePos.GetPoint(distance);
    }

    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        touchStart = GetWorldPosition(groundZ);
    //    }
    //    if (Input.GetMouseButton(0))
    //    {
    //        Vector3 direction = touchStart - GetWorldPosition(groundZ);
    //        cam.transform.position += direction;
    //    }
    //}
    //private Vector3 GetWorldPosition(float z)
    //{
    //    Ray mousePos = cam.ScreenPointToRay(Input.mousePosition);
    //    Plane ground = new Plane(Vector3.forward, new Vector3(0, 0, z));
    //    float distance;
    //    ground.Raycast(mousePos, out distance);
    //    return mousePos.GetPoint(distance);
    //}
}

