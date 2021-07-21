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
            print("THE END!");
            SceneManager.LoadScene(2); //Credits
        }
    }
}
