﻿/*
* Zach Wilson
* CIS 350 - Group Project
* This script should be controlling every audio source in the game to be sure it is following the set settings in Audio Settings Manager
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script should get attached to any game object that has an audio source
public class SourceManager : MonoBehaviour
{
    private AudioSource goAS;
    private float defaultVolume;
    public bool affectedByGlobalVol;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            goAS = GetComponent<AudioSource>();
        }
        catch
        {
            Debug.LogError("Couldn't get the audio source!!!");
        }

        defaultVolume = goAS.volume;
    }

    // Update is called once per frame
    void Update()
    {
        goAS.mute = !GlobalSettings.bUnMuted;
        if(affectedByGlobalVol)
        {
            goAS.volume = defaultVolume * GlobalSettings.volume;
        }
        else 
        {
            goAS.volume = defaultVolume;
        }
    }
}
