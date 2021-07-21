using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackgroundImage : MonoBehaviour
{

    public GameObject[] canvasLimits;
    public GameObject[] imageLimits;

    public bool goingUp;

    void Update()
    {
        if(goingUp)
        {
            transform.Translate(Vector3.up * Time.deltaTime * 2);
            if(imageLimits[1].transform.position.y >= canvasLimits[1].transform.position.y)
                goingUp = !goingUp;

        }
        else
        {
            transform.Translate(Vector3.down * Time.deltaTime * 2);
            if(imageLimits[0].transform.position.y <= canvasLimits[0].transform.position.y)
                goingUp = !goingUp;
        }
    }
}
