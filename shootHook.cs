using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootHook : MonoBehaviour
{
    GameObject player;
    public GameObject hook;
    GameObject firedHook;
    public GameObject hookObject;
    Transform firePoint;
    public int bulletForce = 30;

    public bool weaponReady=true;
    //public AudioSource bulletAudio;
    void Start()
    {
        player = GameObject.Find("player");
        firePoint = GameObject.Find("firePoint").GetComponent<Transform>();
        hookObject = gameObject.transform.GetChild(0).gameObject;
        hookObject.SetActive(true);
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            if (player.GetComponent<PlayerStats>().currentSilah == this.gameObject && weaponReady == true && player.GetComponent<PlayerStats>().isAvaible == true)
            {
                hookObject.SetActive(false);
                StartCoroutine(Shoot());
            }
            
        }
    }
    IEnumerator Shoot()
    {

        firedHook = Instantiate(hook, firePoint.position, firePoint.rotation);
        weaponReady = false;
        Rigidbody2D rb = firedHook.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        yield return null;
    }
}
