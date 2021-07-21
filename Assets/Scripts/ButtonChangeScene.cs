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

    public void QuitGame()
    {
#if UNITY_EDITOR //If is on editor
        UnityEditor.EditorApplication.isPlaying = false; //Closes Editor
#elif UNITY_WEBPLAYER //if is on web
        Application.OpenURL("https://www.lucasgomespalmieri.com.br/"); //Redirect
#else //If isn't anything above
        Application.Quit(); //closes app
#endif
    }

    public void Credits()
    {
        SceneManager.LoadScene(2); //Credits
    }
}
