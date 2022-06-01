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
    public bool hasDied=false;

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
                anim.SetBool("isDead", true);
                Destroy(enemyObject,25f);
            }
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("PKnife"))
        {
            enemyHealth-=10;
            audioSource.Play();
            stabPlayer.Play();
        }

        if(other.CompareTag("PBat"))
        {
            enemyHealth-=15;
            audioSource.Play();
            stabPlayer.Play();
        }

        if(other.CompareTag("PAxe"))
        {
            enemyHealth-=20;
            audioSource.Play();
            stabPlayer.Play();
        }    
    }
}
