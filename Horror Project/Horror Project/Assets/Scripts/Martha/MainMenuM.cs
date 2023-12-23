using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Adds scene management to this script.

public class MainMenuM : MonoBehaviour
{

    public string GameScene; //This is a reference in the script that names the scene I want to open and close within the menus.

    public GameObject optionsScreen; //Creates a reference to the game object.

    // Start is called before the first frame update
    void Start()
    {
        optionsScreen.SetActive(false); //Sets the options screen to inactive at the start of the game.
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame() //This is the function that is called to enter the game scene.
    {
        SceneManager.LoadScene(GameScene); //This tells the scene manager to load the scene specified which in this case is the 'GameScene'.
    }

    public void OpenOptions() //This is the function called to open the options menu.
    {
        optionsScreen.SetActive(true); //Sets the options screen to active so that it is visible.
    }

    public void CloseOptions() //This is the function called to close the options menu.
    {
        optionsScreen.SetActive(false); //Sets the options screen to inactive so that it is invisible.
    }

    public void QuitGame() //This function closes down the game when called.
    {
        Application.Quit(); //This will close Unity, thereby closing the game on button press.
    }
}
