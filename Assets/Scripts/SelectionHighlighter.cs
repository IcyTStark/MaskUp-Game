using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionHighlighter : MonoBehaviour
{
    MeshRenderer renderer;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        
    }
    private void OnMouseEnter()
    {
        renderer.material.color = Color.red;
    }
    private void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }
}
