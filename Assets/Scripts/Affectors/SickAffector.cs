using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SickAffector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Imposter" || other.gameObject.tag == "UnMasked")
        {
            //other.GetComponent<MaskStatus>().ToggleImposterMask(false);
            other.GetComponent<MaskStatus>().ToggleSickPeople(1);
        }
        //if (other.gameObject.tag == "UnMasked")
        //{
        //    other.GetComponent<MaskStatus>().ToggleSickPeople(1);
        //}
    }
}
