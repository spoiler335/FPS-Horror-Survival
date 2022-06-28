using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{

    private NavMeshAgent nav;
    private Animator anim;
    private Transform target;
    private float distanceToTarget;
    private int targetNumber=1;
    private bool hasStopped =false ;
    private bool randomiser =true;
    private int nextTargetNumber;

    [SerializeField] float stopDistance=2f;
    [SerializeField] int maxTargets=10;
    [SerializeField] float waitTime=2.0f;
    [SerializeField] Transform tagret1;
    [SerializeField] Transform tagret2;

    [SerializeField] Transform tagret3;
    [SerializeField] Transform tagret4;

    [SerializeField] Transform tagret5;
    [SerializeField] Transform tagret6;
    [SerializeField] Transform tagret7;
    [SerializeField] Transform tagret8;
    [SerializeField] Transform tagret9;
    [SerializeField] Transform tagret10;

    

    // Start is called before the first frame update
    void Start()
    {
        nav=GetComponent<NavMeshAgent>();
        target=tagret1;

        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position,transform.position);

        if(distanceToTarget>stopDistance)
        {
            nav.SetDestination(target.position);
            nav.isStopped=false;
            anim.SetInteger("State",0);
            nextTargetNumber=targetNumber;
            nav.speed = 1.6f;
        }

        if(distanceToTarget<stopDistance)
        {
            nav.isStopped=true;
            anim.SetInteger("State",1);
            StartCoroutine(lookAround());
        }
    }

    
    void setTarget()
    {
        if(targetNumber==1)
        {
            target=tagret1;
        }

        if(targetNumber==2)
        {
            target=tagret2;
        }

        if(targetNumber==3)
        {
            target=tagret3;
        }

        if(targetNumber==4)
        {
            target=tagret4;
        }

        if(targetNumber==5)
        {
            target=tagret5;
        }

        if(targetNumber==6)
        {
            target=tagret6;
        }

        if(targetNumber==7)
        {
            target=tagret7;
        }

        if(targetNumber==8)
        {
            target=tagret8;
        }

        if(targetNumber==9)
        {
            target=tagret9;
        }

        if(targetNumber==10)
        {
            target=tagret10;
        }
    }

    IEnumerator lookAround()
    {
        yield return new WaitForSeconds(waitTime);

        if(!hasStopped)
        {
            hasStopped=true;
            
            if(randomiser)
            {
                randomiser=false;
                targetNumber=Random.Range(1,maxTargets);
            

                if(targetNumber == nextTargetNumber)
                {
                    ++targetNumber;

                    if(targetNumber >= maxTargets)
                    {
                    targetNumber=1;       
                    }
                }
                
            }
            setTarget();

            yield return new WaitForSeconds(waitTime);
            hasStopped=false;
            randomiser=true;
        }
    }


}
