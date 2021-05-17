using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImposterAffector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Masked")
        {
            other.GetComponent<MaskStatus>().ToggleMask(false);
            other.GetComponent<MaskStatus>().ToggleImposterMask(true);
        }
    }
}
