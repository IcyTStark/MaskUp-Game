using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnMaskedController : AffectorBase
{
    void Start()
    {
        Setgoals();
    }

    void Update()
    {
        StopandWalk();
    }
}
