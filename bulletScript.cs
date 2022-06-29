using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public GameObject patlama;
    GameObject effect;
    
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        effect = Instantiate(patlama, gameObject.transform.position,gameObject.transform.rotation);


        Destroy(gameObject, 1f);
        Destroy(effect, 1f);
    }
}
