using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    RaycastHit hit;

    [SerializeField] float distance =4f;
    [SerializeField] GameObject pickupMessage;
    private AudioSource myPlayer;

    private float rayDistance;
    private bool canSeePickup=false;
    
    void Start()
    {
        pickupMessage.gameObject.SetActive(false);
        rayDistance=distance;
        myPlayer=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position,transform.forward,out hit, rayDistance) )
        {
            if(hit.transform.tag=="Apple")
            {
                canSeePickup=true;
                if(Input.GetKeyDown(KeyCode.E))
                {
                    if(SaveScript.apples<6)
                    {
                        Destroy(hit.transform.gameObject);
                        myPlayer.Play();
                        ++SaveScript.apples; 
                    }   
                }
            }

            else if(hit.transform.tag=="Batterry")
            {
                canSeePickup=true;
                if(Input.GetKeyDown(KeyCode.E))
                {
                    if(SaveScript.battries < 4)
                    {
                        Destroy(hit.transform.gameObject);
                        myPlayer.Play();
                        ++SaveScript.battries;
                    }    
                }
            }

            else
            {
                canSeePickup=false;
            }
        }

        if(canSeePickup)
        {
            pickupMessage.gameObject.SetActive(true);
            rayDistance=1000;
        }
        if(!canSeePickup)
        {
            pickupMessage.gameObject.SetActive(false);
            rayDistance=distance; 
        }
    }
}
