using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    
    [SerializeField ] int enemyHealth=100;
    private AudioSource audioSource;
    [SerializeField] AudioSource stabPlayer;
    private Animator anim;
    [SerializeField] GameObject enemyObject;
    private bool hasDied=false;

    void Start()
    {
        audioSource=GetComponent<AudioSource>();
        anim=GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHealth<=0f)
        {
            if(!hasDied)
            {
                hasDied=true;
                anim.SetTrigger("Death");

                Destroy(enemyObject,25f);
            }
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Knife"))
        {
            enemyHealth-=50;
            audioSource.Play();
            stabPlayer.Play();
        }    
    }
}
