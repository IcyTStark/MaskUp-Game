using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImposterAffector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Masked")
        {
            other.GetComponent<MaskStatus>().ToggleMask(2);
            other.GetComponent<MaskStatus>().ToggleImposterMask(1);
        }
        if (other.gameObject.tag == "UnMasked")
        {
            other.GetComponent<MaskStatus>().ToggleImposterMask(1);
        }
    }
}
