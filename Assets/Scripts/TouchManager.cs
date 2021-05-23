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
                Debug.DrawLine(ray.origin, hitInfo.point);
                Debug.LogError("Raycast Hit" + hitInfo.collider.name);
                //GameObject go = Instantiate(GameObject.CreatePrimitive(PrimitiveType.Sphere));
                //go.transform.position = hitInfo.point;
                if (hitInfo.transform.gameObject.tag == "UnMasked")
                {
                    hitInfo.transform.gameObject.GetComponent<MaskStatus>().ToggleMask(1);
                }
                if (hitInfo.transform.gameObject.tag == "Imposter")
                {
                    hitInfo.transform.gameObject.GetComponent<MaskStatus>().ToggleImposterMask(2);
                    hitInfo.transform.gameObject.GetComponent<MaskStatus>().ToggleMask(1);
                }
                if (hitInfo.transform.gameObject.tag == "Sick")
                {
                    Debug.Log("Yo,stop poking me");
                    hitInfo.transform.gameObject.GetComponent<MaskStatus>().ToggleSickPeople(2);
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