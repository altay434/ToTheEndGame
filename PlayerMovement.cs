using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool right = true;
    GameObject silahPivot;
    void Start()
    {
        silahPivot = GameObject.Find("SilahPivot");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(Vector2.right * Time.deltaTime * GetComponent<PlayerStats>().movementSpeed);
            
            if (!right)
            {
                gameObject.transform.localScale = new Vector2(0.2f, 0.2f);
                silahPivot.transform.localScale = new Vector2(7.70125f, 6.124f);
                right = true;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(Vector2.left * Time.deltaTime * GetComponent<PlayerStats>().movementSpeed);
            
            if (right)
            {
                gameObject.transform.localScale = new Vector2(-0.2f,0.2f);
                silahPivot.transform.localScale = new Vector2(-7.70125f, 6.124f);
                right = false;
            }
        }
        if (Input.GetKey(KeyCode.W) && GetComponent<PlayerStats>().canJump)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 10.0f);
            GetComponent<PlayerStats>().canJump = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(Vector2.down * Time.deltaTime * GetComponent<PlayerStats>().movementSpeed);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Dash());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
         
        if(collision.gameObject.tag == "jumpable")
        {
            GetComponent<PlayerStats>().canJump = true;
        }
        
    }
    IEnumerator Dash()
    {
        GetComponent<PlayerStats>().isAvaible = false;
        GetComponent<PlayerStats>().movementSpeed = 30;
        yield return new WaitForSeconds(0.2f);
        GetComponent<PlayerStats>().isAvaible = true;
        GetComponent<PlayerStats>().movementSpeed = 10;
    }
}
