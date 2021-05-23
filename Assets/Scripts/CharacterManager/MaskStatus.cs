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

    // Start is called before the first frame update

    //public void ToggleMask(bool state)
    //{
    //    mask.SetActive(state);
    //    gameObject.tag = state ? "Masked" : "UnMasked";

    //}
    //public void ToggleImposterMask(bool state)
    //{
    //    imposterMask.SetActive(state);
    //    gameObject.tag = state ? "Imposter" : "Masked";
    //}

    public void ToggleMask(int state)
    {
        switch(state)
        {
            case 1:
                mask.SetActive(true);
                gameObject.tag = "Masked"; //For Click
                break;
            case 2:
                mask.SetActive(false);
                gameObject.tag = "UnMasked"; //For Affector
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
                break;
            case 2:
                imposterMask.SetActive(false);
                var tempImp = gameObject.GetComponent<ImposterController>();
                Destroy(tempImp);

                gameObject.tag = "Masked"; //For Click
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
                break;
            case 2: //For Click
                gameObject.SetActive(false);
                FindObjectOfType<CharacterManager>().characters.Remove(gameObject);
                Instantiate(cleanCharacter, gameObject.transform.position, gameObject.transform.rotation);
                gameObject.tag = "Masked";
                break;
            
        }
    }
    //public void ToggleSickPeople(bool state)
    //{
    //    if(state == false)
    //    {
    //        Instantiate(cleanCharacter, gameObject.transform.position, gameObject.transform.rotation);
    //        gameObject.SetActive(state);
    //        gameObject.tag = state ? "Sick" : "Masked";
    //    }
        
    //    if (state == true)
    //    {
    //        gameObject.SetActive(false);
    //        Instantiate(sickCharacter, gameObject.transform.position, gameObject.transform.rotation);
    //        gameObject.tag = state ? "Sick" : "Masked";
    //    }
        
    //}
}
