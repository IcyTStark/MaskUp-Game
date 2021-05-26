using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TouchManager : MonoBehaviour
{
    NavMeshAgent agent;
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
                    hitInfo.transform.gameObject.GetComponent<MaskStatus>().ToggleMask(1);
                    //hitInfo.transform.gameObject.GetComponent<NavMeshAgent>().speed = 0;
                    //StartCoroutine(WalkAgainn());
                }
                if (hitInfo.transform.gameObject.tag == "Imposter")
                {
                    hitInfo.transform.gameObject.GetComponent<MaskStatus>().ToggleImposterMask(2);
                    hitInfo.transform.gameObject.GetComponent<MaskStatus>().ToggleMask(1);
                    Destroy(hitInfo.transform.gameObject.GetComponent<ImposterController>());

                    //hitInfo.transform.gameObject.GetComponent<ImposterController>().enabled = false;
                    Debug.Log("I'M Disabled");
                    hitInfo.transform.gameObject.AddComponent<AIController>();
                    hitInfo.transform.gameObject.GetComponent<MaskStatus>().ToggleImposterMask(2);
                    //hitInfo.transform.gameObject.GetComponent<NavMeshAgent>().speed = 0;
                    //hitInfo.transform.gameObject.GetComponent<MaskStatus>().ToggleMask(1);
                    //hitInfo.transform.gameObject.GetComponent<NavMeshAgent>().speed = 0;
                    //StartCoroutine(WalkAgainn());
                }
                if (hitInfo.transform.gameObject.tag == "Sick")
                {
                    hitInfo.transform.gameObject.GetComponent<MaskStatus>().ToggleSickPeople(2);
                    //hitInfo.transform.gameObject.GetComponent<NavMeshAgent>().speed = 0;
                    //StartCoroutine(WalkAgainn());
                }
            }
           
            //IEnumerator WalkAgainn()
            //{
            //    hitInfo.transform.gameObject.GetComponent<AffectorBase>().ResetAgent();
            //    yield return new WaitForSeconds(2f * Time.deltaTime);
            //}
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