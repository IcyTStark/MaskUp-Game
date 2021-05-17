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

    void Start()
    {
        waitTime = startWaitTime;
        Setgoals();
        StartCoroutine(StopAndWalkCoroutine());
        CharacterManager.Instance.characters.Add(gameObject);
    }

    public void Setgoals()
    {
        goalLocations = GameObject.FindGameObjectsWithTag(goalName);
        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
        anim = this.GetComponent<Animator>();
        anim.SetFloat("woffset", Random.Range(0.0f, 1.0f));
        ResetAgent();
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
            if (agent.remainingDistance < 0.1f)
            {
                if (waitTime <= 0)
                {
                    //anim.SetTrigger("isWalking");
                    ResetAgent();
                    agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
                    waitTime = startWaitTime;
                }
                else 
                {
                    //Debug.Log(gameObject.name + "waiting");
                    anim.SetTrigger("isIdle");
                    if (waitTime == startWaitTime)
                    {
                        GameObject affectLocation = Instantiate(affector, agent.transform.position, agent.transform.rotation);
                        Destroy(affectLocation, timeItLasts);
                    }
                    waitTime -= Time.deltaTime;
                }

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
