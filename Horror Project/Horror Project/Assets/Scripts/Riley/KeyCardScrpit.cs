using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCardScrpit : MonoBehaviour
{
    public static bool haskeyCard1; // to hold and manipulate data about the has key card bool 

    [SerializeField] private GameObject door1; // to hold and manipulate data about the door gameobject 
    
    public static bool doorOpen; // to hold and manipulate data about the door open bool 

    

    // Update is called once per frame
    void Update()
    {
        if (door1.activeSelf) // if the door is sctive in scene 
        {
            doorOpen = false; // door opn equal false 
        }


        if (!door1.activeSelf) // if door is not active in scene 
        {
            doorOpen = true; // door open equal true 
        }
    }

    private void OnCollisionEnter(Collision collision) // if game object collide with object with scrpit 
    {
        if(collision.gameObject.tag == "CardReader") // if object collided with object tag  card reader 
        {
            Destroy(gameObject, 0.1f); // destroy gamobject 
            Debug.Log("Door Open");
            door1.SetActive(false); // door is set false in scene 
          
        }
    }



}
