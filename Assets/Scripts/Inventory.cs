using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject inventoryMenu;
    private bool inventoryActive=false;

    private AudioSource myPlayer;
    [SerializeField] AudioClip apppleBite;
    [SerializeField] AudioClip batteryChange;
    [SerializeField] AudioClip weaponChange;
    [SerializeField] AudioClip gunShot;
    [SerializeField] AudioClip arrowShot;


    [SerializeField] GameObject playerarms;
    [SerializeField] GameObject knife;
    [SerializeField] GameObject bat;
    [SerializeField] GameObject axe;
    [SerializeField] GameObject handGun;
    [SerializeField] GameObject crossBow;



    //apples
    [SerializeField] GameObject appleImage1;
    [SerializeField] GameObject appleButton1;
    [SerializeField] GameObject appleImage2;
    [SerializeField] GameObject appleButton2;
    [SerializeField] GameObject appleImage3;
    [SerializeField] GameObject appleButton3;
    [SerializeField] GameObject appleImage4;
    [SerializeField] GameObject appleButton4;
    [SerializeField] GameObject appleImage5;
    [SerializeField] GameObject appleButton5;
    [SerializeField] GameObject appleImage6;
    [SerializeField] GameObject appleButton6;





    //battries
    [SerializeField] GameObject batteryImage1;
    [SerializeField] GameObject batteryButton1;
    [SerializeField] GameObject batteryImage2;
    [SerializeField] GameObject batteryButton2;
    [SerializeField] GameObject batteryImage3;
    [SerializeField] GameObject batteryButton3;
    [SerializeField] GameObject batteryImage4;
    [SerializeField] GameObject batteryButton4;


    //weapons
    [SerializeField] GameObject knifeImage;    
    [SerializeField] GameObject knifeButton;    
    [SerializeField] GameObject axeImage;    
    [SerializeField] GameObject axeButton;  
    [SerializeField] GameObject batImage;    
    [SerializeField] GameObject batButton;  
    [SerializeField] GameObject gunImage;    
    [SerializeField] GameObject gunButton;  
    [SerializeField] GameObject corssbowImage;    
    [SerializeField] GameObject crossbowButton;  


    //keys
    [SerializeField] GameObject cabinKey;
    [SerializeField] GameObject roomKey;
    [SerializeField] GameObject houseKey;

    //ammo
    [SerializeField] GameObject bulletClipImage1;
    [SerializeField] GameObject bulletClipButton1;
    [SerializeField] GameObject bulletClipImage2;
    [SerializeField] GameObject bulletClipButton2;
    [SerializeField] GameObject bulletClipImage3;
    [SerializeField] GameObject bulletClipButton3;
    [SerializeField] GameObject bulletClipImage4;
    [SerializeField] GameObject bulletClipButton4;

    [SerializeField] GameObject arrowImage;
    [SerializeField] GameObject arrowButton;
    
    [SerializeField] Animator anim;
    void Start()
    {
        inventoryMenu.SetActive(false);
        inventoryActive=false;
        Cursor.visible=false;   
        myPlayer= GetComponent<AudioSource>();

        //apple
        appleImage1.gameObject.SetActive(false);
        appleButton1.gameObject.SetActive(false);
        appleImage2.gameObject.SetActive(false);
        appleButton2.gameObject.SetActive(false);
        appleImage3.gameObject.SetActive(false);
        appleButton3.gameObject.SetActive(false);
        appleImage4.gameObject.SetActive(false);
        appleButton4.gameObject.SetActive(false);
        appleImage5.gameObject.SetActive(false);
        appleButton5.gameObject.SetActive(false);
        appleImage6.gameObject.SetActive(false);
        appleButton6.gameObject.SetActive(false);
        


        //battries
        batteryImage1.gameObject.SetActive(false);
        batteryButton1.gameObject.SetActive(false);
        batteryImage2.gameObject.SetActive(false);
        batteryButton2.gameObject.SetActive(false);
        batteryImage3.gameObject.SetActive(false);
        batteryButton3.gameObject.SetActive(false);
        batteryImage4.gameObject.SetActive(false);
        batteryButton4.gameObject.SetActive(false);
        

        //weapons
        knifeImage.SetActive(false);
        knifeButton.SetActive(false);
        axeImage.SetActive(false);
        axeButton.SetActive(false);
        batImage.SetActive(false);
        batButton.SetActive(false);
        gunImage.SetActive(false);
        gunButton.SetActive(false);
        corssbowImage.SetActive(false);
        crossbowButton.SetActive(false);

        //keys
        cabinKey.SetActive(false);
        roomKey.SetActive(false);
        houseKey.SetActive(false);

        //ammo
        bulletClipImage1.SetActive(false);
        bulletClipButton1.SetActive(false);
        bulletClipImage2.SetActive(false);
        bulletClipButton2.SetActive(false);
        bulletClipImage3.SetActive(false);
        bulletClipButton3.SetActive(false);
        bulletClipImage4.SetActive(false);
        bulletClipButton4.SetActive(false);
        arrowButton.SetActive(false);
        arrowImage.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if(inventoryActive)
            {
                inventoryMenu.SetActive(false);
                inventoryActive=false;
                Time.timeScale=1f;
                Cursor.visible=false;
                SaveScript.holdsKnife=false;
                SaveScript.holdsAxe=false;
                SaveScript.holdsBat=true;
            }
            
            else
            {
                inventoryMenu.SetActive(true);
                inventoryActive=true;
                Time.timeScale=0f;
                Cursor.visible=true;
            }
        }
        checkInventory();
        checkWeapons();
        checkKeys();
        checkAmmo();
    }

    private void checkAmmo()
    {
        if(SaveScript.bulletClips==0)
        {
            bulletClipImage1.SetActive(false);
            bulletClipButton1.SetActive(false);
            bulletClipImage2.SetActive(false);
            bulletClipButton2.SetActive(false);
            bulletClipImage3.SetActive(false);
            bulletClipButton3.SetActive(false);
            bulletClipImage4.SetActive(false);
            bulletClipButton4.SetActive(false);
        }

        else if(SaveScript.bulletClips==1)
        {
            bulletClipImage1.SetActive(true);
            bulletClipButton1.SetActive(true);
            bulletClipImage2.SetActive(false);
            bulletClipButton2.SetActive(false);
            bulletClipImage3.SetActive(false);
            bulletClipButton3.SetActive(false);
            bulletClipImage4.SetActive(false);
            bulletClipButton4.SetActive(false);
        }

        else if(SaveScript.bulletClips==2)
        {
            bulletClipImage1.SetActive(true);
            bulletClipButton1.SetActive(false);
            bulletClipImage2.SetActive(true);
            bulletClipButton2.SetActive(true);
            bulletClipImage3.SetActive(false);
            bulletClipButton3.SetActive(false);
            bulletClipImage4.SetActive(false);
            bulletClipButton4.SetActive(false);
        }

        else if(SaveScript.bulletClips==3)
        {
            bulletClipImage1.SetActive(true);
            bulletClipButton1.SetActive(false);
            bulletClipImage2.SetActive(true);
            bulletClipButton2.SetActive(false);
            bulletClipImage3.SetActive(true);
            bulletClipButton3.SetActive(true);
            bulletClipImage4.SetActive(false);
            bulletClipButton4.SetActive(false);
        }

        else if(SaveScript.bulletClips==4)
        {
            bulletClipImage1.SetActive(true);
            bulletClipButton1.SetActive(false);
            bulletClipImage2.SetActive(true);
            bulletClipButton2.SetActive(false);
            bulletClipImage3.SetActive(true);
            bulletClipButton3.SetActive(false);
            bulletClipImage4.SetActive(true);
            bulletClipButton4.SetActive(true);
        }
        

        if(SaveScript.arrowRefil)
        {
            arrowImage.SetActive(true);
            arrowButton.SetActive(true);
        }

        else
        {
            arrowButton.SetActive(false);
            arrowImage.SetActive(false);
        }
    }

    private void checkKeys()
    {
        if(SaveScript.hasCabinKey)
        {
            cabinKey.SetActive(true);
        }

        if(SaveScript.hasHouseKey)
        {
            houseKey.SetActive(true);
        }

        if(SaveScript.hasRoomKey)
        {
            roomKey.SetActive(true);
        }
    }

    void checkInventory()
    {
        if(SaveScript.apples==0)
        {
            appleImage1.gameObject.SetActive(false);
            appleButton1.gameObject.SetActive(false);
            appleImage2.gameObject.SetActive(false);
            appleButton2.gameObject.SetActive(false);
            appleImage3.gameObject.SetActive(false);
            appleButton3.gameObject.SetActive(false);
            appleImage4.gameObject.SetActive(false);
            appleButton4.gameObject.SetActive(false);
            appleImage5.gameObject.SetActive(false);
            appleButton5.gameObject.SetActive(false);
            appleImage6.gameObject.SetActive(false);
            appleButton6.gameObject.SetActive(false);
        }

        
        if(SaveScript.apples==1)
        {
            appleImage1.gameObject.SetActive(true);
            appleButton1.gameObject.SetActive(true);
            appleImage2.gameObject.SetActive(false);
            appleButton2.gameObject.SetActive(false);
            appleImage3.gameObject.SetActive(false);
            appleButton3.gameObject.SetActive(false);
            appleImage4.gameObject.SetActive(false);
            appleButton4.gameObject.SetActive(false);
            appleImage5.gameObject.SetActive(false);
            appleButton5.gameObject.SetActive(false);
            appleImage6.gameObject.SetActive(false);
            appleButton6.gameObject.SetActive(false);
        }

        if(SaveScript.apples==2)
        {
            appleImage1.gameObject.SetActive(true);
            appleButton1.gameObject.SetActive(false);
            appleImage2.gameObject.SetActive(true);
            appleButton2.gameObject.SetActive(true);
            appleImage3.gameObject.SetActive(false);
            appleButton3.gameObject.SetActive(false);
            appleImage4.gameObject.SetActive(false);
            appleButton4.gameObject.SetActive(false);
            appleImage5.gameObject.SetActive(false);
            appleButton5.gameObject.SetActive(false);
            appleImage6.gameObject.SetActive(false);
            appleButton6.gameObject.SetActive(false);
        }

        if(SaveScript.apples==3)
        {
            appleImage1.gameObject.SetActive(true);
            appleButton1.gameObject.SetActive(false);
            appleImage2.gameObject.SetActive(true);
            appleButton2.gameObject.SetActive(false);
            appleImage3.gameObject.SetActive(true);
            appleButton3.gameObject.SetActive(true);
            appleImage4.gameObject.SetActive(false);
            appleButton4.gameObject.SetActive(false);
            appleImage5.gameObject.SetActive(false);
            appleButton5.gameObject.SetActive(false);
            appleImage6.gameObject.SetActive(false);
            appleButton6.gameObject.SetActive(false);
        }

        if(SaveScript.apples==4)
        {
            appleImage1.gameObject.SetActive(true);
            appleButton1.gameObject.SetActive(false);
            appleImage2.gameObject.SetActive(true);
            appleButton2.gameObject.SetActive(false);
            appleImage3.gameObject.SetActive(true);
            appleButton3.gameObject.SetActive(false);
            appleImage4.gameObject.SetActive(true);
            appleButton4.gameObject.SetActive(true);
            appleImage5.gameObject.SetActive(false);
            appleButton5.gameObject.SetActive(false);
            appleImage6.gameObject.SetActive(false);
            appleButton6.gameObject.SetActive(false);
        }

        if(SaveScript.apples==5)
        {
            appleImage1.gameObject.SetActive(true);
            appleButton1.gameObject.SetActive(false);
            appleImage2.gameObject.SetActive(true);
            appleButton2.gameObject.SetActive(false);
            appleImage3.gameObject.SetActive(true);
            appleButton3.gameObject.SetActive(false);
            appleImage4.gameObject.SetActive(true);
            appleButton4.gameObject.SetActive(false);
            appleImage5.gameObject.SetActive(true);
            appleButton5.gameObject.SetActive(true);
            appleImage6.gameObject.SetActive(false);
            appleButton6.gameObject.SetActive(false);
        }

        if(SaveScript.apples==6)
        {
            appleImage1.gameObject.SetActive(true);
            appleButton1.gameObject.SetActive(false);
            appleImage2.gameObject.SetActive(true);
            appleButton2.gameObject.SetActive(false);
            appleImage3.gameObject.SetActive(true);
            appleButton3.gameObject.SetActive(false);
            appleImage4.gameObject.SetActive(true);
            appleButton4.gameObject.SetActive(false);
            appleImage5.gameObject.SetActive(true);
            appleButton5.gameObject.SetActive(false);
            appleImage6.gameObject.SetActive(true);
            appleButton6.gameObject.SetActive(true);
        }




        if(SaveScript.battries==0)
        {
            batteryButton1.gameObject.SetActive(false);
            batteryImage1.gameObject.SetActive(false);
            batteryImage2.gameObject.SetActive(false);
            batteryButton2.gameObject.SetActive(false);
            batteryImage3.gameObject.SetActive(false);
            batteryButton3.gameObject.SetActive(false);
            batteryImage4.gameObject.SetActive(false);
            batteryButton4.gameObject.SetActive(false);
        }

        else if(SaveScript.battries==1)
        {
            batteryButton1.gameObject.SetActive(true);
            batteryImage1.gameObject.SetActive(true);
            batteryImage2.gameObject.SetActive(false);
            batteryButton2.gameObject.SetActive(false);
            batteryImage3.gameObject.SetActive(false);
            batteryButton3.gameObject.SetActive(false);
            batteryImage4.gameObject.SetActive(false);
            batteryButton4.gameObject.SetActive(false);
        }

        else if(SaveScript.battries==2)
        {
            batteryButton1.gameObject.SetActive(false);
            batteryImage1.gameObject.SetActive(true);
            batteryImage2.gameObject.SetActive(true);
            batteryButton2.gameObject.SetActive(true);
            batteryImage3.gameObject.SetActive(false);
            batteryButton3.gameObject.SetActive(false);
            batteryImage4.gameObject.SetActive(false);
            batteryButton4.gameObject.SetActive(false);
        }

        else if(SaveScript.battries==3)
        {
            batteryButton1.gameObject.SetActive(false);
            batteryImage1.gameObject.SetActive(true);
            batteryImage2.gameObject.SetActive(true);
            batteryButton2.gameObject.SetActive(false);
            batteryImage3.gameObject.SetActive(true);
            batteryButton3.gameObject.SetActive(true);
            batteryImage4.gameObject.SetActive(false);
            batteryButton4.gameObject.SetActive(false);
        }

        else if(SaveScript.battries==4)
        {
            batteryButton1.gameObject.SetActive(false);
            batteryImage1.gameObject.SetActive(true);
            batteryImage2.gameObject.SetActive(true);
            batteryButton2.gameObject.SetActive(false);
            batteryImage3.gameObject.SetActive(true);
            batteryButton3.gameObject.SetActive(false);
            batteryImage4.gameObject.SetActive(true);
            batteryButton4.gameObject.SetActive(true);
        }
    }


    void checkWeapons()
    {
        if(SaveScript.Knife)
        {
            knifeImage.SetActive(true);
            knifeButton.SetActive(true);
        }

        if(SaveScript.Axe)
        {
            axeImage.SetActive(true);
            axeButton.SetActive(true);
        }

        if(SaveScript.Bat)
        {
            batImage.SetActive(true);
            batButton.SetActive(true);
        }

        if(SaveScript.Gun)
        {
            gunImage.SetActive(true);
            gunButton.SetActive(true);
        }

        if(SaveScript.Crossbow)
        {
            corssbowImage.SetActive(true);
            crossbowButton.SetActive(true);
        }
    } 

    public void healthUpdate()
    {
        if(SaveScript.playerHealth < 100)
        {
            SaveScript.playerHealth+=10;
            SaveScript.healthChanged=true;
            SaveScript.apples--;
            myPlayer.clip=apppleBite;
            myPlayer.Play();
        }

        if(SaveScript.playerHealth > 100)
        {
            SaveScript.playerHealth=100;
        }
    }


    public void batteryRefil()
    {
        SaveScript.batteryRefil=true;
        SaveScript.battries-=1;

        myPlayer.clip=batteryChange;
        myPlayer.Play();
    }


    public void assignKnife()
    {
        playerarms.SetActive(true);
        knife.SetActive(true);
        anim.SetBool("Meele",true);
        myPlayer.clip=weaponChange;
        myPlayer.Play();
        SaveScript.holdsKnife=true;
        SaveScript.holdsAxe=false;
        SaveScript.holdsBat=false;

    }

    public void assignBat()
    {
        playerarms.SetActive(true);
        bat.SetActive(true);
        anim.SetBool("Meele",true);
        myPlayer.clip=weaponChange;
        myPlayer.Play();
        SaveScript.holdsKnife=false;
        SaveScript.holdsAxe=false;
        SaveScript.holdsBat=true;
    }

    public void assignAxe()
    {
        playerarms.SetActive(true);
        axe.SetActive(true);
        anim.SetBool("Meele",true);
        myPlayer.clip=weaponChange;
        myPlayer.Play();
        SaveScript.holdsKnife=false;
        SaveScript.holdsAxe=true;
        SaveScript.holdsBat=false;
    }

    public void weaponsOff()
    {
        axe.SetActive(false);
        bat.SetActive(false);
        knife.SetActive(false);
        handGun.SetActive(false);
        crossBow.SetActive(false);
    }

    public void assignGun()
    {
        playerarms.SetActive(true);
        handGun.SetActive(true);
        anim.SetBool("Meele",false);
        myPlayer.clip=gunShot;
        myPlayer.Play();
    }

    public void assigCrossBow()
    {
        playerarms.SetActive(true);
        crossBow.SetActive(true);
        anim.SetBool("Meele",false);
        myPlayer.clip=arrowShot;
        myPlayer.Play();
    }
}
