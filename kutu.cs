using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kutu : MonoBehaviour
{
    public GameObject[] weapons;
    GameObject weapon;
    GameObject spawnedWeapon;
    GameObject player;
    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "bullet" || collision.collider.tag == "laser" || (collision.collider.tag == "Player" && player.GetComponent<PlayerStats>().isAvaible == true))
        {
            weapon = weapons[Random.Range(0,3)];
            spawnedWeapon = Instantiate(weapon.gameObject,transform.position,transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
