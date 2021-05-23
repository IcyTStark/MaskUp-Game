using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnMaskedAffector : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Masked")
        {
            other.GetComponent<MaskStatus>().ToggleMask(2);
        }
    }
}
