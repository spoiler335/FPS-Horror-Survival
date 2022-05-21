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
    [SerializeField] GameObject chaseMusic;

    // Start is called before the first frame update
    void Start()
    {
        nav=GetComponentInParent<NavMeshAgent>(); 

        StartCoroutine(startWalking());

        chaseMusic.SetActive(false);
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
                    failedChecks=0;
                }

                if(blocked)
                {
                    Debug.Log("can't see the player");
                    runToPlayer=false;
                    anim.SetInteger("State",1);
                    ++failedChecks;
                }

                StartCoroutine(timeChecked());
            }
        }

        if(runToPlayer)
        {
            enemy.GetComponent<EnemyMove>().enabled=false;
            chaseMusic.SetActive(true);
            if(distanceToPlayer > attackDistance)
            {
                nav.isStopped=false;
                anim.SetInteger("State",2);
                nav.acceleration=24;
                nav.SetDestination(player.position);
                nav.speed=chaseSpeed;
            }

            if(distanceToPlayer < attackDistance - 0.5f)
            {
                nav.isStopped=true;
                Debug.Log("Attacking");
                anim.SetInteger("State",3);
                nav.acceleration=180;

                Vector3 pos = (player.position - enemy.transform.position).normalized;
                Quaternion posRotation= Quaternion.LookRotation(new Vector3(pos.x,0,pos.y));
                enemy.transform.rotation=Quaternion.Slerp(enemy.transform.rotation,posRotation,Time.deltaTime*attackRotateSpeed);
            }
        }

        if(!runToPlayer)
        {
            nav.isStopped=true;
            enemy.GetComponent<EnemyMove>().enabled=true;
            anim.SetInteger("State",0);
            nav.speed=walkSpeed;
            chaseMusic.SetActive(false);
            isCheking=true;
        }
    }
    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            runToPlayer=true;
        }    
    }

    IEnumerator timeChecked()
    {
        yield return new WaitForSeconds(checkTime);
        isCheking =true;
        enemy.GetComponent<EnemyMove>().enabled=true;
        
        if(failedChecks>maxChecks)
        {
            enemy.GetComponent<EnemyMove>().enabled=true;
            nav.isStopped=false;
            nav.speed=walkSpeed;
            failedChecks=0;
            chaseMusic.SetActive(false);
        }
    }

    IEnumerator startWalking()
    {
        yield return new WaitForSeconds(1f);
        runToPlayer=true;
        yield return new WaitForSeconds(0.1f);
        runToPlayer=false;
    }
}
