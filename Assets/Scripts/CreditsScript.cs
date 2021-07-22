using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CreditsScript : MonoBehaviour
{
    public Transform canvasBottom;

    public Transform creditsEnd;

    public TMP_Text gameTime;


    void Start()
    {
        //Show Cursor
        Cursor.visible = true;

        //Unlock Cursor
        Cursor.lockState = CursorLockMode.None;

        //Set GameTime
        if(PlayerPrefs.GetString("last_game_time") != null) //If has gameTime
            gameTime.text = LanguageSystem.Fields["credits.gametime"] + 
            "<br><color=#5AA19F>" + PlayerPrefs.GetString("last_game_time", "--:--") + "</color>"; //Show GameTime
        else //if hasn't gameTime
            gameTime.text = ""; //Hide GameTime Text
    }

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * 15); //Roll credits to top

        if(creditsEnd.position.y >= canvasBottom.position.y) //If credits ended
            SceneManager.LoadScene(0); //Go back to menu
    }
}
