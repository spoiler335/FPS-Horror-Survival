using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotSound : MonoBehaviour
{
    private AudioSource oneShot;
    private Collider  collider;

    [SerializeField] bool oneTime=false;
    [SerializeField] float pauseTime=5.0f;

    void Start()
    {
        oneShot=GetComponent<AudioSource>();
        collider=GetComponent<Collider>();
    }

     void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            oneShot.Play();
            collider.enabled=false;

            if(!oneTime)
            {
                StartCoroutine(Reset());
            }
            else
            {
                Destroy(gameObject,pauseTime);
            }
        }    
    }

    IEnumerator Reset() 
    {  
        yield return new WaitForSeconds(pauseTime);
        collider.enabled=true;    
    }

    
}
