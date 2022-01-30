using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    private void Start()
    {
        AudioListener.volume = Settings.appSettings.Volume;
        GetComponent<AudioSource>().volume = 1;
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            AudioListener.volume = Settings.appSettings.Volume;
            GetComponent<AudioSource>().volume = Settings.appSettings.Music;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
            Destroy(gameObject);
    }
}
