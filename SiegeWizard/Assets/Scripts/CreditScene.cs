using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScene : MonoBehaviour
{
    public void bitir()
    {
        Destroy(GameObject.Find("AudioManager"));
        SceneManager.LoadScene(0);
    }
}
