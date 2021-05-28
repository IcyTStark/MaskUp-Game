using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoctorAffector : MonoBehaviour
{
    [SerializeField] GameObject HealthyBubble;
    private void Start()
    {
        HealthyBubble = Resources.Load("DecentManBubble") as GameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "UnMasked")
        {
            other.GetComponent<MaskStatus>().ToggleUnMask(2);
            StartCoroutine(UMWalkAgain());
        }
        if (other.gameObject.tag == "Imposter")
        {
            other.GetComponent<MaskStatus>().ToggleImposter(2);
            other.GetComponent<MaskStatus>().ToggleUnMask(2);
            StartCoroutine(IWalkAgain());
        }
        if(other.gameObject.tag == "Sick")
        {
            other.GetComponent<MaskStatus>().ToggleSickPeople(2);
            StartCoroutine(SWalkAgain());
        }
        IEnumerator UMWalkAgain()
        {
            Destroy(other.gameObject.GetComponent<UnMaskedController>());
            other.gameObject.GetComponent<NavMeshAgent>().speed = 0;
            GameObject mbub = Instantiate(HealthyBubble, other.gameObject.transform.position + new Vector3(1f, 1.7f, 0), Quaternion.identity);
            Destroy(mbub, 1f);
            yield return new WaitForSeconds(2f);
            other.gameObject.AddComponent<AIController>();
            other.gameObject.GetComponent<NavMeshAgent>().speed = 2;
        }

        IEnumerator IWalkAgain()
        {
            other.gameObject.GetComponent<NavMeshAgent>().speed = 0;
            Destroy(other.GetComponent<ImposterController>());
            Destroy(other.GetComponent<UnMaskedController>());
            GameObject mbub = Instantiate(HealthyBubble, other.gameObject.transform.position + new Vector3(1f, 1.7f, 0), Quaternion.identity);
            Destroy(mbub, 1f);
            yield return new WaitForSeconds(2f);
            other.gameObject.AddComponent<AIController>();
            other.gameObject.GetComponent<NavMeshAgent>().speed = 2;
        }

        IEnumerator SWalkAgain()
        {
            other.gameObject.GetComponent<NavMeshAgent>().speed = 0;
            GameObject mbub = Instantiate(HealthyBubble, other.gameObject.transform.position + new Vector3(1f, 1.7f, 0), Quaternion.identity);
            Destroy(mbub, 1f);
            yield return new WaitForSeconds(2f);
            other.gameObject.GetComponent<NavMeshAgent>().speed = 2;
        }
    }
}
