using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapondamage : MonoBehaviour
{
    [SerializeField] int weaponDamage=1;
    [SerializeField] Animator hurtAnim;
    [SerializeField] AudioSource attackSound;
    private bool hitAtive=false;
    [SerializeField] GameObject fpsArms;
   
   private void OnTriggerEnter(Collider other) 
   {
       if(other.CompareTag("Player"))
       {
           if(!hitAtive)
           {
               hitAtive=true;
               hurtAnim.SetTrigger("Hurt");
               SaveScript.playerHealth-=weaponDamage;
               SaveScript.healthChanged=true;
               attackSound.Play();
               fpsArms.GetComponent<PlayerAttacks>().attackStamina-=3;
           }
       }    
   }

   private void OnTriggerExit(Collider other) 
   {
       if(other.CompareTag("Player"))
       {
           if(hitAtive)
           {
               hitAtive=false;
           }
       }    
   }
}
