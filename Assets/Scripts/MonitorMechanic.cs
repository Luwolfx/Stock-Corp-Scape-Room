using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MonitorMechanic : MonoBehaviour
{
    [Header("LOGIN REQUIRED")]
    public string thePassword;
    public string tryedPassword;
    public TMP_Text passwordArea;

    [Header("Areas")]
    public GameObject LoginArea;
    public GameObject LoggedArea;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If player digited 6+ numbers
        if(tryedPassword.Length >= 6)
        {
            if(tryedPassword == thePassword) //If password is correct
            {
                print("Access Granted!"); //Print in console
                PasswordIsCorrect();
            }
            else //If password isn't correct
            {
                print("Wrong Password!"); //Print in console
                PasswordIsIncorrect();
            }
        }
    }


    public void EnterDigit(int digit)
    {
        tryedPassword += digit; //Add digit to try
        passwordArea.text = tryedPassword; //Add password being tryed in the screen area
    }

    public void ResetPasswordPoint()
    {
        tryedPassword = ""; //Reset Password tryed
        passwordArea.text = ""; //Reset Password area in screen
    }

    public void EnterPassword()
    {
        if(tryedPassword == thePassword) //If password is correct
        {
            print("Access Granted!"); //Print in console
            PasswordIsCorrect();
        }
        else //If password isn't correct
        {
            print("Wrong Password!"); //Print in console
            PasswordIsIncorrect();
        }
    }

    public void Loggout()
    {
        PasswordIsIncorrect(); //Resets password

        LoggedArea.SetActive(false); //Dectivate Logged Area
        LoginArea.SetActive(true); //Activate Login Area
    }

    void PasswordIsCorrect()
    {
        LoggedArea.SetActive(true); //Activate Logged Area
        LoginArea.SetActive(false); //Deactivate Login Area
    }

    void PasswordIsIncorrect()
    {
        tryedPassword = ""; //Reset Password tryed
        passwordArea.text = ""; //Reset Password area in screen
    }

    public void PrintToConsole(string text)
    {
        print(text);
    }
}
