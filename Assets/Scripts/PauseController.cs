using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    private PauseControls pauseControls;
    private InputAction menu;

    [SerializeField] private GameObject pauseUI;
    [SerializeField] private Slider mouseSlider;
    [SerializeField] private bool isPaused;

    void Awake()
    {
        pauseControls = new PauseControls();
    }

    void OnEnable()
    {
        menu = pauseControls.Action.Escape;
        menu.Enable();

        menu.performed += Pause;
    }

    void OnDisable()
    {
        menu.Disable();
    }

    void Pause(InputAction.CallbackContext context)
    {
        isPaused = !isPaused;

        if (isPaused)
            PauseGame();
        else
            ResumeGame();
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        mouseSlider.value = GameController.instance.playerSystem.player.RotationSpeed = PlayerPrefs.GetFloat("MouseSense");
        GameController.instance.playerSystem.pauseCanvas.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameController.instance.playerSystem.pauseCanvas.SetActive(false);
        isPaused = false;
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void ChangeMouseSensitivity(System.Single newValue)
    {
        PlayerPrefs.SetFloat("MouseSense", newValue);
        GameController.instance.playerSystem.player.RotationSpeed = (float)newValue;
    }
}
