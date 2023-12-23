using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private float MaxHealth = 3; //This float is made public to edit in Unity. It sets the max health of the player.
    //This means I can set the max health number in Unity editor rather than writing in this script and having to come back to change it if I want to edit it.

    public float CurrentHealth; //This allows me to set the current health of the player in Unity.
    //I find it very useful as I can view any changes to the current health in the inspector while the scene is running,
    //thereby letting me view if the obstacles I made to lower my players health and the pickups I made to increase my players health are working.

    private static Player instance; //Attatches instance to the Player script.

    public float damageFrame; //Allows me set a wait value for the player taking damage.

    private float damageFrameCounter; //Counter for the player taking damage.

    private bool hit; //Allows me to create a true or false statement for when the player is hit.

    public bool hidden; //Bool for if the player is hidden.

    private void Awake()
    {
        instance = this; //Links instance to "this" script, the Player script.
    }

    void Start()
    {
        FillHealth(); //This sets the players health to max health at the start of the game.
    }

    void Update()
    {
       if (hit == true) //If the player is hit.
       {
            if (damageFrameCounter < damageFrame) // If counter is less than damage frame amount.
            {
                damageFrameCounter += Time.deltaTime; //Counter for the damage.
            }

            if (damageFrameCounter >= damageFrame) //If counter is more than or equal to damage frame amount.
            {

                DamagePlayer(); //Activates public void "DamagePlayer".

                damageFrameCounter = 0; //Set counter to zero.

                hit = false; //Set hit to false.
            }
       }
    }

    private void FillHealth() //Attatches fill health to the player.
    {
        CurrentHealth = MaxHealth; //Sets current health to the value of max health.
    } 

    private void OnTriggerEnter(Collider collision) //Trigger the below if statements if collision tag collides with the player.
    {
        if (collision.tag == "Hand")//On collision with the tagged object.
        {
            hit = true; //Sets player being hit to true.
        }

        if (collision.tag == "Locker") //If the collision tag is Locker.
        {
            hidden = true; //Then the player is hidden.
        }

        else
        {
            hidden = false; //If there is no collision with locker then the player is not hidden.
        }

    }
    
    private void DamagePlayer()
    { 
        {
            CurrentHealth--; //Current health of the player decreases by -1.

            if (CurrentHealth <= 0) //If the players current health is 0.
            {
                SceneManager.LoadScene("Jump Scare"); //This reloads the gamescene.
            }

        }

    }
   
}
