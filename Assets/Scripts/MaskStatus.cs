using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskStatus : MonoBehaviour
{

    public GameObject mask;
    // Start is called before the first frame update

    public void ToggleMask(bool state)
    {
        mask.SetActive(state);
        gameObject.tag = state ? "Masked" : "UnMasked";

    }
}
