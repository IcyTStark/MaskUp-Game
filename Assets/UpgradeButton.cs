using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    //[SerializeField]
    GameObject UnMaskedAffector;
    //GameObject SickAffector;
    //GameObject DoctorAffector;
    //GameObject ImposterAffector;

    void Start()
    {
        UnMaskedAffector =  Resources.Load("Affectors / UnMaskedAffector") as GameObject;
        //SickAffector =  Resources.Load("Affectors / SickAffector") as GameObject;
        //DoctorAffector = Resources.Load("Affectors / DoctorAffector") as GameObject;
        //ImposterAffector = Resources.Load("Affectors / ImposterAffector") as GameObject;

    }
    void Update()
    {
        UpgradeUnMasked();
    }

    public void UpgradeUnMasked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UnMaskedAffector.transform.localScale = new Vector3(UnMaskedAffector.transform.localScale.x + 0.25f,
                                                                UnMaskedAffector.transform.localScale.y + 0.25f,
                                                                UnMaskedAffector.transform.localScale.z + 0.25f);
        }
    }
}
