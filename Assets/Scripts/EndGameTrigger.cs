using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider col) 
    {
        if(col.tag == "Player")
        {
            GameController.instance.SaveGameTime(); //Save total Game Time
            print("THE END!");
            SceneManager.LoadScene(2); //Credits
        }
    }
}
