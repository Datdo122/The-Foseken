using UnityEngine;
using UnityEngine.AI;
using System;
using System.Collections;

public class platrollEnemyAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] StatusEnemy statusEnemy;
    [SerializeField] private Transform[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] Animator animEnemy;
    private float waitTime = 2f;
    public float timer;
    public bool isWaiting = false;
    private bool wasChasingPlayer = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        if (waypoints.Length > 0)
        {
            SetDistination();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if (waypoints.Length > 0)
        // {
        //     SetDistination();
        // }
        float speedEnemy = navMeshAgent.velocity.magnitude;
        animEnemy.SetFloat("xVelocity", speedEnemy);
        float distanceToTarget = Vector2.Distance(
            new Vector2(transform.position.x, transform.position.y), 
            new Vector2(waypoints[currentWaypointIndex].position.x, waypoints[currentWaypointIndex].position.y)
        );

        if (!navMeshAgent.pathPending && distanceToTarget< 2f && !isWaiting)
        {
            if (!isWaiting)
            {
                isWaiting = true;
                timer = waitTime;

                navMeshAgent.ResetPath();
            }
        }
        

        if (isWaiting)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                isWaiting = false;
                IterateWaypointIndex();
                SetDistination();
            }
        }
        FlipTowardsVelocity();
        Debug.Log(speedEnemy);
    }

    void OnEnable()
    {
        // 1. Nếu lúc bị tắt script quái đang chờ, thì bây giờ bắt nó thôi chờ
        isWaiting = false; 
        timer = 0;

        // 2. Nhả phanh tay NavMesh
        if (navMeshAgent != null)
        {
            navMeshAgent.isStopped = false;

            // 3. Quan trọng nhất: Nạp lại đích đến là Waypoint hiện tại
            // Bất kể quái đang ở đâu (cách 2m hay 20m), nó sẽ phải đi về đó
            if (waypoints.Length > 0)
            {
                SetDistination();
            }
        }
    }

    public void SetDistination()
    {
        if (waypoints.Length == 0) return;
        navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
    }

    public void IterateWaypointIndex()
    {
        currentWaypointIndex++;
        if (currentWaypointIndex >= waypoints.Length)
        {
            currentWaypointIndex = 0;
        }
    }


    public void FlipTowardsVelocity()
    {
        if (navMeshAgent.velocity.x > 0.1f)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
        }
        else if (navMeshAgent.velocity.x < -0.1f)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
        }
    }
}
