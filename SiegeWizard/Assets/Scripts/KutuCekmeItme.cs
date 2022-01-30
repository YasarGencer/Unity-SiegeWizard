using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KutuCekmeItme : MonoBehaviour
{
    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDist;

    //playerscripte veri gönderiyor
    public bool isGrabbed = false;
    TimeManager time;
    public Animator anim;
    private void Start()
    {
        time = GameObject.Find("TimeManager").GetComponent<TimeManager>();
    }
    void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.lossyScale, rayDist);
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (isGrabbed)
            {
                anim.SetBool("cekme", false);
                isGrabbed = false;
                time.pressable = true;
                if (grabCheck)
                    if (grabCheck.collider.gameObject.CompareTag("kutu"))
                    {
                        grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                        grabCheck.collider.gameObject.transform.parent = null;
                    }       
            }
            else
            {
                if (grabCheck)
                    if (grabCheck.collider.gameObject.CompareTag("kutu"))
                    {
                        anim.SetBool("cekme", true);
                        anim.SetTrigger("cekmeT");
                        isGrabbed = true;
                        time.pressable = false;
                    }
            }
            
        }
        if (isGrabbed)
            Move(grabCheck.collider.gameObject);
    }
    void Move(GameObject grab)
    {
        if (grab.gameObject.CompareTag("kutu"))
        {
            grab.transform.parent = boxHolder;
            grab.transform.position = boxHolder.position;
            grab.transform.rotation = new Quaternion(0, 0, 0, 0);
            grab.GetComponent<Rigidbody2D>().isKinematic = true;
            grab.transform.parent = null;
        }
    }
}
