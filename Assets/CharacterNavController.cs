using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterNavController : MonoBehaviour
{
    public Transform target;
    public float runRadius = 100f;
    private Animator bunny;
    private UnityEngine.AI.NavMeshAgent navmesh;
    private Transform[] destination;

    private int currentPoint;
    private int runSpeed;

    [SerializeField] private bool inRange;
    [SerializeField] private float timer;
    [SerializeField] private float maxtimer = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        navmesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        bunny = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distTo = Vector3.Distance(transform.position, target.position);

        if(distTo <= runRadius)
        {
            timer += Time.deltaTime;

            if(timer > maxtimer)
            {
                inRange = true;
                bunny.SetBool("IsRunning", true);
                transform.LookAt(target);
                Vector3 rutTo = Vector3.MoveTowards(transform.position,target.position, 1000f);
                Debug.Log(rutTo);
                navmesh.destination = -rutTo;
            }
         
        }
        else if(distTo > runRadius)
        {
            bunny.SetBool("IsRunning", false);
            inRange = false;
            BackToPosition();
        }
    }

    void BackToPosition()
    {
        if(!inRange && navmesh.remainingDistance < 0.5f)
        {
            navmesh.destination = destination[currentPoint].position;
            UpdateCurrentPoint();
        }
    }

    void UpdateCurrentPoint()
    {
        if(currentPoint == destination.Length -1)
        {
            currentPoint=0;
        }
        else
        {
            currentPoint++;
        }
    }
}
