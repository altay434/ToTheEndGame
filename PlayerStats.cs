using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int movementSpeed = 10;
    public bool canJump = false;
    public bool hasSilah = false;
    public GameObject currentSilah = null;
    public int playerHP = 100;
    public bool isAvaible = true;
    public int speed = 10;
    public GameObject laser;
    public void Update()
    {
        if (playerHP <= 0 || Input.GetKey(KeyCode.R))
        {
            Application.LoadLevel(0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.collider.tag == "enemy" && isAvaible == true)
        {
            playerHP -= 25;
        }
    }
    
    
}


