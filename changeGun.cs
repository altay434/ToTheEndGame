using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeGun : MonoBehaviour
{
    GameObject player;
    GameObject silahSpawn;
    GameObject silah;
    void Start()
    {
        
       silahSpawn = GameObject.Find("silahSpawn");
       player = GameObject.Find("player");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q)){
            Destroy(silah);
            GetComponent<PlayerStats>().currentSilah = null;
            GetComponent<PlayerStats>().hasSilah = false;
            StopAllCoroutines();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetComponent<PlayerStats>().hasSilah == false && (collision.gameObject.tag == "silah1" || 
                                                              collision.gameObject.tag == "silah2" || 
                                                              collision.gameObject.tag == "silah3") && 
                                                              GetComponent<PlayerStats>().isAvaible == true)
        {
            GetComponent<PlayerStats>().hasSilah = true;
            GetComponent<PlayerStats>().currentSilah = collision.gameObject;
            silah = collision.gameObject;

            collision.gameObject.transform.position = new Vector2(silahSpawn.transform.position.x, silahSpawn.transform.position.y);
            collision.gameObject.transform.rotation = silahSpawn.transform.rotation;
            collision.gameObject.transform.SetParent(silahSpawn.transform);
            StartCoroutine(reset());

        }
    }
    IEnumerator reset()
    {

        if(GetComponent<PlayerStats>().currentSilah != null)
        {
            yield return new WaitForSeconds(10);
            GetComponent<PlayerStats>().currentSilah = null;
            GetComponent<PlayerStats>().hasSilah = false;
            Destroy(silah);
            
        }
    }
}
