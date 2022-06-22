using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunUIScript : MonoBehaviour
{
    [SerializeField] Text bulletsAmt;
    // Start is called before the first frame update
    void Start()
    {
        bulletsAmt.text= SaveScript.bullets + "";
    }

    // Update is called once per frame
    void Update()
    {
        bulletsAmt.text= SaveScript.bullets + "";
        if(SaveScript.holdsGun && Input.GetMouseButtonDown(0))
        {
            if(SaveScript.bullets > 0)
            {
                SaveScript.bullets -= 1;
            }
        }
    }
}
