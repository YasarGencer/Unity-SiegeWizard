using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float hiz, jump, hizHolder, jumpCount = 2, jumpHolder = 2;
    KutuCekmeItme kutu;
    Rigidbody2D rb;
    public ParticleSystem jumpParticle, walkParticle, movingParticle;
    MouseHareket yesilKutu;
    public AudioSource walkS, jumpS, moveS;
    void Start()
    {
        yesilKutu = GameObject.Find("YesilKutu").GetComponent<MouseHareket>();
        kutu = gameObject.GetComponent<KutuCekmeItme>() as KutuCekmeItme;
        hizHolder = hiz;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        karakter();
    }
    void karakter()
    {
        if (kutu.isGrabbed)
            hiz = hizHolder / 2;
        else if (yesilKutu.moving)
            hiz = hizHolder / 5;
        else if (hiz != 0)
            hiz = hizHolder;

        if (yesilKutu.moving && !movingParticle.isPlaying)
        {
            movingParticle.Play();
            if (!moveS.isPlaying)
                moveS.Play();
        }
        else if (!yesilKutu.moving)
        {
            movingParticle.Stop();
            if (moveS.isPlaying)
                moveS.Stop();
        }
            

        if (Input.GetKey(KeyCode.A))
        {
            if (walkParticle.isPaused || walkParticle.isStopped)
                walkParticle.Play();
            if (!walkS.isPlaying)
                walkS.Play();
            kutu.anim.SetBool("hareket", true);
            this.transform.Translate(-(hiz * Time.deltaTime), 0, 0);
            if (kutu.isGrabbed == false)
                this.transform.localScale = new Vector3(-1, 1, 1);  
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (walkParticle.isPaused || walkParticle.isStopped)
                walkParticle.Play();
            if (!walkS.isPlaying)
                walkS.Play();
            kutu.anim.SetBool("hareket", true);
            this.transform.Translate((hiz * Time.deltaTime), 0, 0);
            if (kutu.isGrabbed == false)
                this.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            if(walkParticle.isPlaying)
                walkParticle.Stop();
            if (walkS.isPlaying)
                walkS.Stop();
            kutu.anim.SetBool("hareket", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //this.transform.Translate(0,-(jump * Time.deltaTime), 0);
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {

            if (jumpCount == 2)
                rb.AddForce(transform.up * jump);
            if (jumpCount == 1)
                rb.AddForce(transform.up * jump / 2);
            if (jumpCount > 0)
            {
                jumpParticle.Play();
                jumpS.Play();
            }
            jumpCount--;
        }
    }
}