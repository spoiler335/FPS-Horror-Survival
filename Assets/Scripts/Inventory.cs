using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject inventoryMenu;
    private bool inventoryActive=false;
    void Start()
    {
        inventoryMenu.SetActive(false);
        inventoryActive=false;
        Cursor.visible=false;   
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
    }
}
