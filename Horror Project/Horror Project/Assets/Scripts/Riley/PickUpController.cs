using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    [SerializeField] Transform holdArea; // to hold and manumaplate abot the hold area transfer 
    private GameObject heldObj; // to hold and manumaplate abot the held objct 
    private Rigidbody heldObjRB; //to hold and manumaplate abot the rigi body 

    public static bool isHolding; //to hold and manumaplate abot the is holding bool 

    [SerializeField] private float pickupRange = 5.0f; //to hold and manumaplate abot the puck up range 
    [SerializeField] private float pickupForce = 200.0f;//to hold and manumaplate abot the pick up foce 

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // if the player press left mouse button 
        {
            if(heldObj == null) //if the play is not holding object 
            {
                RaycastHit hit; // ray cast hit 
                if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))  //if it hit and object 
                {
                    //pick up objct 
                    PickUpObject(hit.transform.gameObject); // pik up object 
                    isHolding = false; // is holding qual false 

                }
            }
            else 
            {
                DropObject(); // drop object fuchtion
                isHolding = false; // is holding false 
                //Debug.Log("isholding not");

            }
        }
        if(heldObj != null) // if is holsign object 
        {
            MoveObject(); // move object fuchtion 
            isHolding = true; // is holding true 
            //Debug.Log("isholding");
        }
    }

    private void MoveObject() // move object function 
    {
        if(Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f) // if the distin is more then 0.1 
        {
            Vector3 moveDirection = (holdArea.position - holdArea.transform.position); //teh vertor 3 move direction 
            heldObjRB.AddForce(moveDirection * pickupForce); // add fore the the rigibody 
        }
    }

    private void PickUpObject(GameObject pickObj) // pick up function 
    {
        if (pickObj.GetComponent<Rigidbody>()) // gte pick item rigied body 
        {
            heldObjRB = pickObj.GetComponent<Rigidbody>(); // held object rigibody  is the pick object rigibody 
            heldObjRB.useGravity = false; // the held item has no gravity 
            heldObjRB.drag = 5; // the rigig body drag 
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation; // freeze rotatio on the rigibody 

            heldObjRB.transform.parent = holdArea; // held object rigibody is equal to the hodl arear 
            heldObj = pickObj; // held opjct = pic kobject 
        }
    }

    private void DropObject() // thisis the drop object 
    {
        
        heldObjRB.useGravity = true; // gravity is set to true 
        heldObjRB.drag = 1; // the drag is st to 1 
        heldObjRB.constraints = RigidbodyConstraints.None;  // and the rigibody constarint is none 

        heldObj.transform.parent = null; // is equal to null 
        heldObj = null; // held object is equal to null 
    }
}
