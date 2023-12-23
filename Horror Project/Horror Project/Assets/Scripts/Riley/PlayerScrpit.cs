using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; //using unity scene manager 
using UnityEngine;
using UnityEngine.Animations; // animation from unity 

public class PlayerScrpit : MonoBehaviour
{
    //[SerializeField] private GameObject icon; 

    private Transform enemy; // to hold and manumaplate abot the nemie transform 


    //private bool isRunning; //to hold and manumaplate abot the 
    public static bool inLight; //to hold and manumaplate abot the the light 

    private AudioSource heartBeat; //to hold and manumaplate abot the heart beat 
    [SerializeField] public static bool isInlocker; // to hold and manumaplate abot the is in locker 
    [SerializeField] public static bool isHiding; //to hold and manumaplate abot the is hiding 

     public static bool isClose; //Martha - Sets a bool for if enemy is close for the heartbeat UI.
     public static bool isMid; //Martha - Sets a bool for if enemy is mid range for the heartbeat UI.
     public static bool isFar; //Martha - Sets a bool for if enemy is far for the heartbeat UI.
     public Animator heartSpeed; //Adds the heartSpeed animator.
    private float sprintSpeed;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;// to lock the cursor 
        Cursor.visible = false; // cursor visiable 
    }

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform; // to fing the enemy object transform 
        heartBeat = GetComponent<AudioSource>(); // getting the sudio source component 
        sprintSpeed = StarterAssets.FirstPersonController.SprintSpeed;

    }

    // Update is called once per frame
    void Update()
    {
       
        //SprintMach();
        HeartBeat(); // to call the heart beat function 
        Hidden(); // to call the hidden fuchtion 
       

        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //}

        //Debug.Log(isHiding);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

            StarterAssets.FirstPersonController.SprintSpeed = 10;
            //isRunning = true;
            //StartCoroutine(StopSrpit());
        }

    }


    private void OnTriggerEnter(Collider other) // if ojcest scprit atacht to colldeds and is set top triggere with a object 
    {
        


        if (other.tag == "Locker") // if collided with tag locker 
        {
            isInlocker = true;  // is i locker true 
          
        }

        if(other.tag == "light") // if collided with object tag light 
        {
            inLight = true; // in light is true 
           
        }
    }

    private void OnTriggerExit(Collider other) //if the triggered obbject stop colliding 
    {
        if (other.tag == "Locker") // if collided with locker 
        {
            isInlocker = false; // is in locker is false 
           
        }

        if (other.tag == "light") // if stop colliding with tag light 
        {
            inLight = false; // in light us fasle 
            
        }
    }

   
   


    

    //private void SprintMach()
   // {
       

       // if (Input.GetKeyDown(KeyCode.LeftShift))
       // {

            //StarterAssets.FirstPersonController.SprintSpeed = 10;
            //isRunning = true;
                //StartCoroutine(StopSrpit());
        //}
       
    //}
       
    //}

   // IEnumerator StopSrpit()
   // {
        
      //  yield return new WaitForSeconds(1.5f);
      //  StartCoroutine(SprintCalldown());
        //icon.SetActive(false);
   // }
    //IEnumerator SprintCalldown()
   // {
        
       
      //  StarterAssets.FirstPersonController.SprintSpeed = 6f;
      //  yield return new WaitForSeconds(5);
       
       // isRunning = false;
        //icon.SetActive(true);
    //l}

   
    private void HeartBeat() // the hear beart fuchtion 
    {
        float distance = Vector3.Distance(enemy.position, this.transform.position); // caluactat a float varble called distend between the playe and enemey 

       if(distance > IdleState.chaseRange) // if distance is les the chase range in the idle state scrpit 
       {
            IdleState.isChasing = false; // idle state scpit is chaseing false 
       }

        

        if(IdleState.isChasing) // if chasing true  in the idle state scrpit 
        {
            heartBeat.pitch = 2.5F; // the heart beat pitch is 2.5 
            isMid = true; //Martha - Sets enemy is mid range to true.

            if (isMid == true)

            {
                heartSpeed.SetTrigger("Mid");
            }

        }
        else
        {

            if (distance < 25) // if distance is less the 2.5 
            {
                heartBeat.pitch = 3f;   // the heart beat pitch equal 3
                isClose = true; //Martha - Sets enemy is close to true.

                if(isClose == true)

                {
                    heartSpeed.SetTrigger("Close");
                }
                
            }

            else if (distance < 40) // if the distance is less then 23 
            {
                heartBeat.pitch = 2.5F;// heart beat pitch is 2.5
                isMid = true; //Martha - Sets enemy is mid range to true.

                if (isMid == true)

                {
                    heartSpeed.SetTrigger("Mid");
                }

            }

            else if (distance < 80) // distance less 27 
            {
                heartBeat.pitch = 1; // ths heat beat pitch is  onw 
                IdleState.isChasing = false; // iodle state is chasing fasle 
                isFar = true; //Martha - Sets enemy is far to true.

                if (isFar == true)

                {
                    heartSpeed.SetTrigger("Far");
                }
            }

            else
            {
                isClose = false;
                isMid = false;
                isFar = false;
                //Martha - Sets all to false
            }
        }
    }

    private void Hidden() // the hinde function 
    {
        if (isInlocker)// if isin locker true 
        {
            if(LockerScrpit.isDoorClose) // if is door close bool in locker scpit true 
            {
                isHiding = true; // is hiding is true 
               

            }
            else 
            {
                isHiding = false; // is hinding false 
               
            }
           
        }
        else if (isInlocker) // else if is inlocker 
        {
          
            isHiding = false; // is hiding false 
          
        }
    
    }
}
