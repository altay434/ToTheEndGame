using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hookScript : MonoBehaviour
{
    GameObject player;
    bool isPlayerReady = false;
    void Start()
    {
        player = GameObject.Find("player");
        gameObject.transform.SetParent(player.GetComponent<PlayerStats>().currentSilah.transform);
    }
    void Update()
    {
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        Vector2 dir = transform.position - player.transform.position;
        player.GetComponent<Rigidbody2D>().AddForce(dir * 150 * Time.deltaTime, ForceMode2D.Impulse);
        Destroy(this.gameObject);
        //GameObject.FindGameObjectWithTag("silah2").GetComponent<shootHook>().weaponReady = true;
        //GameObject.FindGameObjectWithTag("silah2").GetComponent<shootHook>().hookObject.SetActive(true);
        GetComponentInParent<shootHook>().weaponReady = true;
        GetComponentInParent<shootHook>().hookObject.SetActive(true);
    }
}
