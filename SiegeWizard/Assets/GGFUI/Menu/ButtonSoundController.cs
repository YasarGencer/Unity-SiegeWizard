using UnityEngine;

public class ButtonSoundController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip mouseOver;
    public AudioClip mouseClick;

    private void Start()
    {
        audioSource = GameObject.Find("ButtonsAudioSource").GetComponent<AudioSource>();
        mouseOver = Resources.Load<AudioClip>("mouse_over");
        mouseClick = Resources.Load<AudioClip>("mouse_click");
    }

    public void PlayMouseOverClip()
    {
        audioSource.PlayOneShot(mouseOver);
    }

    public void PlayMouseClickClip()
    {
        audioSource.PlayOneShot(mouseClick);
    }
}
