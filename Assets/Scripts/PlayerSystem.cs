using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSystem : MonoBehaviour
{
    public static PlayerSystem instance;

    public GameObject mobileController;
    public Button getItem;

    void Awake() 
    {
        //Set the Instance
        if(instance == null) instance = this;
    }

    void Start()
    {
        #if UNITY_ANDROID || UNITY_IOS // If is mobile

            // Activate the mobile controller
            mobileController.SetActive(true);
            // Activate get item button
            getItem.gameObject.SetActive(true);
            // Set it to not interactable
            getItem.interactable = false;

        #else // else (if isn't mobile)

            // Disable Mobile Controller
            mobileController.SetActive(false);
            // Set getItem button to interatable
            getItem.interactable = true;
            // Disable getItem button
            getItem.gameObject.SetActive(false);

        #endif // close if/else
    }

    void Update()
    {
        
    }
}
