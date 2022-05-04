using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{

    private NavMeshAgent nav;

    private Transform target;
    private float distanceToTarget;
    private int targetNumber=1;

    [SerializeField] float stopDistance=2f;
    [SerializeField] Transform tagret1;
    [SerializeField] Transform tagret2;
    // Start is called before the first frame update
    void Start()
    {
        nav=GetComponent<NavMeshAgent>();
        target=tagret1;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position,transform.position);

        if(distanceToTarget>stopDistance)
        {
            nav.SetDestination(target.position);
        }

        if(distanceToTarget<stopDistance)
        {
            ++targetNumber;

            if(targetNumber>2)
            {
                targetNumber=1;
            }
            setTarget();
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
    }
}
