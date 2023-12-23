using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCandleScrpit : MonoBehaviour
{
    [SerializeField] private GameObject candleLight; // to hold and mualpate data about the game objct canle light 

   

    private void OnCollisionEnter(Collision collision) // on collision enter make it so it read th fuchtio when game object 
    {
        if(collision.gameObject.tag == "Candle") // if collided with a object tag candle 
        {
            candleLight.SetActive(true); // set candle to active so it show in scream
        }
    }
}
