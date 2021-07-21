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

    //Energy objective
    public bool fuseInPlace, energyRestored;
    private bool powerIsOn;
    public Server[] servers;

    [Header("Objective - Energy")]
    public GameObject[] energy_objects;

    [Header("Objective - Servers")]
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
        if(fuseInPlace)
            if(energyRestored && !powerIsOn)
            {
                powerIsOn = true;
                PowerObjectiveCheck(true);
            }
            else if(!energyRestored && powerIsOn)
            {
                powerIsOn = false;
                PowerObjectiveCheck(false);
            }
        else if(!fuseInPlace && (energyRestored || powerIsOn))
        {
            powerIsOn = false;
            energyRestored = false;
            PowerObjectiveCheck(false);
        }
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
