using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // to use the scene management from unity 

public class MainMenuScprit : MonoBehaviour
{
    [SerializeField] private AudioSource monSCearm; // to hold and manumaplate abot the monster scream 
    [SerializeField] private GameObject monster; // to hold and manuapater about the moster game object 
    [SerializeField] private GameObject Button; //to hold and manumaplate abot the button object 




    // Start is called before the first frame update
    void Start()
    {
        
    }

     public void StartGame() // start game function 
    {
        Button.SetActive(false); // set bttuon to nto active 
        StartCoroutine(JumpScream()); // start the coroutine of jump scream 
    }


    IEnumerator JumpScream() // jump scream Ienumerator 
    {
        yield return new WaitForSeconds(0.1f); // wait for 1 second 
        monster.GetComponent<Animator>().SetBool("IsScreaming", true);// play the scream animation 
        yield return new WaitForSeconds(0.3f); // waitfor 0.3 seconds 
        monSCearm.Play(); /// play the monster scream 
        yield return new WaitForSeconds(2.3f); // wait for 2.3 seconds 
        monster.GetComponent<Animator>().SetBool("IsScreaming", false); // stop player the screaming aimation
        SceneManager.LoadScene("Level 1"); // load the next  scenee 
        Cursor.lockState = CursorLockMode.Locked;// to lock the cursor 
        Cursor.visible = false; // cursor visiable 
    }
}
