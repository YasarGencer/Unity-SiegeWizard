using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("kutu"))
        {
            gameObject.GetComponentInParent<PlayerScript>().jumpCount = gameObject.GetComponentInParent<PlayerScript>().jumpHolder;
        }
    }
}
