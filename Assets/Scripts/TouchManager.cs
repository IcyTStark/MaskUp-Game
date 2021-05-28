using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TouchManager : MonoBehaviour
{
    [SerializeField] GameObject HealthyBubble;
    private void Start()
    {
        HealthyBubble = Resources.Load("DecentManBubble") as GameObject;
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
                    hitInfo.transform.gameObject.GetComponent<MaskStatus>().ToggleUnMask(2);
                    StartCoroutine(UMWalkAgain());
                }
                if (hitInfo.transform.gameObject.tag == "Imposter")
                {
                    hitInfo.transform.gameObject.GetComponent<MaskStatus>().ToggleImposter(2);
                    hitInfo.transform.gameObject.GetComponent<MaskStatus>().ToggleUnMask(2);
                    StartCoroutine(IWalkAgain());
                }
                if (hitInfo.transform.gameObject.tag == "Sick")
                {
                    hitInfo.transform.gameObject.GetComponent<MaskStatus>().ToggleSickPeople(2);
                    StartCoroutine(SWalkAgain());
                }
            }

            IEnumerator UMWalkAgain()
            {
                Destroy(hitInfo.transform.gameObject.GetComponent<UnMaskedController>());
                hitInfo.transform.gameObject.GetComponent<NavMeshAgent>().speed = 0;
                GameObject mbub = Instantiate(HealthyBubble, hitInfo.transform.gameObject.transform.position + new Vector3(1f, 1.7f, 0), Quaternion.identity);
                Destroy(mbub, 1f);
                yield return new WaitForSeconds(2f);
                hitInfo.transform.gameObject.AddComponent<AIController>();
                hitInfo.transform.gameObject.GetComponent<NavMeshAgent>().speed = 2;
            }
            
            IEnumerator IWalkAgain()
            {
                hitInfo.transform.gameObject.GetComponent<NavMeshAgent>().speed = 0;
                Destroy(hitInfo.transform.GetComponent<ImposterController>());
                Destroy(hitInfo.transform.GetComponent<UnMaskedController>());
                GameObject mbub = Instantiate(HealthyBubble, hitInfo.transform.gameObject.transform.position + new Vector3(1f, 1.7f, 0), Quaternion.identity);
                Destroy(mbub, 1f);
                yield return new WaitForSeconds(2f);
                hitInfo.transform.gameObject.AddComponent<AIController>();
                hitInfo.transform.gameObject.GetComponent<NavMeshAgent>().speed = 2;
            }
            
            IEnumerator SWalkAgain()
            {
                hitInfo.transform.gameObject.GetComponent<NavMeshAgent>().speed = 0;
                GameObject mbub = Instantiate(HealthyBubble, hitInfo.transform.gameObject.transform.position + new Vector3(1f, 1.7f, 0), Quaternion.identity);
                Destroy(mbub, 1f);
                yield return new WaitForSeconds(2f);
                hitInfo.transform.gameObject.GetComponent<NavMeshAgent>().speed = 2;
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