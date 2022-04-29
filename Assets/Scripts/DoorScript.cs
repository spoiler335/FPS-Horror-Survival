﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    private Animator anim;
    public bool isOpen=false;

    private AudioSource myPlayer;

    [SerializeField] AudioClip cabinSound;
    [SerializeField] AudioClip roomSound;
    [SerializeField] AudioClip houseSound;

    [SerializeField] bool isCabin;
    [SerializeField] bool isRoom;
    [SerializeField] bool isHouse;


    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
        myPlayer=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void doorOpen()
    {
        if(!isOpen)
        {
            anim.SetTrigger("Open");
            isOpen=true;
            if(isCabin)
            {
                myPlayer.clip=cabinSound;
                myPlayer.Play();
            }
            
            if(isHouse)
            {
                myPlayer.clip=houseSound;
                myPlayer.Play();
            }
            
            if(isRoom)
            {
                myPlayer.clip=roomSound;
                myPlayer.Play();
            }
        }

        else if(isOpen)
        {
            anim.SetTrigger("Close");
            isOpen=false;

            if(isCabin)
            {
                myPlayer.clip=cabinSound;
                myPlayer.Play();
            }
            
            if(isHouse)
            {
                myPlayer.clip=houseSound;
                myPlayer.Play();
            }
            
            if(isRoom)
            {
                myPlayer.clip=roomSound;
                myPlayer.Play();
            }
        }
    }
}
