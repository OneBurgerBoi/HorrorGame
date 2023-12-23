using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class UIScript : MonoBehaviour
{
    private Player myPlayer; //Creates a variable for the player script.
    public GameObject health3; //Variable for the value 3 health image.
    public GameObject health2; //Variable for the value 2 health image.
    public GameObject health1; //Variable for the value 1 health image.
    public GameObject eyeOpen; //Variable for eyeOpen image.
    public GameObject eyeClosed; //Variable for eyeClosed image.

    public Animator heartSpeeds; //Adds the heartSpeed animator.

    // Start is called before the first frame update
    void Start()
    {
        myPlayer = FindObjectOfType<Player>(); //This locates the Player script and gives it the variable name of "myPlayer".
    }

    // Update is called once per frame
    void Update()
    {
        if (myPlayer.CurrentHealth == 3) //If the players current health is 3.
        {
            health3.SetActive(true); //Activates the health image.
            health2.SetActive(true); //Activates the health image.
            health1.SetActive(true); //Activates the health image.
        }

        if (myPlayer.CurrentHealth == 2) //If the players current health is 2.
        {
            health3.SetActive(false); //Hides other health images.
            health2.SetActive(true); //Activates the health image.
            health1.SetActive(true); //Activates the health image.
        }

        if (myPlayer.CurrentHealth == 1) //If the players current health is 1.
        {
            health3.SetActive(false); //Hides other health images.
            health2.SetActive(false); //Hides other health images.
            health1.SetActive(true); //Activates the health image.
        }

        if (myPlayer.CurrentHealth == 0) //If the players current health is 1.
        {
            health3.SetActive(false); //Hides other health images.
            health2.SetActive(false); //Hides other health images.
            health1.SetActive(false); //Hides other health images.
        }

        if (PlayerScrpit.isHiding) //If player is hidden show the eye closed icon.
        {
            eyeOpen.SetActive(false);
            eyeClosed.SetActive(true);
        }

        else //If player is not hidden then show the eye open icon.
        {
            eyeOpen.SetActive(true);
            eyeClosed.SetActive(false);
        }


    }

}
