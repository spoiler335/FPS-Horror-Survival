using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject inventoryMenu;
    private bool inventoryActive=false;

    [SerializeField] GameObject appleImage1;
    [SerializeField] GameObject appleButton1;

    void Start()
    {
        inventoryMenu.SetActive(false);
        inventoryActive=false;
        Cursor.visible=false;   
        appleImage1.gameObject.SetActive(false);
        appleButton1.gameObject.SetActive(false);
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
    }


}
