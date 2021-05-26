using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AffectorBase : MonoBehaviour
{
    [Header("Goal Locations")]
    [Tooltip("Points where the people should roam around")]
    [SerializeField] GameObject[] goalLocations;
    [SerializeField] GameObject affector;
    [Tooltip("Goal they are suppoused to be roaming around")]
    [SerializeField] string goalName;

    float waitTime;
    [Tooltip("Time they should wait at each point")]
    [SerializeField] float startWaitTime;

    NavMeshAgent agent; //Gets the agent attached with each player
    Animator anim;  //Gets their animation component

    float speedMult;
    [Tooltip("Time the affect lasts on their wait")]
    [SerializeField] float timeItLasts;
    
    GameObject target;
    GameObject affectLocation;

    void Start()
    {
        CharacterManager.Instance.characters.Add(gameObject);
        waitTime = startWaitTime;
        goalLocations = GameObject.FindGameObjectsWithTag(goalName);
        agent = this.GetComponent<NavMeshAgent>();
        target = goalLocations[Random.Range(0, goalLocations.Length)];
        agent.SetDestination(target.transform.position);
        anim = this.GetComponent<Animator>();
        anim.SetFloat("woffset", Random.Range(0.0f, 1.0f));
        ResetAgent();
        StartCoroutine(StopAndWalkCoroutine());
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
    void Update()
    {
        
        //StopandWalk();
    }

    //public void StopandWalk()
    //{

    //}

    IEnumerator StopAndWalkCoroutine()
    {
        while (true)
        {
            
            //Debug.Log(agent.remainingDistance);
            if (agent.remainingDistance < 0.1f)
            {
                if (waitTime <= 0)
                {
                    //anim.SetTrigger("isWalking");
                    ResetAgent();
                    int index = Random.Range(0, goalLocations.Length);
                    while(goalLocations[index] == target)
                    {
                        index = Random.Range(0, goalLocations.Length);
                    }
                    target = goalLocations[index];
                    agent.SetDestination(target.transform.position);
                    waitTime = startWaitTime;
                    
                }
                else
                {
                    if(agent.remainingDistance == 0)
                    {
                        //Debug.LogError(agent.remainingDistance);
                        anim.SetTrigger("isIdle");
                    }
                    //Debug.Log(gameObject.name + "waiting")
                    if (waitTime <= 2 && affectLocation == null)
                    {
                        
                        affectLocation = Instantiate(affector, agent.transform.position - new Vector3(0f, 0.4f, 0f), agent.transform.rotation);
                        Destroy(affectLocation, timeItLasts);
                    }
                    waitTime -= 1 * Time.deltaTime;
                    //WaitingTime = Mathf.RoundToInt(waitTime);
                    //Debug.Log(WaitingTime);

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

////config parameters
//[SerializeField] float speed;
//float waitTime;
//[SerializeField] float startWaitTime;


//[SerializeField] Transform[] moveSpots;
//int randomSpot;

////Cached reference
//Animator anim;

//private void Start()
//{
//    waitTime = startWaitTime;
//    anim = GetComponent<Animator>();
//    randomSpot = Random.Range(0, moveSpots.Length);
//}

//void Update()
//{
//    transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
//    anim.SetTrigger("isWalking");
//    if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
//    {
//        if (waitTime <= 0)
//        {
//            randomSpot = Random.Range(0, moveSpots.Length);
//            waitTime = startWaitTime;

//        }
//        else
//        {
//            anim.SetTrigger("isIdle");
//            waitTime -= Time.deltaTime;
//        }
//    }
//}
