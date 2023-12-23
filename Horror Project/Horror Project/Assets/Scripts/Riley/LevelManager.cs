using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // to use the scene management from unity 


public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject pannle; // to hold and manipulate data about the pannle  gameobject 
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (KeyCardScrpit.doorOpen)
        {
            pannle.SetActive(true); // set active plannle true 
            player.SetActive(false);// set player to not be active
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;// to lock the cursor 
            Cursor.visible = true; // cursor visiable 

        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Level 1"); // load the next  scenee 
    }
}
