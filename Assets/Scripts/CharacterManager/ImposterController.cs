using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ImposterController : MonoBehaviour
{
    [Header("Goal Locations")]
    [Tooltip("Points where the people should roam around")]
    [SerializeField] GameObject[] goalLocations;
    public GameObject affector;
    [Tooltip("Goal they are suppoused to be roaming around")]

    float waitTime;
    [Tooltip("Time they should wait at each point")]
    [SerializeField] float startWaitTime = 4;

    NavMeshAgent agent; //Gets the agent attached with each player
    Animator anim;  //Gets their animation component

    float speedMult;
    [Tooltip("Time the affect lasts on their wait")]
    [SerializeField] float timeItLasts = 4;

    GameObject target;
    GameObject affectLocation;

    void Start()
    {
        CharacterManager.Instance.characters.Add(gameObject);
        CharacterManager.Instance.imposterCharacters.Add(gameObject);
        affector = Resources.Load("Affectors/ImposterAffector") as GameObject;
        waitTime = startWaitTime;
        goalLocations = GameObject.FindGameObjectsWithTag("ImpostersGoal");
        agent = this.GetComponent<NavMeshAgent>();
        target = goalLocations[Random.Range(0, goalLocations.Length)];
        agent.SetDestination(target.transform.position);
        anim = this.GetComponent<Animator>();
        anim.SetFloat("woffset", Random.Range(0.0f, 1.0f));
        ResetAgent();
        StartCoroutine(StopAndWalkCoroutine());
    }
    private void OnDestroy()
    {
        CharacterManager.Instance.characters.Remove(gameObject);
        CharacterManager.Instance.imposterCharacters.Remove(gameObject);
    }

    public void ResetAgent()
    {
        speedMult = Random.Range(0.5f, 1.5f);
        agent.speed = 2 * speedMult;
        agent.angularSpeed = 120.0f;
        anim.SetFloat("speedMult", speedMult);
        anim.SetTrigger("isWalking");
        agent.ResetPath();
    }

    IEnumerator StopAndWalkCoroutine()
    {
        while (true)
        {
            if (agent.remainingDistance < 0.1f)
            {
                if (waitTime <= 0)
                {
                    ResetAgent();
                    int index = Random.Range(0, goalLocations.Length);
                    while (goalLocations[index] == target)
                    {
                        index = Random.Range(0, goalLocations.Length);
                    }
                    target = goalLocations[index];
                    agent.SetDestination(target.transform.position);
                    waitTime = startWaitTime;

                }
                else
                {
                    if (agent.remainingDistance == 0)
                    {
                        anim.SetTrigger("isIdle");
                    }

                    if (waitTime <= 2 && affectLocation == null)
                    {
                        affectLocation = Instantiate(affector, agent.transform.position - new Vector3(0f, 0.4f, 0f), agent.transform.rotation);
                        Destroy(affectLocation, timeItLasts);
                    }
                    waitTime -= 1 * Time.deltaTime;
                }

            }
            else
            {
                anim.SetTrigger("isWalking");
            }
            yield return null;
        }
    }
}
