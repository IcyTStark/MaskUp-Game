using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffectScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Masked")
        {
            Debug.Log("Im working brother");
            other.gameObject.GetComponent<MaskStatus>().ToggleMask(false);
        }
    }
    //{
        
    //}
}
