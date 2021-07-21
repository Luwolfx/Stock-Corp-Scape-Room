using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardKey : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickAction()
    {
        if(gameObject.GetComponent<Button>()) //Se for um botão
            gameObject.GetComponent<Button>().onClick.Invoke(); //Invoca a ação!
    }
}
