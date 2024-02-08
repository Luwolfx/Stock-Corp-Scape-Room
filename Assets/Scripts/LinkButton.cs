using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkButton : MonoBehaviour
{
    [SerializeField] private string buttonUrl;

    public void ButtonClick()
    {
        Application.OpenURL(buttonUrl);
    }
    
}
