using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RascalsControl : MonoBehaviour
{
    [Header("Goal Locations")]
    [Tooltip("Points where the people should roam around")]
    [SerializeField] GameObject[] goalLocations;
    [SerializeField] GameObject affector;

    float waitTime;
    [SerializeField] float startWaitTime;

    NavMeshAgent agent; //Gets the agent attached with each player
    Animator anim;  //Gets their animation component

    float speedMult;
    float detectionRadius = 20;
    float fleeRadius = 10;

    void Start()
    {
        goalLocations = GameObject.FindGameObjectsWithTag("ImpostersGoal");
        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
        anim = this.GetComponent<Animator>();
        anim.SetFloat("woffset", Random.Range(0.0f, 1.0f));
        ResetAgent();
    }

    void ResetAgent()
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
        if (agent.remainingDistance < 1)
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
                anim.SetTrigger("isIdle");
                GameObject affectLocation = Instantiate(affector, agent.transform.position, agent.transform.rotation);
                Destroy(affectLocation, 10f);
                waitTime -= Time.deltaTime;
            }
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
