using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    int hp = 3; 
    public Image[] hearts;
    bool hasCooldown = false;
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Enemy")){
            if(GetComponent<PlayerMovement>().isGrounded){
                SubtractHealth();
            }
        }
    }
    void SubtractHealth(){
        if(!hasCooldown){
            if(hp > 0){
                hp--;
                hasCooldown = true;
                StartCoroutine(Cooldown());
            }
            if(hp <= 0){
                // add the scene changer
            }
            EmptyHearts();
        }
    }
    void EmptyHearts(){
        for(int i = 0; i < hearts.Length; i++){
            if(hp -1 < i)
                hearts[i].gameObject.SetActive(false);
        }
    }
    IEnumerator Cooldown(){
        yield return new WaitForSeconds(.5f);
        hasCooldown = false;
        StopCoroutine(Cooldown());
    }
}
