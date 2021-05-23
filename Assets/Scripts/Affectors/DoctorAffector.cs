using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorAffector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "UnMasked")
        {
            other.GetComponent<MaskStatus>().ToggleMask(1);
        }
        if (other.gameObject.tag == "Imposter")
        {
            other.GetComponent<MaskStatus>().ToggleImposterMask(2);
            other.GetComponent<MaskStatus>().ToggleMask(1);
        }
        if(other.gameObject.tag == "Sick")
        {
            other.GetComponent<MaskStatus>().ToggleSickPeople(2);
        }
    }
}
