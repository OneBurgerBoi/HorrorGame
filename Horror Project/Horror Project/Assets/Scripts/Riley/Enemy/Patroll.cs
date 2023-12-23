using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // to use unity inbuil AI function 

public class Patroll : StateMachineBehaviour
{
    private float timer; // a float verable to hold and munalite data
    
    private List<Transform> wayPoints = new List<Transform>(); // a list of transform for that waypoint that equal to a new list of transform

    private NavMeshAgent agent; // to hold and manipulate data of the nav mesh agent 

    private Transform player; // to hold and manipulate data of the player tranform 


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>(); // to get the nav mesh aganit for the enemie

        timer = 0; // the timer equal zero 
        GameObject go = GameObject.FindGameObjectWithTag("WayPoints"); // the game objecrt verable of the go eqal the game object with a tag of waypoints 
        foreach(Transform t in go.transform) // for each transform of t in gos from the go transform 
        {
            wayPoints.Add(t); // the waypoint add t

        }

        agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position); // so that the enemy goes to different waypoints 

        player = GameObject.FindGameObjectWithTag("Player").transform; // the player variable is the game object the is tag player and coloct its tranform 
        agent.speed = 5; // the enime speed is 5 
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(agent.remainingDistance <= agent.stoppingDistance) //if the eneime is getting close or at the waypoint 
        {
            agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position); // set a new waypoint for the enemy to go to 
        }

        timer += Time.deltaTime; // to make it timer from having the same as the in game timer 

       

        float distance = Vector3.Distance(player.position, animator.transform.position); // a float for the distance bestwewen the player and enemy 

        if (distance < IdleState.chaseRange && !PlayerScrpit.isHiding) // if the distance is less thn the chase range and the player is not hiding
        {
            animator.SetBool("isChasing", true); // play the chase animation 
            IdleState.isChasing = true; // bool is chasing  is true 
        }
      
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position); // stop the enime moving when at the end 
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
