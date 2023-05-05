using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<Room> rooms;

    public void TurnOnEnergy(string roomName)
    {
        rooms.Find(x => x.roomName == roomName).ToggleEnergy(true);
    }

    public void TurnOffEnergy(string roomName)
    {
        rooms.Find(x => x.roomName == roomName).ToggleEnergy(false);
    }

    public Room GetRoom(string roomName)
    {
        return rooms.Find(x => x.roomName == roomName);
    }

}
