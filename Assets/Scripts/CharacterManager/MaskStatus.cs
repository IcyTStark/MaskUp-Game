using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskStatus : MonoBehaviour
{
    //1 - true 2 - false
    [SerializeField] GameObject mask;
    [SerializeField] GameObject imposterMask;
    GameObject cleanCharacter;
    GameObject sickCharacter;
    [SerializeField] GameObject SickBubble;
    [SerializeField] GameObject ImposterBubble;
    [SerializeField] GameObject UnMaskedBubble;

    // Start is called before the first frame update
    public void ToggleUnMask(int state)
    {
        switch(state)
        {
            case 1:
                mask.SetActive(false);
                gameObject.tag = "UnMasked"; //For Affector
                GameObject umbub = Instantiate(UnMaskedBubble, gameObject.transform.position + new Vector3(1f, 1.7f, 0), Quaternion.identity);
                Destroy(umbub, 1f);
                break;
            case 2:
                mask.SetActive(true);
                gameObject.tag = "Masked"; //For Click
                break;
        }
    }

    public void ToggleImposter(int state)
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
                break;
           
        }
    }

    public void ToggleSickPeople(int state)
    {
        switch(state)
        {
            case 1: //For Affector
                Destroy(gameObject);//.SetActive(false);
                FindObjectOfType<CharacterManager>().characters.Remove(gameObject);
                CharacterManager.Instance.sickCharacters.Remove(gameObject);
                sickCharacter = Resources.Load("SickDecent") as GameObject;
                Instantiate(sickCharacter, gameObject.transform.position, gameObject.transform.rotation);
                //gameObject.tag = "Sick";
                GameObject sbub = Instantiate(SickBubble, gameObject.transform.position + new Vector3(1f, 1.7f, 0), Quaternion.identity);
                Destroy(sbub, 1f);
                break;
            case 2: //For Click
                //gameObject.SetActive(false);
                Destroy(gameObject);
                FindObjectOfType<CharacterManager>().characters.Remove(gameObject);
                CharacterManager.Instance.maskedCharacters.Remove(gameObject);
                cleanCharacter = Resources.Load("DecentMan")as GameObject;
                Instantiate(cleanCharacter, gameObject.transform.position, gameObject.transform.rotation);
                //gameObject.tag = "Masked";
                break;
            
        }
    }
}
