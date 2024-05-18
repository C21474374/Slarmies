using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    private Transform player;
    public int coinvalue;
    private AudioSource source;
    
    private Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if(distanceFromPlayer< lineOfSite)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position,speed * Time.deltaTime);
           
        }
    }
      void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            
           //reload scene restart game
           AudioSource.PlayClipAtPoint(source.clip, Vector3.zero);
           PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0)+ coinvalue);
            Destroy(gameObject);
           
        }
    }
  
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,lineOfSite);
    }
}
