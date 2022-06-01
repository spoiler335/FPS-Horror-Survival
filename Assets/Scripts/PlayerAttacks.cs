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
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
        attackStamina=maxAttackStamina;
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
        }
    }
}
