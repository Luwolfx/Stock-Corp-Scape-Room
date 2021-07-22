using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLanguage : MonoBehaviour
{
    public void changeLanguage(string lang)
    {
        LanguageSystem.instance.LoadSpecificLanguage(lang);
    }
}
