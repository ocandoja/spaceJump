using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    Rigidbody2D enemyRB;
    float timeBeforeChange;
    public float delay = .5f;
    public float speed;
    Animator enemyAnim;
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRB.velocity = Vector2.right * speed;
        if(speed < 0)
            GetComponent<SpriteRenderer>().flipX = true;
        else
            GetComponent<SpriteRenderer>().flipX = false;
        if(timeBeforeChange < Time.time)
        {
            speed *= -1;
            timeBeforeChange = Time.time + delay;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            if(transform.position.y + .03f < other.transform.position.y){
                enemyAnim.SetBool("IsDead", true);
            }
        }
    }
    public void DisableEnemy(){
        gameObject.SetActive(false);
    }
}
