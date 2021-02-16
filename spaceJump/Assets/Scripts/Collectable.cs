using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    public static int collectableQuan = 0;
    Text collectableText;
    ParticleSystem collectablePart;
    AudioSource collectableAudi;
    // Start is called before the first frame update
    void Start()
    {
        collectableText = GameObject.Find("CollectableQuantityText").GetComponent<Text>();
        collectablePart = GameObject.Find("CollectableParticle").GetComponent<ParticleSystem>();
        collectableAudi = GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            collectablePart.transform.position = transform.position;
            collectablePart.Play();
            collectableAudi.Play();
            gameObject.SetActive(false);
            collectableQuan ++;
            collectableText.text = collectableQuan.ToString();
        }
    }
}
