using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public static Settings appSettings = new Settings();
    private void Start()
    {
        AudioListener.volume = 1;
    }
    public float Volume = 1;
    public float Music = 1;
}
