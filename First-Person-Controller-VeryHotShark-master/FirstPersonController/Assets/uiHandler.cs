using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;

public class uiHandler : MonoBehaviour
{
    [BoxGroup("Flashlight")] [SerializeField] Light Flashlight;
    [BoxGroup("Flashlight")] [SerializeField] Image flashlightIndicator;
    [BoxGroup("Flashlight")] [SerializeField] Color opaque;
    [BoxGroup("Flashlight")] [SerializeField] Color transparent;
    [BoxGroup("Flashlight")] [SerializeField] AudioSource flashlightToggle;

    [BoxGroup("Flashlight")] private bool flashlightToggled = false;

    /*---------------------------------------------------------------------------------------------------------*/

    [BoxGroup("Player Health")] [SerializeField] [Range(0, 100)] float playerHealth = 100f;
    [BoxGroup("Player Health")] [SerializeField] Slider playerHealthSlider;

    /*---------------------------------------------------------------------------------------------------------*/

    [BoxGroup("Player Armor")] [SerializeField] [Range(0, 300)] float playerArmor = 0f;
    [BoxGroup("Player Armor")] [SerializeField] Slider playerArmorSlider;

    /*---------------------------------------------------------------------------------------------------------*/

    [BoxGroup("Player Grenades")] [SerializeField] [Range(0, 3)] int playerGrenades = 0;
    [BoxGroup("Player Grenades")] [SerializeField] Slider playerGrenadesSlider;

    /*---------------------------------------------------------------------------------------------------------*/

    [BoxGroup("Player Meds")] [SerializeField] [Range(0, 3)] int playerMeds = 0;
    [BoxGroup("Player Meds")] [SerializeField] Slider playerMedsSlider;

    void Start()
    {
        opaque = new Color32(255, 255, 255, 255);
        transparent = new Color32(255, 255, 255, 80);

        flashlightToggled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (flashlightToggled == false)
            {
                flashlightToggled = true;
                flashlightToggle.Play();
            }
            else
            {
                flashlightToggled = false;
                flashlightToggle.Play();
            }
        }

        if (flashlightToggled == true)
        {
            Flashlight.intensity = 1.25f;
            flashlightIndicator.color = opaque;
        }
        else if (flashlightToggled == false)
        {
            Flashlight.intensity = 0f;
            flashlightIndicator.color = transparent;
        }

        /*---------------------------------------------------------------------------------------------------------*/

        playerHealthSlider.value = playerHealth;

        if (playerHealth < 0)
            playerHealth = 0;
        else if (playerHealth > 100)
            playerHealth = 100;

        /*---------------------------------------------------------------------------------------------------------*/

        playerArmorSlider.value = playerArmor;

        if (playerArmor < 0)
            playerArmor = 0;
        else if (playerArmor > 300)
            playerArmor = 300;

        /*---------------------------------------------------------------------------------------------------------*/

        playerGrenadesSlider.value = playerGrenades;

        if (playerGrenades < 0)
            playerGrenades = 0;
        else if (playerGrenades > 3)
            playerGrenades = 3;

        /*---------------------------------------------------------------------------------------------------------*/

        playerMedsSlider.value = playerMeds;

        if (playerMeds < 0)
            playerMeds = 0;
        else if (playerMeds > 3)
            playerMeds = 3;
    }
}
