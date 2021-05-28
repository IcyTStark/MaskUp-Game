using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectivePanning : MonoBehaviour
{
    private Vector3 touchStart;
    [SerializeField] Camera cam;
    float groundZ = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = GetWorldPosition(groundZ);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - GetWorldPosition(groundZ);
            direction.y = 0;
            cam.transform.position += direction;
            Vector3 clampPos = cam.transform.position;
            cam.transform.position = new Vector3(Mathf.Clamp(clampPos.x, -10f, 10f), clampPos.y, clampPos.z);
            clampPos.x = Mathf.Clamp(cam.transform.position.x, -10f, 10f);
            //cam.transform.position = clampPos;
            
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
}

