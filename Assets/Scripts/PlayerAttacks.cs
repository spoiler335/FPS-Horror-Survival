using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SaveScript.holdsKnife)
        {
            if(Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("KnifeLMB");
            }

            if(Input.GetMouseButtonDown(1))
            {
                anim.SetTrigger("KnifeRMB");
            }
        }

        if(SaveScript.holdsAxe)
        {
            if(Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("AxeLMB");
            }

            if(Input.GetMouseButtonDown(1))
            {
                anim.SetTrigger("AxeRMB");
            }
        }     

        if(SaveScript.holdsBat)
        {
            if(Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("BatLMB");
            }

            if(Input.GetMouseButtonDown(1))
            {
                anim.SetTrigger("BatRMB");
            }
        }
    }
}
