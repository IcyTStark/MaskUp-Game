using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImposterAffector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Masked")
        {
            Destroy(other.GetComponent<AIController>());
            other.gameObject.AddComponent<ImposterController>();
            other.GetComponent<MaskStatus>().ToggleUnMask(2);
            other.GetComponent<MaskStatus>().ToggleImposter(1);
        }
        if (other.gameObject.tag == "UnMasked")
        {
            Destroy(other.GetComponent<UnMaskedController>());
            other.gameObject.AddComponent<ImposterController>();
            other.GetComponent<MaskStatus>().ToggleImposter(1);
        }
    }
}
