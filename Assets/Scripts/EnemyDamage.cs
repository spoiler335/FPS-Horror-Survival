using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    
    public int enemyHealth=100;
    private AudioSource audioSource;
    [SerializeField] AudioSource stabPlayer;
    private Animator anim;
    [SerializeField] GameObject enemyObject;
    public bool hasDied=false;
    [SerializeField] GameObject bloodSplatKnife;
    [SerializeField] GameObject bloodSplatBat;
    [SerializeField] GameObject bloodSplatAxe;

    void Start()
    {
        audioSource=GetComponent<AudioSource>();
        anim=GetComponentInParent<Animator>();
        bloodSplatKnife.SetActive(false);
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
            bloodSplatKnife.SetActive(true);
        }

        if(other.CompareTag("PBat"))
        {
            enemyHealth-=15;
            audioSource.Play();
            stabPlayer.Play();
            bloodSplatBat.SetActive(true);
        }

        if(other.CompareTag("PAxe"))
        {
            enemyHealth-=20;
            audioSource.Play();
            stabPlayer.Play();
            bloodSplatAxe.SetActive(true);
        }

        if(other.CompareTag("PCrossbow"))
        {
            enemyHealth-=50;
            audioSource.Play();
            stabPlayer.Play();
            Destroy(other.gameObject, 0.05f);
        }    
    }
}
