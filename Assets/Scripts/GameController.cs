using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [Header("Game Statistics")]
    public string totalGameTime;
    public TMP_Text totalGameTime_Text;
    private float gameStartedTime;

    [Header("Game Mechanics")]
    public MapController mapController;
    public FuseBoxScript fuseBox;
    public PlayerSystem playerSystem;
    
    [Header("Objectives")]
    public int actualObjective;

    [Header("Objective - Energy")]
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
        actualObjective = 0;

        //Servers
        foreach(Server s in servers) //ForEach Server
        {
            s.isOn = false; //Start off
        }

        //Cursor Lock to center
        Cursor.lockState = CursorLockMode.Locked;

        gameStartedTime = Time.time;

        playerSystem.player.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        GameTimer(); //Calculate GameTime

        if(playerSystem.inventory.Contains("FUSE")) //If has fuse in inventory
            fuse_HUD_Icon.SetActive(true); //Show fuse icon in HUD
        else //If hasn't fuse in inventory
            fuse_HUD_Icon.SetActive(false); //Hide fuse icon in HUD
    }

    void GameTimer()
    {
        float t = Time.time - gameStartedTime; //get total time
        int min = ((int)t / 60); //Calculate minutes
        int secs = ((int)t % 60); //calculate seconds

        //TIMER
        totalGameTime = min + ":"; //put minutes in totalGameTime
        if(secs > 9) totalGameTime+= secs; else totalGameTime+= "0"+secs; //put seconds in totalGameTime
        totalGameTime_Text.text = totalGameTime; //Put timer in HUD
    }

    public void BreakStorageLights()
    {
        if(actualObjective == 6)
        {
            ChangeObjective(7);
            fuseBox.GetFuseArea("STORAGE").BreakFuse();
        }
    }

    public void SaveGameTime()
    {
        PlayerPrefs.SetString("last_game_time", totalGameTime); //Save GameTime in a PlayerPref
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

            ChangeObjective(6);
            serversObjectiveHint.SetActive(false); //Disable server hints
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

    public void ChangeObjective(int objNumber)
    {
        if(objNumber > actualObjective) actualObjective = objNumber; //If objective number is more than the actual, change the actual to this.
    }

    public void GetItem(string itemName)
    {
        playerSystem.inventory.Add(itemName);
    }

}
