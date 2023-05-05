using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Server : MonoBehaviour
{
    public bool isOn;
    public Material powerOffMat, offMat, onMat;

    // Update is called once per frame
    void Update()
    {
        if(GameController.instance.mapController.GetRoom("LABORATORY").hasEnergy) // if energy is on
        {
            if(isOn) gameObject.GetComponent<MeshRenderer>().material = onMat; //if server is on change material to green
            else gameObject.GetComponent<MeshRenderer>().material = offMat; //if server is off change material do red
        }
        else // if energy isn't onn
        {
            gameObject.GetComponent<MeshRenderer>().material = powerOffMat; //if power is off chanfe material to black
        }
    }

    public void PowerOnOff()
    {
        if(GameController.instance.mapController.GetRoom("LABORATORY").hasEnergy) //If has energy
        {
            if(isOn) isOn = false; else isOn = true; // Turn power on/off
            GameController.instance.ServerObjectiveCheck();
        }
    }
}
