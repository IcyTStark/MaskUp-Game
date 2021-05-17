using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorAffector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "UnMasked")
        {
            other.GetComponent<MaskStatus>().ToggleMask(true);
        }
        if(other.gameObject.tag == "Imposter")
        {
            other.GetComponent<MaskStatus>().ToggleImposterMask(false);
            other.GetComponent<MaskStatus>().ToggleMask(true);
        }
    }
}
