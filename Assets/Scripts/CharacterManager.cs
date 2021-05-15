using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public List<GameObject> characters = new List<GameObject>();
    
    private static CharacterManager _instance;

    private void Start()
    {
        UnMasked();
        //Imposter();
    }

    private void Awake()
    {
        if(_instance != null)
        {
            Destroy(this);
            DontDestroyOnLoad(this);
        }

    }
    public static CharacterManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<CharacterManager>();
                if(_instance == null)
                {
                    _instance = new GameObject().AddComponent<CharacterManager>();
                }
            }
            return _instance;
        }
    }

    void UnMasked()
    {
        List<GameObject> temp = new List<GameObject>(characters);
        int randomNumber = Random.Range(0, characters.Count);
        for(int i= 0; i<randomNumber;i++)
        {
            int index = Random.Range(0, temp.Count);
            temp[index].GetComponent<MaskStatus>().ToggleMask(false);
            Debug.Log(temp[index].name);
            temp.RemoveAt(index);
        }
    }

    //void Imposter()
    //{
    //    List<GameObject> tempImp = new List<GameObject>(characters);
    //    for(int j = 0; j < 2; j++)
    //    {
    //        int index_1 = Random.Range(0, tempImp.Count);
    //        tempImp[index_1].GetComponent<MaskStatus>().ToggleMask(false);
    //        Debug.Log(tempImp[index_1].name);
    //        tempImp.RemoveAt(index_1);
    //    }
            
    //}
}
