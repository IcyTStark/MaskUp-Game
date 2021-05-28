using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    [Header("Goal Locations")]
    [Tooltip("Points where the people should roam around")]
    [SerializeField] GameObject[] goalLocations;

    NavMeshAgent agent; //Gets the agent attached with each player
    Animator anim;  //Gets their animation component

    float speedMult;
    //float detectionRadius = 20;
    //float fleeRadius = 10;

    void Start()
    {
        CharacterManager.Instance.characters.Add(gameObject);
        CharacterManager.Instance.maskedCharacters.Add(gameObject);
        goalLocations = GameObject.FindGameObjectsWithTag("goal");
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
    private void OnDestroy()
    {
        CharacterManager.Instance.characters.Remove(gameObject);
        CharacterManager.Instance.maskedCharacters.Remove(gameObject);
    }
    void Update()
    {
        if(agent.remainingDistance < 1)
        {
            ResetAgent();
            agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
        }
    }
}


