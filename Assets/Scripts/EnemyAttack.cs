using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    private NavMeshAgent nav;
    private NavMeshHit hit;
    private bool blocked=false;
    private bool runToPlayer=false;
    private float distanceToPlayer;
    private bool isCheking;
    private int failedChecks=0;

    [SerializeField] Animator anim;
    [SerializeField] Transform player;
    [SerializeField] GameObject enemy;
    [SerializeField] float maxRange=35f;
    [SerializeField] int maxChecks=3;
    [SerializeField] float chaseSpeed=8.5f;
    [SerializeField] float walkSpeed=2.5f;
    [SerializeField] float attackDistance=2.3f;
    [SerializeField] float attackRotateSpeed = 2f;
    [SerializeField] float checkTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        nav=GetComponentInParent<NavMeshAgent>(); 

        StartCoroutine(startWalking());
    }

    // Update is called once per frame
    void Update()
    {   
        distanceToPlayer=Vector3.Distance(player.position,enemy.transform.position);

        if(distanceToPlayer> maxRange)
        {
            runToPlayer=false;
            nav.isStopped=true;
            nav.speed=walkSpeed;
            enemy.GetComponent<EnemyMove>().enabled=true;
        }

        if(distanceToPlayer <= maxRange)
        {
            if(isCheking)
            {
                isCheking=false;

                blocked=NavMesh.Raycast(transform.position, player.position, out hit, NavMesh.AllAreas);

                if(!blocked)
                {
                    Debug.Log("Can see Player");
                    runToPlayer=true;
                }

                if(blocked)
                {
                    Debug.Log("can't see the player");
                    runToPlayer=false;
                    anim.SetInteger("State",1);
                }

                StartCoroutine(timeChecked());
            }
        }

        if(runToPlayer)
        {
            enemy.GetComponent<EnemyMove>().enabled=false;
            if(distanceToPlayer>attackDistance)
            {
                nav.isStopped=false;
                anim.SetInteger("State",2);
                nav.acceleration=24;
                nav.SetDestination(player.position);
                nav.speed=chaseSpeed;
            }

            if(distanceToPlayer<attackDistance)
            {
                nav.isStopped=true;
                Debug.Log("Attacking");
                nav.acceleration=180;
            }
        }

        if(!runToPlayer)
        {
            nav.isStopped=true;
        }
    }

    IEnumerator timeChecked()
    {
        yield return new WaitForSeconds(checkTime);
        isCheking =true;
        enemy.GetComponent<EnemyMove>().enabled=true;
    }

    IEnumerator startWalking()
    {
        yield return new WaitForSeconds(1f);
        runToPlayer=true;
        yield return new WaitForSeconds(0.1f);
        runToPlayer=false;
    }
}
