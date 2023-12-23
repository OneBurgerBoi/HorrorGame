using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IdleState : StateMachineBehaviour
{
    private float timer; // a float verable to hold and muilplate the timer variable 

    private Transform player; // a transform verable to hold and muilplate the player transform 

    public static float chaseRange = 20; // a static float verable to hold and muilplate the play chase range 

    public static bool isChasing; //a bool verable to hold and muilplate the is chaseing bool 

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0; // timer equal 0
        player = GameObject.FindGameObjectWithTag("Player").transform; // the player equal the game object with a tag player 
    }
    
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime; // timer is add with using time dot delta time 

        if(timer > 0) // if timer  less the 0 
        {
            animator.SetBool("isPortrolling", true);  // plat the is portolling aimation 
        }

        float distance = Vector3.Distance(player.position, animator.transform.position); //the distand is the player position to the enime position 

        if(distance < chaseRange) // the distance is more the chase range 
        {
            if(PlayerScrpit.isHiding == false)
            {
                animator.SetBool("isChasing", true);
                isChasing = true;
            }
           
        }
       
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
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
