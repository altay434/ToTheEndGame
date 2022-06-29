using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMechanics : MonoBehaviour
{
    Vector2 mouse_pos;
    public Rigidbody2D rbSilah;
    float angle;
    

    
    void Update()
    {

        mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.position = GameObject.Find("player").transform.position;
    }
    private void FixedUpdate()
    {
        Vector2 lookDir = mouse_pos - rbSilah.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rbSilah.rotation = angle;
    }
}
