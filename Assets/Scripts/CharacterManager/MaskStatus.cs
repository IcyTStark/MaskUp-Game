using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskStatus : MonoBehaviour
{
    //1 - true 2 - false
    [SerializeField] GameObject mask;
    [SerializeField] GameObject imposterMask;
    [SerializeField] GameObject cleanCharacter;
    [SerializeField] GameObject sickCharacter;
    [SerializeField] GameObject SickBubble;
    [SerializeField] GameObject HealthyBubble;
    [SerializeField] GameObject ImposterBubble;
    [SerializeField] GameObject UnMaskedBubble;

    // Start is called before the first frame update
    public void ToggleMask(int state)
    {
        switch(state)
        {
            case 1:
                mask.SetActive(true);
                gameObject.tag = "Masked"; //For Click
                GameObject mbub = Instantiate(HealthyBubble, gameObject.transform.position + new Vector3(1f,1.7f,0), Quaternion.identity);
                Destroy(mbub, 1f);
                break;
            case 2:
                mask.SetActive(false);
                gameObject.tag = "UnMasked"; //For Affector
                GameObject umbub = Instantiate(UnMaskedBubble, gameObject.transform.position + new Vector3(1f, 1.7f, 0), Quaternion.identity);
                Destroy(umbub, 1f);
                break;
            
        }
    }

    public void ToggleImposterMask(int state)
    {
        switch(state)
        {
            case 1:
                imposterMask.SetActive(true);
                gameObject.tag = "Imposter"; //For Affector
                GameObject ibub = Instantiate(ImposterBubble, gameObject.transform.position + new Vector3(1f, 1.7f, 0), Quaternion.identity);
                Destroy(ibub, 1f);
                break;
            case 2:
                imposterMask.SetActive(false);
                gameObject.tag = "Masked"; //For Click
                GameObject mbub = Instantiate(HealthyBubble, gameObject.transform.position + new Vector3(1f, 1.7f, 0), Quaternion.identity);
                Destroy(mbub, 1f);
                break;
           
        }
    }

    public void ToggleSickPeople(int state)
    {
        switch(state)
        {
            case 1: //For Affector
                gameObject.SetActive(false);
                FindObjectOfType<CharacterManager>().characters.Remove(gameObject);
                Instantiate(sickCharacter, gameObject.transform.position, gameObject.transform.rotation);
                gameObject.tag = "Sick";
                GameObject sbub = Instantiate(SickBubble, gameObject.transform.position + new Vector3(1f, 1.7f, 0), Quaternion.identity);
                
                Destroy(sbub, 1f);
                break;
            case 2: //For Click
                gameObject.SetActive(false);
                FindObjectOfType<CharacterManager>().characters.Remove(gameObject);
                Instantiate(cleanCharacter, gameObject.transform.position, gameObject.transform.rotation);
                gameObject.tag = "Masked";
                GameObject mbub = Instantiate(HealthyBubble, gameObject.transform.position + new Vector3(1f, 1.7f, 0), Quaternion.identity);
                Destroy(mbub, 1f);
                break;
            
        }
    }
}
