using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    private Animator anim;
    public bool isOpen=false;

    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void doorOpen()
    {
        if(!isOpen)
        {
            anim.SetTrigger("Open");
            isOpen=true;
        }

        else if(isOpen)
        {
            anim.SetTrigger("Close");
            isOpen=false;
        }
    }
}
