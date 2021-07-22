using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class SetLanguage : MonoBehaviour
{
    public string TextId;
    public bool setNewText;

    void Start()
    {
        Invoke("getTextType", 0.01f);
    }


    private void Update() 
    {
        if(setNewText)
        {
            setNewText = false;
            getTextType();
        }
    }

    void getTextType()
    {
        if(LanguageSystem.Fields.Count <= 1)
        {
            Invoke("getTextType", 0.5f);
            print("LanguageSystem not found!");
            return;
        }

        if(!LanguageSystem.Fields.ContainsKey(TextId))
        {
            Invoke("getTextType", 0.5f);
            print("TextId not found!");
            return;
        }

        if(GetComponent<Text>() != null)
        {
            OnlyText(GetComponent<Text>());
        }
        else if(GetComponent<TMP_Text>() != null)
        {
            OnlyTextMeshPro(GetComponent<TMP_Text>());
        }
    }

    void OnlyText(Text text)
    {
        if (text != null)
            if(TextId == "ISOCode")
                text.text = LanguageSystem.GetLanguage();
            else
                text.text = LanguageSystem.Fields[TextId];
        else
            text.text = "Erro!";
    }

    void OnlyTextMeshPro(TMP_Text text)
    {
        if (text != null)
            if(TextId == "ISOCode")
                text.text = LanguageSystem.GetLanguage();
            else
            {
                text.text = LanguageSystem.Fields[TextId];
                text.text += " ";

            }
        else
            text.text = "Erro!";
    }
}
