using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImposterController : AffectorBase
{
    // Start is called before the first frame update
    void Start()
    {
        Setgoals();
    }

    // Update is called once per frame
    void Update()
    {
        StopandWalk();
    }
}
