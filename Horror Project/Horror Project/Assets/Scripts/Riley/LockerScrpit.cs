using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerScrpit : MonoBehaviour
{
    
    [SerializeField] private GameObject doorHinge; //to hold and manumaplate abot the door hinge object 
    public static bool isDoorClose = true; //to hold and manumaplate abot the door close  bool equal to ture 
    private bool lockerState; //to hold and manumaplate abot the bo locker state 

    [SerializeField] private AudioSource doorOpen; //to hold and manumaplate abot the audio soure door open 
    [SerializeField] private AudioSource doorClose; //to hold and manumaplate abot the aufio sound door close 


    

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1)) // if player press right mouse click 
        {

            if (!PickUpController.isHolding) //and if the player is not holding anything 
            {
                if (lockerState) // if locker state is true 
                {

                    if (!isDoorClose) // if the door is not close 
                    {
                        doorHinge.GetComponent<Animator>().SetBool("isOpen", true); // play the locker closing animation 
                        isDoorClose = true; //door is close eaual to false 
                        doorClose.Play(); // player sound effect 
                        //Debug.Log("Door close");
                    }
                    else if(isDoorClose) // else if door is close 
                    {
                        doorHinge.GetComponent<Animator>().SetBool("isOpen", false);  // door open animation 
                        isDoorClose = false; // door is close is set to false 
                        doorOpen.Play(); // play door sound effect 
                        //Debug.Log("Door open");
                    }

                }
            }
           

        }
    }

    private void OnTriggerEnter(Collider other) // if colide and set to trigger 
    {
        

        if (other.tag == "Player") // if colliderde and wit htag playr 
        {
            lockerState = true; // locker stare equal true 
            //Debug.Log("Nere");
        }
    }

    private void OnTriggerExit(Collider other) // if levea the colldier and has st to trigger 
    {
      

        if (other.tag == "Player") // if colldre wit hplayer 
        {
            lockerState = false; // locker state is false 
            //Debug.Log("Away");
        }
    }
}
