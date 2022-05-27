using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    
    public int enemyHealth=100;
    private AudioSource audioSource;

    void Start()
    {
        audioSource=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Knife"))
        {
            enemyHealth-=50;
            audioSource.Play();
        }    
    }
}
