using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    
    [Header("Objectives")]
    private int objective;
    public int actualObjective;

    [Header("Objective - Energy")]
    public bool hasFuse, fuseInPlace, energyRestored;
    private bool powerIsOn;
    public GameObject[] energy_objects;
    public GameObject fuse_HUD_Icon;

    [Header("Objective - Servers")]
    public Server[] servers;
    public GameObject serversObjectiveHint;
    public GameObject stockpcScreen;
    public GameObject stockpcScreenError;
    public GameObject[] activate_screens;
    public GameObject[] deactivate_screens;

    void Awake() 
    {
        //Set the Instance
        if(instance == null) instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //ObjectiveSystem
        objective = 0;
        actualObjective = 0;

        //Servers
        foreach(Server s in servers) //ForEach Server
        {
            s.isOn = false; //Start off
        }

        //Cursor Lock to center
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(fuseInPlace) //If fuse is in place
            if(energyRestored && !powerIsOn) //If energy is restored but power continues off
            {
                powerIsOn = true; //Set power to on
                PowerObjectiveCheck(true); //Enable EnergyOnly Objects
            }
            else if(!energyRestored && powerIsOn) //If energy is off but power continues on
            {
                powerIsOn = false; //Set power to off
                PowerObjectiveCheck(false); //Disable EnergyOnly Objects
            }
        else if(!fuseInPlace && (energyRestored || powerIsOn)) //If fuse isn't in place
        {
            powerIsOn = false; //Power is set to false
            energyRestored = false; //Energy is set to false
            PowerObjectiveCheck(false); //Disable EnergyOnly Objects
        }

        if(hasFuse) //If has fuse in inventory
            fuse_HUD_Icon.SetActive(true); //Show fuse icon in HUD
        else //If hasn't fuse in inventory
            fuse_HUD_Icon.SetActive(false); //Hide fuse icon in HUD
    }

    public void ServerObjectiveCheck()
    {
        //If only servers 2, 3, 5, 9, 11 are on, pass!
        if(!servers[0].isOn && servers[1].isOn && servers[2].isOn && !servers[3].isOn && servers[4].isOn && 
           !servers[5].isOn && !servers[6].isOn && !servers[7].isOn && servers[8].isOn && !servers[9].isOn && servers[10].isOn)
        {
            print("Correct Servers On!");
            if(!stockpcScreen.activeInHierarchy) // If Screen without error isn't active
            {
                stockpcScreenError.SetActive(false); //Deactive error
                stockpcScreen.SetActive(true); //Active Screen without error
            } 

            if(actualObjective <= 4) // If objective is outdated
            {
                actualObjective = 5; // Update objective
                serversObjectiveHint.SetActive(false);
            }
        }
        else //If servers are not correct, disable PC
        {
            print("Wrong Servers!");
            stockpcScreenError.SetActive(true); //Active error
            stockpcScreen.SetActive(false); //Deactive Screen without error

            foreach(GameObject g in activate_screens) //Activate everything that needs to be activated
            {
                g.SetActive(true);
            }

            foreach(GameObject g in deactivate_screens) //Deactivate everything that needs to be deactivated
            {
                g.SetActive(false);
            }
        }
    }

    public void PowerObjectiveCheck(bool hasPower)
    {
        foreach(GameObject g in energy_objects) //get every energy object
        {
            g.SetActive(hasPower); //Activate or Deactivate depending on power is on or off
        }
    }

}
