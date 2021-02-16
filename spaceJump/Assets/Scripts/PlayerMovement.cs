using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public float speed = .5f;
    public float jumpForce = 10f;
    public bool isGrounded = true;
    public Animator playerAnimator;
     // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerRb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, playerRb.velocity.y);
        if(isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRb.AddForce(Vector2.up * jumpForce);
                isGrounded = false;
                GetComponent<AudioSource>().Play();
                if(!isGrounded)
                {
                    playerAnimator.SetBool("isWalking", false);
                    if(Input.GetAxis("Horizontal") < 0 )
                    {
                        playerAnimator.SetTrigger("Jumped");
                        GetComponent<SpriteRenderer>().flipX = true;
                    } else if(Input.GetAxis("Horizontal") >= 0)
                    {
                        playerAnimator.SetTrigger("Jumped");
                        GetComponent<SpriteRenderer>().flipX = false;
                    }
                }
            }
        }
        if(Input.GetAxis("Horizontal") == 0)
        {
            playerAnimator.SetBool("isWalking", false);
        } 
        else if(Input.GetAxis("Horizontal") < 0)
        {
            playerAnimator.SetBool("isWalking", true);
            GetComponent<SpriteRenderer>().flipX = true;
        } 
        else if(Input.GetAxis("Horizontal") > 0)
        {
            playerAnimator.SetBool("isWalking", true);
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }
}
