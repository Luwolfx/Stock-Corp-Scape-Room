using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseArea : MonoBehaviour
{
    public string fuseAreaName;
    public Room fuseRoom;
    public FuseBoxScript fuseBoxScript;
    public bool canTurnOffEnergy;

    [Header("States")]
    public State actualState;
    public bool isOn;

    [Header("Objects")]
    public GameObject fuseObject;
    public GameObject brokenFuseObject;
    public GameObject fuseEmpty;
    public MeshRenderer fuseButton;
    public enum State
    {
        EMPTY,
        BROKEN,
        NORMAL
    }

    private void Start()
    {
        LoadActualState();
    }

    public void ToggleEnergy()
    {
        ToggleEnergy(!isOn);
    }

    public void ToggleEnergy(bool toggle)
    {
        fuseBoxScript.buttonAudio.Play();

        if (!toggle && canTurnOffEnergy || toggle)
        {
                if(toggle && actualState == State.NORMAL)
                {
                    if (fuseAreaName == "LABORATORY")
                        GameController.instance.ChangeObjective(4);

                    if (fuseAreaName == "STORAGE")
                        GameController.instance.ChangeObjective(9);
                }

            isOn = toggle;
            LoadActualState();
        }
    }

    public void AddFuse()
    {
        if (GameController.instance.playerSystem.inventory.Contains("FUSE")) //If you have the fuse
        {
            SetState(State.NORMAL);

            GameController.instance.playerSystem.inventory.Remove("FUSE"); //Remove fuse from inventory

            fuseBoxScript.fuseAudio.Play(); //Play fuse placemente audio
        }
    }

    public void RemoveFuse()
    {
        if(actualState == State.BROKEN)
        {
            if (fuseAreaName == "STORAGE")
                GameController.instance.ChangeObjective(8);

            fuseBoxScript.fuseAudio.Play(); //Play fuse placemente audio
            SetState(State.EMPTY);
        }

    }

    public void BreakFuse()
    {
        fuseBoxScript.fuseExplosion.Play();
        SetState(State.BROKEN);
    }

    void SetState(State state)
    {
        actualState = state;
        LoadActualState();
    }

    void LoadActualState()
    {
        switch (actualState)
        {
            case State.EMPTY:
                if (isOn) isOn = false;
                fuseObject.SetActive(false);
                brokenFuseObject.SetActive(false);
                fuseEmpty.SetActive(true);
                break;

            case State.BROKEN:
                if (isOn) isOn = false;
                fuseObject.SetActive(false);
                brokenFuseObject.SetActive(true);
                fuseEmpty.SetActive(false);
                break;

            case State.NORMAL:
                fuseObject.SetActive(true);
                brokenFuseObject.SetActive(false);
                fuseEmpty.SetActive(false);
                break;
        }
        LoadButtonState();
    }

    void LoadButtonState()
    {
        switch(actualState)
        {
            case State.NORMAL:

                if (isOn)
                {
                    fuseButton.material = fuseBoxScript.buttonMaterials[2];
                    fuseRoom.ToggleEnergy(true);
                }
                else
                {
                    fuseButton.material = fuseBoxScript.buttonMaterials[1];
                    fuseRoom.ToggleEnergy(false);
                }

                break;

            default:
                fuseButton.material = fuseBoxScript.buttonMaterials[0];
                fuseRoom.ToggleEnergy(false);
                break;
        }
    }

}
