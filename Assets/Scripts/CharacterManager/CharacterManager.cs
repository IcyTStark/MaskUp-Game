using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    public List<GameObject> characters = new List<GameObject>();
    public List<GameObject> unMaskedCharacters = new List<GameObject>();
    public List<GameObject> maskedCharacters = new List<GameObject>();
    public List<GameObject> sickCharacters = new List<GameObject>();
    public List<GameObject> imposterCharacters = new List<GameObject>();

    [SerializeField] int loseNumber = 2;
    
    private static CharacterManager _instance;

    private void Start()
    {
        //UnMasked();
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

    void Update()
    {
        //foreach (GameObject gO in characters)
        //{
        //    if (!characters.Any(gO => gO.tag == "UnMasked") && !characters.Any(gO => gO.tag == "Imposter") && !characters.Any(gO => gO.tag == "Sick"))
        //    {
        //        Invoke("nextLevel", 5f);
        //    }
        //}
        if (maskedCharacters.Count == characters.Count)
        {
            Invoke("nextLevel", 5f);
        }
        if (sickCharacters.Count + unMaskedCharacters.Count + imposterCharacters.Count > loseNumber)
        {
            Invoke("reloadLevel", 5f);
        }
    }
    void nextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);

    }
    void reloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);

    }

    //o => o.tag == "UnMasked"
    //void UnMasked()
    //{
    //    List<GameObject> temp = new List<GameObject>(characters);
    //    int randomNumber = Random.Range(0, characters.Count);
    //    for(int i= 0; i<randomNumber;i++)
    //    {
    //        int index = Random.Range(0, temp.Count);
    //        temp[index].GetComponent<MaskStatus>().ToggleMask(false);
    //        Debug.Log(temp[index].name);
    //        temp.RemoveAt(index);
    //    }
    //}

    //void Imposter()
    //{
    //    List<GameObject> tempImp = new List<GameObject>(characters);
    //    for (int j = 0; j < 2; j++)
    //    {
    //        int index_1 = Random.Range(0, tempImp.Count);
    //        tempImp[index_1].GetComponent<MaskStatus>().ToggleImposterMask(false);
    //        Debug.Log(tempImp[index_1].name);
    //        tempImp.RemoveAt(index_1);
    //    }

    //}
}
