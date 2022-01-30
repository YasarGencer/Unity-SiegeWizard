using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public GameObject before, after;
    public Animator fade;
    bool isBefore = true;
    public bool pressable = true;
    private GameObject player;
    public AudioSource FadeS;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && pressable)
        {
            StartCoroutine(ChangeTime());
        }

    }
    IEnumerator ChangeTime()
    {
        pressable = false;

        player.GetComponent<PlayerScript>().hiz = 0;
        //cam.SetTrigger("time");
        fade.SetTrigger("fade");
        FadeS.Play();
        yield return new WaitForSeconds(1f);
        {
            player.GetComponent<PlayerScript>().hiz = player.GetComponent<PlayerScript>().hizHolder;
            FadeS.Stop();
            if (isBefore)
            {
                after.SetActive(true);
                before.SetActive(false);
                isBefore = false;
            }
            else
            {
                before.SetActive(true);
                after.SetActive(false);
                isBefore = true;
            }
        }
        yield return new WaitForSeconds(1f);
        pressable = true;
    }
}
