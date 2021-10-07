using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    RaycastHit hit;

    [SerializeField] float distance =4f;
    [SerializeField] GameObject pickupMessage;

    private float rayDistance;
    private bool canSeePickup=false;
    
    void Start()
    {
        pickupMessage.gameObject.SetActive(false);
        rayDistance=distance;
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
                    Destroy(hit.transform.gameObject);
                    ++SaveScript.apples;    
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
