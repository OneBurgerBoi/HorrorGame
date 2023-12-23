using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu; //Helps me to connect the pause menu to the level manager.
    public bool isPaused; //Creates a bool for if the game is paused.
    public GameObject cursor; //Allows me to hide the crosshair shown in the game scene.

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false); //Sets the pause menu to inactive at the start of the game.
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) //When escape is pressed.
        {
            if(isPaused)
            {
                ResumeGame(); //If game is paused then resume game.
                Cursor.visible = false; //This makes the cursor invisible whilst the game scene is active.
                Cursor.lockState = CursorLockMode.Locked; //This keeps the cursor at a centre point when the game scene is active.
            }
            else
            {
                PauseGame(); //If game is not paused then pause the game.
                Cursor.visible = true; //This makes the cursor visible again.
                Cursor.lockState = CursorLockMode.Confined; //This allows the cursor to be moved around but not outside of the game scene bounds.
            }
        }
        
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true); //Show pause menu.
        Time.timeScale = 0f; //Sets the time scale of the scene to 0 so that the game scene stops.
        isPaused = true; //Sets the game being paused to true.
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false); //Hides the pause menu.
        Time.timeScale = 1f; //Sets the time scale of the scene back to normal.
        isPaused = false; //Sets is paused to false.
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; //Sets time scale to normal.
        SceneManager.LoadScene("MainMenu"); //Loads the main menu scene.
    }

    public void QuitGame()
    {
        Application.Quit(); //Quits the game.
    }

    public void HideCursor()
    {
        cursor.SetActive(false); //Hides cursor crosshair in the pause menu.
    }
}
