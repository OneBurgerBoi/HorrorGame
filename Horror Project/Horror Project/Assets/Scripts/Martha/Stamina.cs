using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{

    public float stamina; //Creates a float for the stamina value.
    float maxStamina; //Max stamina amount so as not to give the player infinate stamina.
    public Slider staminaBar; //Sets a UI slider as the stamina bar to show the stamina value.
    public float dValue; //The dValue is the float amount by which the stamina will increase and decrease when the left shift key is pressed.

    // Start is called before the first frame update
    void Start()
    {
        maxStamina = stamina; //Max stamina amount is set to the stamina amount set at the start of the game.
        staminaBar.maxValue = maxStamina; //The stamina bars max value shown is set to that of the maximum stamina value.
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift)) //If the left shift key is pressed.
            DecreaseEnergy(); //Run decrease energy.
        else if (stamina != maxStamina) //If stamina is not equal to max stamina.
            IncreaseEnergy(); //Run increase energy.

        staminaBar.value = stamina; //Makes the value shown on the stamina bar equal to the current stamina amount.
    }

    private void DecreaseEnergy()
    {
        if (stamina != 0) //If the current stamina is not 0.
            stamina -= dValue * Time.deltaTime; //The the stamina amount will decrease by the dValue I have set.
    }

    private void IncreaseEnergy()
    {
        stamina += dValue * Time.deltaTime; //Stamina will slowly increase by the amount of the dValue I set.
    }
}
