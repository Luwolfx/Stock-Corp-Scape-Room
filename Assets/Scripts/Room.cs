using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public string roomName;
    public bool hasEnergy;
    public List<GameObject> energyObjects;

    public void ToggleEnergy(bool toggle)
    {
        hasEnergy = toggle;
        foreach (GameObject energyObj in energyObjects)
        {
            if(energyObj.GetComponent<Server>())
                energyObj.GetComponent<Server>().isOn = toggle;
            else
                energyObj.SetActive(toggle);
        }
    }
}
