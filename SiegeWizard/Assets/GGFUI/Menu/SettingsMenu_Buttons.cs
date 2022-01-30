using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu_Buttons : MonoBehaviour
{
    public Dropdown screenMode;
    public Dropdown resolution;
    public Slider volume;
    public Slider music;

    void Start()
    {
        AudioListener.volume = Settings.appSettings.Volume;
        volume.value = Settings.appSettings.Volume;
        music.value = Settings.appSettings.Music;

        switch (Screen.fullScreenMode)
        {
            case FullScreenMode.ExclusiveFullScreen:
                screenMode.value = 0;
                break;
            case FullScreenMode.FullScreenWindow:
                screenMode.value = 1;
                break;
            case FullScreenMode.Windowed:
                screenMode.value = 2;
                break;
            case FullScreenMode.MaximizedWindow:
                screenMode.value = 3;
                break;
            default:
                screenMode.value = 0;
                break;
        }

        resolution.captionText.text = string.Format("{0} x {1}", Screen.currentResolution.width, Screen.currentResolution.height);
    }

    public void FullScreenMode_CheckChange()
    {
        switch (screenMode.value)
        {
            case 0:
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                break;
            case 1:
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                break;
            case 2:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                break;
            case 3:
                Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
                break;
            default:
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                break;
        }
    }

    public void Resolution_Change()
    {
        int height;
        int width;

        switch (resolution.value)
        {
            case 0:
                width = 1920;
                height = 1080;
                break;
            case 1:
                width = 1024;
                height = 768;
                break;
            case 2:
                width = 1366;
                height = 768;
                break;
            case 3:
                width = 1440;
                height = 900;
                break;
            case 4:
                width = 2560;
                height = 1440;
                break;
            default:
                width = 1920;
                height = 1080;
                break;
        }

        Screen.SetResolution(width, height, Screen.fullScreen);
    }

    public void Volume_Change()
    {
        AudioListener.volume = volume.value;
        Settings.appSettings.Volume = volume.value;
    }

    public void Music_Change()
    {
        Settings.appSettings.Music = music.value;
    }
}
