using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject inventoryMenu;
    private bool inventoryActive=false;

    [SerializeField] GameObject appleImage1;
    [SerializeField] GameObject appleButton1;

    [SerializeField] GameObject batteryImage1;
    [SerializeField] GameObject batteryButton1;
    [SerializeField] GameObject batteryImage2;
    [SerializeField] GameObject batteryButton2;
    [SerializeField] GameObject batteryImage3;
    [SerializeField] GameObject batteryButton3;
    [SerializeField] GameObject batteryImage4;
    [SerializeField] GameObject batteryButton4;

    void Start()
    {
        inventoryMenu.SetActive(false);
        inventoryActive=false;
        Cursor.visible=false;   
        appleImage1.gameObject.SetActive(false);
        appleButton1.gameObject.SetActive(false);



        batteryImage1.gameObject.SetActive(false);
        batteryButton1.gameObject.SetActive(false);
        batteryImage2.gameObject.SetActive(false);
        batteryButton2.gameObject.SetActive(false);
        batteryImage3.gameObject.SetActive(false);
        batteryButton3.gameObject.SetActive(false);
        batteryImage4.gameObject.SetActive(false);
        batteryButton4.gameObject.SetActive(false);
        
        
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
    }

    void checkInventory()
    {
        if(SaveScript.apples==1)
        {
            appleImage1.gameObject.SetActive(true);
            appleButton1.gameObject.SetActive(true);
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


    public void healthUpdate()
    {
        SaveScript.playerHealth+=10;
        SaveScript.healthChanged=true;
        SaveScript.apples--;
        appleImage1.gameObject.SetActive(false);
        appleButton1.gameObject.SetActive(false);
    }


    public void batteryRefil()
    {
        SaveScript.batteryRefil=true;
        SaveScript.battries-=1;

        
    }


}
