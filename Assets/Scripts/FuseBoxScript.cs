using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FuseBoxScript : MonoBehaviour
{
    public List<FuseArea> fuses;

    public Material[] buttonMaterials;

    public AudioSource fuseAudio, buttonAudio, fuseExplosion;

    public void PlaceFuse()
    {
        if(GameController.instance.playerSystem.inventory.Contains("FUSE")) //If you have the fuse
        {
            GetFuseArea("LABORATORY").AddFuse();

            GameController.instance.playerSystem.inventory.Remove("FUSE"); //Remove fuse from inventory

            fuseAudio.Play(); //Play fuse placemente audio
        }
    }

    public FuseArea GetFuseArea(string areaName)
    {
        return fuses.Find(x => x.fuseAreaName == areaName);
    }

}
