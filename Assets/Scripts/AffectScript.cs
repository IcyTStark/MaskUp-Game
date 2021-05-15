using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffectScript : MonoBehaviour
{
    [Tooltip ("True: Masks them, False: UnMasks them")]
    [SerializeField] bool whatToHappen;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Masked")
        {
            Debug.Log("Im working brother");
            other.gameObject.GetComponent<MaskStatus>().ToggleMask(whatToHappen);
        }
    }
    
}
