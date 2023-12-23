using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpScearScrpit : MonoBehaviour
{
    [SerializeField] private AudioSource monSCearm; // to hold and mubaluplate data about the monster scream
    [SerializeField] private GameObject monster; // to hold and manuaplater data about the game object of the monster 
    [SerializeField] private GameObject button; // to hold and manipulator data about the button 

    [SerializeField] private AudioSource playerScream; //to hold and munaplater data aboutthe player scream 
    [SerializeField] private AudioSource playerSplat;// to hold and manipulate data about the player splat 


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(attack()); // start the coroutine of attack 
    }

    IEnumerator attack() // attatck ienumator 
    {
        yield return new WaitForSeconds(0.1f); // wait for 0.1 sconsds 
        monster.GetComponent<Animator>().SetBool("isAttacking", true); // play  the attack animation 
        yield return new WaitForSeconds(1f); // wait for one sceond 
        playerScream.Play(); // play the player scream sound effect 
        yield return new WaitForSeconds(0.3f); // wait for 0.3 seconds 
        playerSplat.Play(); // play the plat sound effect 
        yield return new WaitForSeconds(5f); // wait for 5 scenonds 
        button.SetActive(true); // set button active to true 
        // StartCoroutine(JumpScrea());

    }


    public void Restar() // the restart function 
    {
        SceneManager.LoadScene("Level 1"); //load scenemanager level 1
    }

   IEnumerator JumpScrea() // jump screa ienumerator 
    {
        yield return new WaitForSeconds(1.5f); //wait for 1.5 seconds 
        monster.GetComponent<Animator>().SetBool("IsScreaming", true); // player the scream animation 
        yield return new WaitForSeconds(0.3f); // wait for 0.3 seconds 
        monSCearm.Play(); // play monster scream
        yield return new WaitForSeconds(2.3f); //wait for 2.3 seconds 
        monster.GetComponent<Animator>().SetBool("IsScreaming", false); // set the animation bool tp false stop playing 
    }
}
