using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonChangeScene : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene(0); //Menu
    }

    public void Game()
    {
        SceneManager.LoadScene(1); //Game
    }

    public void Credits()
    {
        SceneManager.LoadScene(2); //Credits
    }
}
