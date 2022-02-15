using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public Transform target;
    public float runRadius = 100f;
    private Animator bunny;
    private UnityEngine.AI.NavMeshAgent navmesh;
    private Transform[] destination;

    private int currentPoint;
    private int runSpeed;


    [SerializeField] private float timer;
    [SerializeField] private float maxtimer = 1f;
    private NavMeshAgent agent;

    public float radius;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();  
        navmesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        bunny = GetComponent<Animator>();     
    }

    // Update is called once per frame
    void Update()
    {
       // if(!agent.hasPath)
       // {
      //      agent.SetDestination(GetPoints.Instance.GetRandomPoint(transform,radius));
      //  }

          float distTo = Vector3.Distance(transform.position, target.position);

        if(distTo <= runRadius && !agent.hasPath)
        {
            timer += Time.deltaTime;

            if(timer > maxtimer)
            {
                agent.SetDestination(GetPoints.Instance.GetRandomPoint(transform,radius));
                bunny.SetBool("IsRunning", true);       
            }
         
        }
        else if(distTo > runRadius)
        {
            bunny.SetBool("IsRunning", false);
         
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

#endif

}
