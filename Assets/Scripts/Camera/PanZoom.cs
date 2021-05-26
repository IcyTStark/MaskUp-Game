using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanZoom : MonoBehaviour
{
    [SerializeField] float dragSpeed = -0.5f;
    Vector3 dragOrigin;

    bool cameraDragging = false;

    float outerLeft = -10f;
    float outerRight = 10f;

    [SerializeField] float leftMaxClamp;
    [SerializeField] float rightMaxClamp;
    
    Vector3 dir;

    [SerializeField] Camera cam;
    Transform trans;

    void Start()
    {
        trans = this.transform;
        Clamp();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            cameraDragging = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            cameraDragging = false;
        }
        if (cameraDragging)
        {
            dir = cam.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
            Vector3 pos = trans.position;
            pos += (trans.right * dir.x) * dragSpeed;
            pos.x = Mathf.Clamp(pos.x, outerLeft, outerRight);
            trans.position = pos;
            
        }
    }

    void Clamp()
    {
        outerLeft = Mathf.Clamp(outerLeft, leftMaxClamp, 0);
        outerRight = Mathf.Clamp(outerRight, 0, rightMaxClamp);
    }

}