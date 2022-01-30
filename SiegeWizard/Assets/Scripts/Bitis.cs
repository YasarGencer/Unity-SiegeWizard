using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bitis : MonoBehaviour
{
    public Animator anim;
    bool anahtar = false;
    public AudioSource collect;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetTrigger("kapan");
            Invoke("Reset", 0.5f);
        }else if (Input.GetKeyDown(KeyCode.Escape))
        {
            anim.SetTrigger("kapan");
            Invoke("MainMenu", 0.5f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Anahtar")
        {
            anahtar = true;
            collect.Play();
            Destroy(collision.gameObject);
        }
        if (collision.name == "Bitis" && anahtar)
        {
            anim.SetTrigger("kapan");
            Invoke("Kapan", 0.5f);
        }
    }

    public void Kapan()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
