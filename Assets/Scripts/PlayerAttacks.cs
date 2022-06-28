using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{

    private Animator anim;
    public float attackStamina;
    [SerializeField] float maxAttackStamina=10f;
    [SerializeField] float attackDrain=2f;
    [SerializeField] float attackRefil=1f;
    [SerializeField] GameObject crossAir;
    [SerializeField] GameObject pointer;
    [SerializeField] AudioClip gunSound;
    [SerializeField] AudioClip bowShotSound;
    private AudioSource myPlayer;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
        attackStamina=maxAttackStamina;
        crossAir.SetActive(false);
        myPlayer=GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(attackStamina < maxAttackStamina)
        {
            attackStamina+=attackRefil*Time.deltaTime;
        }

        if(attackStamina <= 0.1f)
        {
            attackStamina=0.1f;
        }

        if(attackStamina > 3f)
        {
            Debug.Log(attackStamina);
            if(SaveScript.holdsKnife)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    anim.SetTrigger("KnifeLMB");
                    attackStamina-=attackDrain;
                }

                if(Input.GetMouseButtonDown(1))
                {
                    anim.SetTrigger("KnifeRMB");
                    attackStamina-=attackDrain;
                }
            }

            if(SaveScript.holdsAxe)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    anim.SetTrigger("AxeLMB");
                    attackStamina-=attackDrain;
                }

                if(Input.GetMouseButtonDown(1))
                {
                    anim.SetTrigger("AxeRMB");
                    attackStamina-=attackDrain;
                }
            }     

            if(SaveScript.holdsBat)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    anim.SetTrigger("BatLMB");
                    attackStamina-=attackDrain;
                }

                if(Input.GetMouseButtonDown(1))
                {
                    anim.SetTrigger("BatRMB");
                    attackStamina-=attackDrain;
                }
            }

            if(SaveScript.holdsGun)
            {
                
                if(Input.GetMouseButton(1))
                {
                    anim.SetBool("AimGun",true);
                    crossAir.SetActive(true);
                    pointer.SetActive(false);
                }

                if(Input.GetMouseButtonUp(1))
                {
                    anim.SetBool("AimGun",false);
                    crossAir.SetActive(false);
                    pointer.SetActive(true);
                }

                if(Input.GetMouseButtonDown(0))
                {
                    if(SaveScript.bullets > 0)
                    {
                        myPlayer.clip=gunSound;
                        myPlayer.Play();
                    }
                }
            }

            if(SaveScript.holdsCrossBow)
            {
                
                if(Input.GetMouseButton(1))
                {
                    anim.SetBool("AimGun",true);
                    crossAir.SetActive(true);
                    pointer.SetActive(false);
                }

                if(Input.GetMouseButtonUp(1))
                {
                    anim.SetBool("AimGun",false);
                    crossAir.SetActive(false);
                    pointer.SetActive(true);
                }

                if(Input.GetMouseButtonDown(0))
                {
                    if(SaveScript.arrows > 0)
                    {
                        myPlayer.clip=bowShotSound;
                        myPlayer.Play();
                    }
                }
            }
        }
    }
}
