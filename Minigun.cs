using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Minigun : MonoBehaviour
{
    GameObject player;
    bool weaponReady = true;
    Transform firePoint;
    public GameObject laser;
    void Start()
    {

        player = GameObject.Find("player");
        firePoint = GameObject.Find("firePoint").GetComponent<Transform>();
        laser = player.GetComponent<PlayerStats>().laser;
    }

    // Update is called once per frame
    void Update() {
        if (player.GetComponent<PlayerStats>().currentSilah == this.gameObject)
        {
            if (weaponReady && Input.GetMouseButton(0) && player.GetComponent<PlayerStats>().isAvaible == true)
            {
                laser.SetActive(true);
            }
            else
            {
                laser.SetActive(false);
            }
        }

    }
    
}
