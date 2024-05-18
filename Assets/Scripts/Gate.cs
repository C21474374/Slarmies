using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    private Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        
        col = GetComponent<Collider2D>();
        StartCoroutine(waiter());
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            
           //reload scene restart game
            SceneManager.LoadScene(2);
           
        }
    }
    private IEnumerator waiter()
     {
          yield return new WaitForSeconds(2);
          col.enabled = true;
     }
}
