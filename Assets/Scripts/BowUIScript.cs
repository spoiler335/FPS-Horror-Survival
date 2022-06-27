using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowUIScript : MonoBehaviour
{
   
    [SerializeField] Text arrowAmt;
    void Start()
    {
        arrowAmt.text = SaveScript.arrows + "" ;
    }

    
    void Update()
    {
        arrowAmt.text = SaveScript.arrows + "" ;
        
        if(SaveScript.holdsCrossBow && Input.GetMouseButtonDown(0))
        {
            if(SaveScript.arrows > 0)
            {
                SaveScript.arrows -= 1;
            }
        }
    }
}
