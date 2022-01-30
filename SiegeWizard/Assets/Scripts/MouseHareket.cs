using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHareket : MonoBehaviour
{
    public float maxRange, minRange;
    private Vector3 mousePoziton;
    private Rigidbody2D rb;
    private Vector2 direction;
    private float moveSpeed = 100f;
    private bool ableToMove = true;
    public bool moving = false;
    GameObject player;
    public ParticleSystem movingEffect;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Vector3.Distance(player.transform.position, this.transform.position) > minRange && Vector3.Distance(player.transform.position,this.transform.position) < maxRange && ableToMove)
            {
                moving = true;
                if (!movingEffect.isPlaying)
                    movingEffect.Play();
                mousePoziton = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                direction = (mousePoziton - transform.position).normalized;
                rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
            }
            else
            {
                moving = false;
                movingEffect.Stop();
            }
        }
        else
        {
            moving = false;
            movingEffect.Stop();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ableToMove = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ableToMove = true;
        }
    }
}
