using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootBullet : MonoBehaviour
{
    GameObject player;
    public GameObject rocketBullet;
    GameObject firedBullet;
    Transform firePoint;
    public int bulletForce = 30;
    bool weaponReady = true;
    //public AudioSource bulletAudio;
    void Start()
    {
        player = GameObject.Find("player");
        firePoint = GameObject.Find("firePoint").GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (player.GetComponent<PlayerStats>().currentSilah == this.gameObject && weaponReady == true && player.GetComponent<PlayerStats>().isAvaible == true)
            {
                StartCoroutine(Shoot());
            }
        }
    }
    IEnumerator Shoot()
    {
        //AudioSource ses = Instantiate(bulletAudio, firePoint.position, firePoint.rotation);
        //ses.Play();
        //Destroy(ses.gameObject, 3);
        
        
        
        firedBullet = Instantiate(rocketBullet, firePoint.position, firePoint.rotation);
        weaponReady = false;
        Rigidbody2D rb = firedBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.3f);
        weaponReady=true;
    }
}
