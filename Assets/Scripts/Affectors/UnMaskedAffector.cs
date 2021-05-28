using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnMaskedAffector : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Masked")
        {
            Destroy(other.GetComponent<AIController>());
            other.gameObject.AddComponent<UnMaskedController>();
            other.GetComponent<MaskStatus>().ToggleUnMask(1);
        }
    }
}
