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

            else if(hit.transform.tag=="Knife")
            {
                canSeePickup=true;
                if(Input.GetKeyDown(KeyCode.E))
                {
                    if(!SaveScript.Knife)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.Knife=true;
                        myPlayer.Play();
                    }
                }
                
            }

            else if(hit.transform.tag=="Gun")
            {
                canSeePickup=true;
                if(Input.GetKeyDown(KeyCode.E))
                {
                    if(!SaveScript.Gun)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.Gun=true;
                        myPlayer.Play();
                    }
                }
                
            }

            else if(hit.transform.tag=="Bat")
            {
                canSeePickup=true;
                if(Input.GetKeyDown(KeyCode.E))
                {
                    if(!SaveScript.Bat)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.Bat=true;
                        myPlayer.Play();
                    }
                }
            }

            else if(hit.transform.tag=="CrossBow")
            {
                canSeePickup=true;
                if(Input.GetKeyDown(KeyCode.E))
                {
                    if(!SaveScript.Crossbow)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.Crossbow=true;
                        myPlayer.Play();
                    }
                }
            }

            else if(hit.transform.tag=="Axe")
            {
                canSeePickup=true;
                if(Input.GetKeyDown(KeyCode.E))
                {
                    if(!SaveScript.Axe)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.Axe=true;
                        myPlayer.Play();
                    }
                }
            }

            else if(hit.transform.tag=="CabinKey")
            {
                canSeePickup=true;
                if(Input.GetKeyDown(KeyCode.E))
                {
                    if(!SaveScript.hasCabinKey)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.hasCabinKey=true;
                        myPlayer.Play();
                    }
                }
            }

            else if(hit.transform.tag=="RoomKey")
            {
                canSeePickup=true;
                if(Input.GetKeyDown(KeyCode.E))
                {
                    if(!SaveScript.hasRoomKey)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.hasRoomKey=true;
                        myPlayer.Play();
                    }
                }
            }

            else if(hit.transform.tag=="HouseKey")
            {
                canSeePickup=true;
                if(Input.GetKeyDown(KeyCode.E))
                {
                    if(!SaveScript.hasHouseKey)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.hasHouseKey=true;
                        myPlayer.Play();
                    }
                }
            }

            else if(hit.transform.tag=="Magzine")
            {
                canSeePickup=true;
                if(Input.GetKeyDown(KeyCode.E))
                {
                    if(SaveScript.bulletClips<4)
                    {
                        Destroy(hit.transform.gameObject);
                        ++SaveScript.bulletClips;
                        myPlayer.Play();
                    }
                }
            }

            else if(hit.transform.tag=="Arrows")
            {
                canSeePickup=true;
                if(Input.GetKeyDown(KeyCode.E))
                {
                    if(!SaveScript.arrowRefil)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.arrowRefil=true;
                        myPlayer.Play();
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
