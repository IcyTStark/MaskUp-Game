using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FleeFromLocation : MonoBehaviour
{
//    [SerializeField] GameObject spikeBoyMask;
//    [SerializeField] GameObject popGirlMask;
//    [SerializeField] GameObject decentManMask;
//    [SerializeField] GameObject beardoManMask;
    //[SerializeField] GameObject spikeBoyMouthPosition;
    //[SerializeField] GameObject popGirlMouthPosition;
    //GameObject[] agents;
    void Start()
    {
        //agents = GameObject.FindGameObjectsWithTag("Masked");
        //spikeBoyMask.SetActive(false);
        //popGirlMask.SetActive(false);
        //decentManMask.SetActive(false);
        //beardoManMask.SetActive(false);
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