using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiScore : MonoBehaviour
{
    [SerializeField] private Text scoreText; //to hold and muaplater data about the score text 
    [SerializeField] public static float score; // tp hold and menuplate data aboutthe score 

    [SerializeField] private Text highScoreText; //to hold and manipulate data about the high score text 
    [SerializeField] private float highScore; // to hold and manipulate data about high score 
    private float timer; // to hold and manipulate data about the timer 
    
    private bool beatOnce; // to hold and manipulate data bool beat once 
    

    // Start is called before the first frame update
    void Start()
    {
        
        highScore = PlayerPrefs.GetFloat("HighScore"); // high score equal the save player prefb and get the float of the high score 



    }

    // Update is called once per frame
    void Update()
    {


        highScoreText.text = highScore.ToString(); //to show the high score on the scene 
        scoreText.text = score.ToString(); // to show the score on the scene

        if (KeyCardScrpit.doorOpen) // if in kycard scprit door open is true 
        {
            if (!beatOnce) // and hasnit beat once 
            {
                beatOnce = true; // beat once equal true 
                PlayerPrefs.SetFloat("HighScore", score); // save the high score to the player prefab 

            }
            else // else 
            {
                if (score < highScore) // if score is less then high score 
                {
                    PlayerPrefs.SetFloat("HighScore", score); // save tge player pref set float high score  to score 
                }
            }
            

        }
       

        if (Input.GetKeyDown(KeyCode.M))
        {
            PlayerPrefs.DeleteKey("HighScore");
        }

        timer += Time.deltaTime;
        score = timer;
        
    }
}
