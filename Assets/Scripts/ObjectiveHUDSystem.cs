using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.UIElements;

public class ObjectiveHUDSystem : MonoBehaviour
{
    public Transform canvasTopRight;
    public Transform[] objectiveSystemPoints;
    public TMP_Text objectiveTitle;
    public TMP_Text objectiveText;
    public int objectiveBeingShown;

    public enum ObjectiveSystemFases
    {
        WAITING_FOR_COMPLETION,
        HIDING,
        CHANGING_OBJECTIVE,
        SHOWING
    }
    public ObjectiveSystemFases fases;

    // Start is called before the first frame update
    void Start()
    {
        objectiveBeingShown = 0; //star with objective 0
        fases = ObjectiveSystemFases.CHANGING_OBJECTIVE; //start on fase changing objective
    }

    // Update is called once per frame
    void Update()
    {
        switch(fases)
        {
            case ObjectiveSystemFases.WAITING_FOR_COMPLETION:

                if(GameController.instance.actualObjective > objectiveBeingShown) //Check if objective has changed
                {
                    fases = ObjectiveSystemFases.HIDING; //Start change on screen
                }

            break;

            case ObjectiveSystemFases.HIDING:

                if(objectiveSystemPoints[0].position.x <= canvasTopRight.position.x) //Check if isn't hided in screen
                    transform.Translate(Vector3.right * Time.deltaTime * 1000); //continue moving
                else //if is hided
                    fases = ObjectiveSystemFases.CHANGING_OBJECTIVE; //change to next fase

            break;

            case ObjectiveSystemFases.CHANGING_OBJECTIVE:
                
                if(LanguageSystem.Fields["objective.title"] != null)
                {
                    objectiveBeingShown = GameController.instance.actualObjective; //Set new Objective
                    objectiveTitle.text = LanguageSystem.Fields["objective.title"]+ " " + objectiveBeingShown; //Set new title to objective
                    objectiveText.text = LanguageSystem.Fields["objective."+objectiveBeingShown]; //Set new text to objective

                    fases = ObjectiveSystemFases.SHOWING; //change to next fase
                }

            break;

            case ObjectiveSystemFases.SHOWING:

                if(objectiveSystemPoints[1].position.x >= canvasTopRight.position.x) //check if objective isn't showing
                    transform.Translate(Vector3.left * Time.deltaTime * 600); // continue moving
                else //if is showing
                    fases = ObjectiveSystemFases.WAITING_FOR_COMPLETION; //go back to first fase

            break;
        }
    }
}
