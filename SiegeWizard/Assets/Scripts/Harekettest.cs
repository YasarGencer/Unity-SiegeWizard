using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harekettest : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject cam;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 10);

        if (Input.GetKey("a"))
        {
            this.transform.position = new Vector2(transform.position.x - .1f, transform.position.y);
        }
        if (Input.GetKey("d"))
        {
            this.transform.position = new Vector2(transform.position.x + .1f, transform.position.y);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * 300);
        }
    }
}
