using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private float speed = 0f;
    private float moveDuration = 1f;

    public Rigidbody2D rb;
    public Animator animator;
    private bool m_FacingRight = true;
    public Transform startingPoint;
    public bool intro;
    private Collider2D col;

    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        
      col = GetComponent<Collider2D>();
        StartCoroutine(startmove(startingPoint.position));
        
        
    }
   
    void Update()
    {
     
       movement.x = Input.GetAxisRaw("Horizontal");
       
       if(movement.x > 0)
       {
            speed = moveSpeed;
            
       }
       else if(movement.x < 0)
       {
            speed = moveSpeed;
           
       }
       else if(movement.x == 0)
       {
            speed = 0f;
       }
       if (movement.x < 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (movement.x > 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
       movement.y = Input.GetAxisRaw("Vertical");
       animator.SetFloat("Speed", speed);
    }

  
    void FixedUpdate()
    {

      rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }
 

    
     private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
  

     IEnumerator startmove(Vector3 targetPosition)
     {
          Vector3 startPosition = transform.position;
          float timeElapsed = 0;
          while (timeElapsed < moveDuration)
          {
               transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed / moveDuration);
               timeElapsed += Time.deltaTime;
               yield return null;
          }
          
            
     }
      void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "ShopCollider")
        {
            
           Debug.Log("Open shop");
           
        }
    }
   
}
