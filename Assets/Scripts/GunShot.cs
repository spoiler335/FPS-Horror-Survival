using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot : MonoBehaviour
{
    RaycastHit hit;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(SaveScript.holdsGun)
        {
            if(Input.GetKey(KeyCode.Mouse1) && Input.GetKey(KeyCode.Mouse0) )
            {
                if(Physics.Raycast(transform.position,transform.forward,out hit,3000))
                {
                    if(hit.transform.Find("Body"))
                    {
                        hit.transform.GetComponentInChildren<EnemyDamage>().enemyHealth-=Random.Range(30,90);
                        hit.transform.GetComponent<Animator>().SetTrigger("BigReact");
                    }
                }
            }  
        }
    }
}
