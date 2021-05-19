using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TouchManager : MonoBehaviour
{
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.transform.gameObject.tag == "UnMasked")
                {
                    hitInfo.transform.gameObject.GetComponent<MaskStatus>().ToggleMask(true);
                }
                if(hitInfo.transform.gameObject.tag == "Imposter")
                {
                    hitInfo.transform.gameObject.GetComponent<MaskStatus>().ToggleImposterMask(false);
                    hitInfo.transform.gameObject.GetComponent<MaskStatus>().ToggleMask(true);
                }
            }
        }
        
       
    }
    
}


//void residue()
//{
//if (Physics.Raycast(ray,out hitInfo))
//{
//    Debug.Log("Hi I am " + hitInfo.transform.name + " and I am "+ hitInfo.transform.tag);
//}
//    //if(hitInfo.transform != null)
//    //{
//    //    PrintName(hitInfo.transform.gameObject);
//    //}
//    if (hitInfo.transform.gameObject.tag == "Masked")
//    {
//        Debug.Log("Im Masked");
//    }
//    if (hitInfo.transform.gameObject.tag == "UnMasked")
//    {
//        Debug.Log("Im Unmasked");
//        //Instantiate(unMasked, hitInfo.point, unMasked.transform.rotation);
//        foreach (GameObject a in agents)
//        {
//            a.GetComponent<AIController>().DetectNewObstacle(hitInfo.point);
//        }
//    }

//    //Instantiate(unMasked, hitInfo.point, unMasked.transform.rotation);
//    //foreach(GameObject a in agents)
//    //{
//    //    a.GetComponent<AIController>().DetectNewObstacle(hitInfo.point);
//    //}
//}